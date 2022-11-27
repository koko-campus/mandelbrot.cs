using CommandLine;

class Options
{
  [Option('w', "width", Required = false, HelpText = "画像の横幅を指定します。")]
  internal int Width { get; set; } = 500;
  
  [Option('h', "height", Required = false, HelpText = "画像の縦幅を指定します。")]
  internal int Height { get; set; } = 500;
  
  [Option('r', "resolution", Required = false, HelpText = "解像度を指定します。")]
  internal double Resolution { get; set; } = 200;
  
  [Option("re", Required = false, HelpText = "実軸の開始点を指定します。")]
  internal double Re { get; set; } = 0.5;

  [Option("im", Required = false, HelpText = "虚軸の開始点を指定します。")]
  internal double Im { get; set; } = -1.0;

  [Option("hue", Required = false, HelpText = "集合の着色を色相を指定します。")]
  internal int Hue { get; set; } = 0;

  [Option("limit", Required = false, HelpText = "収束判定の閾値を指定します。")]
  internal int Limit { get; set; } = 20;

  [Option("max", Required = false, HelpText = "最大反復回数を指定します。")]
  internal int Upto { get; set; } = 10;
  
  [Option("file", Required = false, HelpText = "出力先ファイル名を指定します。")]
  internal string File { get; set; } = "mandelbrot.gif";
  
  [Option("count", Required = false, HelpText = "カウントを指定します。")]
  internal int Count { get; set; } = 1;
}
