using System.Drawing;
using Microsoft.VisualStudio.Modeling.Diagrams;
using System.Numerics;
using CommandLine;

#pragma warning disable CA1416

internal static partial class Program
{
  internal static NLog.ILogger logger = NLog.LogManager.GetCurrentClassLogger();
  
  internal static int Main(string[] args)
  {
    try
    {
      var options = Parser.Default.ParseArguments<Options>(args);

      if (options.Tag == ParserResultType.NotParsed)
      {
        logger.Error("オプションの解析に失敗しました。");
        return 1;
      }

      // メイン処理

      // 必要な変数の宣言
      var width = options.Value.Width;
      var height = options.Value.Height;
      var resolution = options.Value.Resolution;
      var Re = options.Value.Re;
      var Im = options.Value.Im;
      var hue = options.Value.Hue;
      var limit = options.Value.Limit;
      var upto = options.Value.Upto;
      var file = options.Value.File;
      var count = options.Value.Count;      

      if (File.Exists(file)) File.Delete(file);

      Bitmap[] gifs = new Bitmap[count];
      List<Task> tasks = new();

      foreach (var counter in Enumerable.Range(0, count))
      {
        var task = Task.Run(() => {
          logger.Info($"画像ビットマップデータの生成を開始します。({counter} / {count})");
          var _resolution = resolution * Math.Pow(1.05, counter);
          Bitmap canvas = new(width, height);
          for (double x = 0; x < width; x++)
          {
            for (double y = 0; y < height; y++)
            {
              int result = Check(x / _resolution - Re, y / _resolution + Im, limit, upto);
              Color color = Color.Black;
              if (result != 0)
              {
                color = new HslColor(hue, 100, result).ToRgbColor();
              }
              canvas.SetPixel((int)x, (int)y, color);
            }
          }
          gifs[counter] = canvas;
          logger.Info($"画像ビットマップデータの生成が完了しました。({counter} / {count})");
        });
        tasks.Add(task);
      }
      Task.WhenAll(tasks).Wait();

      SaveAnimatedGif(file, gifs, 10, 0);

      return 0;
    } catch (Exception ex)
    {
      logger.Error(ex, "処理の実行中に対応されていない例外が発生しました。");
      return 1;
    }
  }

  private static int Check(double x, double y, int limit, int upto)
  {
    (var real, var imag) = (x, y);
    for (int i = 0; i < limit; i++)
    {
      Complex complex = new(real, imag);
      var ReIm = complex * complex;
      real = ReIm.Real + x; // Zの二乗 + C(実部)
      imag = ReIm.Imaginary + y; // Zの二乗 + C(虚部)
      if (upto < real * imag)
      {
        var result = (double)i / limit * 100;
        return (int)result;
      }
    }
    return 0;
  }
}

#pragma warning restore CA1416
