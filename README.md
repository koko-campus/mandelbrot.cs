# 「C#」 × 「マンデルブロ集合」

C#を使用してマンデルブロ集合を描写します。  
GIFフォーマットでマンデルブロ集合の探索をアニメーションを描写します。  
高速に画像ファイルを生成するため、非同期で処理を実行します。  

![成果物](./docs/img/mandelbrot.gif)  

## 実行方法

以下のパラメタをコマンドライン引数にセットして実行。  

- w (width) | 横幅
- h (height) | 縦幅
- rs (resolution) | 解像度
- r (re) | 実軸開始点
- i (im) | 虚軸開始点
- h (hue) | 彩度
- l (limit) | 収束判定の閾値
- x (max) | 最大反復回数
- f (file) | 出力先ファイル名
- z (zoom) | ズームレベル
- c (count) | 画像数

## 開発環境

| 機能 | バージョン |
| ---- | ---- |
| Windows | 11 Home |
| C# | .NET依存 |
| .NET | 6.0 |
| Visual Studio | 2022 |
