using CommandLine;

class Options
{
  [Option('w', "width", Required = false, HelpText = "画像の横幅を指定します。")]
  internal int Width { get; set; } = 500;
  
  [Option('h', "height", Required = false, HelpText = "画像の縦幅を指定します。")]
  internal int Height { get; set; } = 500;
  
  [Option('s', "resolution", Required = false, HelpText = "解像度を指定します。")]
  internal double Resolution { get; set; } = 200;
  
  [Option('r', "re", Required = false, HelpText = "実軸の開始点を指定します。")]
  internal double Re { get; set; } = 0.5;

  [Option('i', "im", Required = false, HelpText = "虚軸の開始点を指定します。")]
  internal double Im { get; set; } = -1.0;

  [Option('h', "hue", Required = false, HelpText = "集合の着色を色相を指定します。")]
  internal int Hue { get; set; } = 0;

  [Option('l', "limit", Required = false, HelpText = "収束判定の閾値を指定します。")]
  internal int Limit { get; set; } = 20;

  [Option('x', "max", Required = false, HelpText = "最大反復回数を指定します。")]
  internal int Upto { get; set; } = 10;
  
  [Option('f', "file", Required = false, HelpText = "出力先ファイル名を指定します。")]
  internal string File { get; set; } = "mandelbrot.gif";

  [Option('z', "zoom", Required = false, HelpText = "ズームレベルを設定します。")]
  internal double Zoom { get; set; } = 1.05;

  [Option('c', "count", Required = false, HelpText = "カウントを指定します。")]
  internal int Count { get; set; } = 30;
}
