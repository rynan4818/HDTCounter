# HDTCounter

このBeatSaberプラグインは、デンパ時計さんの製作された[HeadDistanceTravelled](https://github.com/denpadokei/HeadDistanceTravelled)のHMD移動距離[m]を表示する[CountersPlus](https://github.com/Caeden117/CountersPlus)用のカスタムカウンターです。

![image](https://user-images.githubusercontent.com/14249877/172158178-c825414b-6bc0-41b4-8ea5-7851f0afc8dd.png)

# インストール方法
1. [HeadDistanceTravelled](https://github.com/denpadokei/HeadDistanceTravelled)をインストールして動作するか確認します。

2. [リリースページ](https://github.com/rynan4818/HDTCounter/releases)から最新のHDTCounterのリリースをダウンロードします。

3. ダウンロードしたzipファイルをBeat Saberフォルダに解凍して、`Plugin`フォルダに`HDTCounter.dll`ファイルをコピーします。
    
4. このmodは以下のプラグインに依存するため、[ModAssistant](https://github.com/Assistant/ModAssistant)でインストールして下さい。

    - BSIPA
    - BeatSaberMarkupLanguage
    - SiraUtil
    - [CountersPlus](https://github.com/Caeden117/CountersPlus)
    - [HeadDistanceTravelled](https://github.com/denpadokei/HeadDistanceTravelled) ※1でインストール済
    
    それぞれの依存modの対応バージョンは[manifest.json](https://github.com/rynan4818/HDTCounter/blob/main/HDTCounter/manifest.json)の`dependsOn`項目を参照下さい。

# 使用方法
modをインストールすると、COUNTERS+の設定画面にHDT Counterが追加されますので、表示位置や詳細設定をして使用してください。
HDT Counterの設定値は以下の通りです。
|項目|説明|
|:---|:---|
|DecimalPrecision|小数点以下を表示する桁数|
|EnableLabel|ラベル(Head Distance Travelled)の表示|
|LabelFontSize|ラベルのフォントサイズ|
|FigureFontSize|カウンターのフォントサイズ|
|OffsetX|カウンターのX軸オフセット|
|OffsetY|カウンターのY軸オフセット|
|OffsetZ|カウンターのZ軸オフセット|

数値を細かく設定したい場合は、`UserData\HDTCounter.json`を直接編集してください。
