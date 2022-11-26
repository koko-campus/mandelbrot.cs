using System.Drawing;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.Modeling.Diagrams;
using System.Numerics;

internal static partial class Program
{
  static int width = 500;
  static int height = 500;
  static double resolution = 200;
  static double Re = 0.5;
  static double Im = 2.0;
  static int hue = 0;
  static int limit = 20;
  static int upto = 10;
  static string file = "";
  static int count = 30;

  internal static int Main(string[] args)
  {
    Parse(args);

    if (IsNum(Obtain("-w"))) width = int.Parse(Obtain("-w"));
    if (IsNum(Obtain("-h"))) height = int.Parse(Obtain("-h"));
    if (IsNum(Obtain("-rs"))) resolution = double.Parse(Obtain("-rs"));
    if (IsNum(Obtain("-re"))) Re = double.Parse(Obtain("-re"));
    if (IsNum(Obtain("-im"))) Im = double.Parse(Obtain("-im"));
    if (IsNum(Obtain("-hue"))) hue = int.Parse(Obtain("-hue"));
    if (IsNum(Obtain("-limit"))) limit = int.Parse(Obtain("-limit"));
    if (IsNum(Obtain("-upto"))) upto = int.Parse(Obtain("-upto"));
    if (IsNum(Obtain("-count"))) count = int.Parse(Obtain("-count"));
    file = Obtain("-f") != "" ? Obtain("-f") : $@"1.gif";

    if (File.Exists(file)) File.Delete(file);

    Bitmap[] gifs = new Bitmap[count];
    List<Task> tasks = new List<Task>();

    foreach (var counter in Enumerable.Range(0, count))
    {
      var task = Task.Run(() => {
        Console.WriteLine($"{counter} started / out of ({count})");
        resolution *= 1.05;
        Bitmap canvas = new(width, height);
        for (double x = 0; x < width; x++)
        {
          for (double y = 0; y < height; y++)
          {
            int result = Check(x / resolution - Re, y / resolution - 3 + Im);
            Color color = Color.Black;
            if (result != 0)
            {
              color = new HslColor(hue, 100, result).ToRgbColor();
            }
            canvas.SetPixel((int)x, (int)y, color);
          }
        }
        gifs[counter] = canvas;
        Console.WriteLine($"{counter} ended / out of ({count})");
      });
      tasks.Add(task);
      Task.WhenAll(tasks).Wait();
    }
    Task.WhenAll(tasks).Wait();

    SaveAnimatedGif(file, gifs, 10, 0);

    return 0;
  }

  private static bool IsNum(string num)
  {
    return Regex.IsMatch(num, @"\w+\.?\w*");
  }

  private static int Check(double x, double y)
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

