# 「C#」 × 「マンデルブロ集合」

C#を使用してマンデルブロ集合を描写します。  
GIFフォーマットでマンデルブロ集合の探索をアニメーションを描写します。  
高速に画像ファイルを生成するため、非同期で処理を実行します。  

![成果物](./docs/img/mandelbrot.gif)  

## 実行方法

以下のパラメタをコマンドライン引数にセットして実行。 

```csharp
var width = options.Value.Width;
var height = options.Value.Height;
var resolution = options.Value.Resolution;
var Re = options.Value.Re;
var Im = options.Value.Im;
var hue = options.Value.Hue;
var limit = options.Value.Limit;
var upto = options.Value.Upto;
var file = options.Value.File;
var zoom = options.Value.Zoom;
var count = options.Value.Count;
```

## 開発環境

| 機能 | バージョン |
| ---- | ---- |
| Windows | 11 Home |
| C# | .NET依存 |
| .NET | 6.0 |
| Visual Studio | 2022 |
