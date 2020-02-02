using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
// using CeVIO.Talk.RemoteService;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.InteropServices;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using NMeCab;
using Microsoft.VisualBasic;

namespace MovieHachiTool
{
    class ModuleReuseClass
    {
        [DllImport("ole32.dll")]
        private static extern int OleDraw(IntPtr pUnk, int dwAspect, IntPtr hdcDraw, ref Rectangle lprcBounds);

        //*********************************************************************
        /// <summary>　指定されたWebサイトをbitmap画像として取得する
        /// http://nanoappli.com/blog/archives/2490
        /// </summary>
        /// <param name="url">キャプチャ対象のサイトURL</param>
        /// <returns>         ページの画像</returns>
        //*********************************************************************
        /* public static Bitmap getBitmapFromUrl(string url)
        {
            bool isCaptured = false;
            Bitmap bitmap = null;

            //------------------------------------------------
            // Webサイト情報取得用のブラウザコントロールを作成
            //------------------------------------------------

            WebBrowser browser = new WebBrowser();
            browser.ScrollBarsEnabled = false;
            browser.ScriptErrorsSuppressed = true;

            //---------------------------------------------
            // 指定URLへNavigate()完了時のハンドラを登録
            //---------------------------------------------
            browser.DocumentCompleted += (sender, e) => {
                if (e.Url.Equals("about:blank"))
                {
                    return;
                }

                try
                {
                    // キャプチャサイズを指定
                    browser.Width = browser.Document.Body.ScrollRectangle.Width;
                    browser.Height = browser.Document.Body.ScrollRectangle.Height;

                    // キャプチャの保存先bitmapを生成
                    bitmap = new Bitmap(browser.Width, browser.Height);

                    // 生成したbitmapにWebページの画像を保存
                    Graphics graphic = null;
                    IntPtr ptrObj = IntPtr.Zero;
                    IntPtr ptrHdc = IntPtr.Zero;
                    try
                    {
                        graphic = Graphics.FromImage(bitmap);
                        ptrHdc = graphic.GetHdc();
                        ptrObj = Marshal.GetIUnknownForObject(browser.ActiveXInstance);
                        Rectangle rect = new Rectangle(0, 0, browser.Width, browser.Height);

                        // ptrObj画像内のrectで指定した領域を,HDCのエリアに貼付
                        OleDraw(ptrObj, (int)DVASPECT.DVASPECT_CONTENT, ptrHdc, ref rect);
                    }
                    finally
                    {
                        if (ptrObj != IntPtr.Zero)
                        {
                            Marshal.Release(ptrObj);
                        }
                        if (ptrHdc != IntPtr.Zero)
                        {
                            graphic.ReleaseHdc(ptrHdc);
                        }
                        if (graphic != null)
                        {
                            graphic.Dispose();
                        }
                    }
                }
                finally
                {
                    isCaptured = true;
                }
            };

            //------------------------------------------------
            // 指定されたページへ遷移       
            //------------------------------------------------
            browser.Navigate(url);
            while (!isCaptured)
            {
                // 指定URLのロード&キャプチャが完了するのを待つ
                Application.DoEvents();
                System.Threading.Thread.Sleep(20);
            }

            // 取得したbmp情報を返す
            return bitmap;
        } */

        public static Bitmap getBitmapFromTitle(string inputTitle, string inputURL, string fontName)
        {
            var bmp = new Bitmap(1280, 720);
            //文字列を表示する範囲を指定する
            RectangleF rect = new RectangleF(100, 100, bmp.Width - 100, bmp.Height - 100);
            //ImageオブジェクトのGraphicsオブジェクトを作成する
            var g = Graphics.FromImage(bmp);

            try
            {
                //フォントオブジェクトの作成
                var fnt = new Font(fontName, 40);
                if (!string.IsNullOrEmpty(inputTitle))
                {
                    //文字列を位置(0,0)、青色で表示
                    g.DrawString(inputTitle, fnt, Brushes.Blue, rect);
                }

                //文字列を表示する範囲を指定する
                rect = new RectangleF(10, bmp.Height - 70, bmp.Width - 200, bmp.Height);

                if (!string.IsNullOrEmpty(inputURL))
                {
                    fnt = new Font(fontName, 20);
                    //文字列を位置(0,0)、青色で表示
                    g.DrawString(inputURL, fnt, Brushes.DarkSlateGray, rect);
                }

                //リソースを解放する
                fnt.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            g.Dispose();

            return bmp;
        }

        /* public static String getTitleFromURL(string inputURL)
        {
            WebClient wclnt = new WebClient();

            string htmlText = "";
            using (Stream strm = wclnt.OpenRead(inputURL))
            {
                byte[] byteData;
                byte[] buf = new byte[short.MaxValue];

                using (MemoryStream ms = new MemoryStream())
                {

                    while (true)
                    {
                        int read = strm.Read(buf, 0, buf.Length);

                        if (read > 0)
                        {
                            ms.Write(buf, 0, read);
                        }
                        else
                        {
                            break;
                        }
                    }
                    byteData = ms.ToArray();
                }
                // バイトデータから自動判別でエンコードした文字列を取得
                // Hnx8.ReadJEnc.ReadJEnc.JP.GetEncoding(byteData, byteData.Length, out htmlText);
                ModuleReuseClass.GetEncoding(byteData, byteData.Length, out htmlText);
            }
            // 正規表現でtitleタグ内のテキストのみ取得
            Match regmch = Regex.Match(htmlText, "(?.*?)", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            string title = regmch.Groups["title"].Value;
            return title;
        } */

        public static string getURLToFile(string inputURL, string outputFile)
        {
            WebClient wclnt = new WebClient();

            try
            {
                wclnt.DownloadFile(inputURL, outputFile);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Webベージの取得中にエラーが発生しました。\n" + ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return outputFile;
        }


        /// <summary>
        /// 文字コードを判別する
        /// </summary>
        /// <remarks>
        /// Jcode.pmのgetcodeメソッドを移植したものです。
        /// Jcode.pm(http://openlab.ring.gr.jp/Jcode/index-j.html)
        /// Jcode.pmの著作権情報
        /// Copyright 1999-2005 Dan Kogai <dankogai@dan.co.jp>
        /// This library is free software; you can redistribute it and/or modify it
        ///  under the same terms as Perl itself.
        /// </remarks>
        /// <param name="bytes">文字コードを調べるデータ</param>
        /// <returns>適当と思われるEncodingオブジェクト。
        /// 判断できなかった時はnull。</returns>
        public static System.Text.Encoding GetCode(byte[] bytes)
        {
            const byte bEscape = 0x1B;
            const byte bAt = 0x40;
            const byte bDollar = 0x24;
            const byte bAnd = 0x26;
            const byte bOpen = 0x28;    //'('
            const byte bB = 0x42;
            const byte bD = 0x44;
            const byte bJ = 0x4A;
            const byte bI = 0x49;

            var len = bytes.Length;
            byte b1, b2, b3, b4;

            //Encode::is_utf8 は無視

            var isBinary = false;
            for (int i = 0; i < len; i++)
            {
                b1 = bytes[i];
                if (b1 <= 0x06 || b1 == 0x7F || b1 == 0xFF)
                {
                    //'binary'
                    isBinary = true;
                    if (b1 == 0x00 && i < len - 1 && bytes[i + 1] <= 0x7F)
                    {
                        //smells like raw unicode
                        return System.Text.Encoding.Unicode;
                    }
                }
            }
            if (isBinary)
            {
                return null;
            }

            //not Japanese
            var notJapanese = true;
            for (int i = 0; i < len; i++)
            {
                b1 = bytes[i];
                if (b1 == bEscape || 0x80 <= b1)
                {
                    notJapanese = false;
                    break;
                }
            }
            if (notJapanese)
            {
                return System.Text.Encoding.ASCII;
            }

            for (int i = 0; i < len - 2; i++)
            {
                b1 = bytes[i];
                b2 = bytes[i + 1];
                b3 = bytes[i + 2];

                if (b1 == bEscape)
                {
                    if (b2 == bDollar && b3 == bAt)
                    {
                        //JIS_0208 1978
                        //JIS
                        return Encoding.GetEncoding(50220);
                    }
                    else if (b2 == bDollar && b3 == bB)
                    {
                        //JIS_0208 1983
                        //JIS
                        return Encoding.GetEncoding(50220);
                    }
                    else if (b2 == bOpen && (b3 == bB || b3 == bJ))
                    {
                        //JIS_ASC
                        //JIS
                        return Encoding.GetEncoding(50220);
                    }
                    else if (b2 == bOpen && b3 == bI)
                    {
                        //JIS_KANA
                        //JIS
                        return Encoding.GetEncoding(50220);
                    }
                    if (i < len - 3)
                    {
                        b4 = bytes[i + 3];
                        if (b2 == bDollar && b3 == bOpen && b4 == bD)
                        {
                            //JIS_0212
                            //JIS
                            return Encoding.GetEncoding(50220);
                        }
                        if (i < len - 5 &&
                            b2 == bAnd && b3 == bAt && b4 == bEscape &&
                            bytes[i + 4] == bDollar && bytes[i + 5] == bB)
                        {
                            //JIS_0208 1990
                            //JIS
                            return Encoding.GetEncoding(50220);
                        }
                    }
                }
            }

            //should be euc|sjis|utf8
            //use of (?:) by Hiroki Ohzaki <ohzaki@iod.ricoh.co.jp>
            var sjis = 0;
            var euc = 0;
            var utf8 = 0;
            for (int i = 0; i < len - 1; i++)
            {
                b1 = bytes[i];
                b2 = bytes[i + 1];
                if (((0x81 <= b1 && b1 <= 0x9F) || (0xE0 <= b1 && b1 <= 0xFC)) &&
                    ((0x40 <= b2 && b2 <= 0x7E) || (0x80 <= b2 && b2 <= 0xFC)))
                {
                    //SJIS_C
                    sjis += 2;
                    i++;
                }
            }
            for (int i = 0; i < len - 1; i++)
            {
                b1 = bytes[i];
                b2 = bytes[i + 1];
                if (((0xA1 <= b1 && b1 <= 0xFE) && (0xA1 <= b2 && b2 <= 0xFE)) ||
                    (b1 == 0x8E && (0xA1 <= b2 && b2 <= 0xDF)))
                {
                    //EUC_C
                    //EUC_KANA
                    euc += 2;
                    i++;
                }
                else if (i < len - 2)
                {
                    b3 = bytes[i + 2];
                    if (b1 == 0x8F && (0xA1 <= b2 && b2 <= 0xFE) &&
                        (0xA1 <= b3 && b3 <= 0xFE))
                    {
                        //EUC_0212
                        euc += 3;
                        i += 2;
                    }
                }
            }
            for (int i = 0; i < len - 1; i++)
            {
                b1 = bytes[i];
                b2 = bytes[i + 1];
                if ((0xC0 <= b1 && b1 <= 0xDF) && (0x80 <= b2 && b2 <= 0xBF))
                {
                    //UTF8
                    utf8 += 2;
                    i++;
                }
                else if (i < len - 2)
                {
                    b3 = bytes[i + 2];
                    if ((0xE0 <= b1 && b1 <= 0xEF) && (0x80 <= b2 && b2 <= 0xBF) &&
                        (0x80 <= b3 && b3 <= 0xBF))
                    {
                        //UTF8
                        utf8 += 3;
                        i += 2;
                    }
                }
            }
            //M. Takahashi's suggestion
            //utf8 += utf8 / 2;

            System.Diagnostics.Debug.WriteLine(
                string.Format("sjis = {0}, euc = {1}, utf8 = {2}", sjis, euc, utf8));
            if (euc > sjis && euc > utf8)
            {
                //EUC
                return System.Text.Encoding.GetEncoding(51932);
            }
            else if (sjis > euc && sjis > utf8)
            {
                //SJIS
                return System.Text.Encoding.GetEncoding(932);
            }
            else if (utf8 > euc && utf8 > sjis)
            {
                //UTF8
                return System.Text.Encoding.UTF8;
            }

            return null;
        }
        /*
        public static void GetEncoding(byte[] byteData, int nLength, out string htmText)
        {
            string str;
            System.Text.Encoding enc = ModuleReuseClass.GetCode(byteData);

            if(enc != null)
            {
                str = enc.GetString(byteData);
            }
            else
            {
                str = System.Text.Encoding.UTF8.GetString(byteData);
            }

            htmText = str;
        }
        */

        /// <summary>
        /// 指定された文字列が URL かどうかを返します
        /// </summary>
        public static bool IsUrl(string input)
        {
            // NULL
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }
            return Regex.IsMatch(
               input,
               @"^s?https?://[-_.!~*'()a-zA-Z0-9;/?:@&=+$,%#]+$"
            );
        }

        /// <summary>
        /// トーク文字列であるかを判定します。
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsTalk(string input)
        {
            // NULL
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            // 1文字目判定
            if (input.StartsWith("*")
                ||
                input.StartsWith(":")
                ||
                input.StartsWith("#")
                ||
                input.StartsWith(";"))
            {
                return false;
            }

            // すべての文言を退ける。
            return true;
        }

        /// <summary>
        /// ふりがな文字列であるかを判定します。
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsFrigana(string input)
        {
            // NULL
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            // 1文字目判定
            if (input.StartsWith(":")
                ||
                input.StartsWith("#"))
            {
                return false;
            }

            return false;
        }

        /// <summary>
        /// 指定したパスにディレクトリが存在しない場合
        /// すべてのディレクトリとサブディレクトリを作成します
        /// </summary>
        public static DirectoryInfo SafeCreateDirectory(string path)
        {
            try
            {
                if (Directory.Exists(path))
                {
                    return null;
                }
                return Directory.CreateDirectory(path);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 選択パス 
        /// </summary>
        /// <param name="input">パス文字列</param>
        /// <returns></returns>
        public static string SelectPath(string input)
        {
            try
            {
                //FolderBrowserDialogクラスのインスタンスを作成
                FolderBrowserDialog fbd = new FolderBrowserDialog();

                //上部に表示する説明テキストを指定する
                fbd.Description = "フォルダを指定してください。";
                //ルートフォルダを指定する
                //デフォルトでDesktop
                fbd.RootFolder = Environment.SpecialFolder.Desktop;
                //最初に選択するフォルダを指定する
                //RootFolder以下にあるフォルダである必要がある
                fbd.SelectedPath = input;
                //ユーザーが新しいフォルダを作成できるようにする
                //デフォルトでTrue
                fbd.ShowNewFolderButton = true;

                //ダイアログを表示する
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    //選択されたフォルダを表示する
                    return fbd.SelectedPath;
                }
                else
                {
                    return input;
                }
            }
            catch
            {
                return input;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input">計測したい文字列</param>
        /// <returns></returns>
        /// public static double GetVoiceTime(string input)
        /// {
        ///     double dOut = 0d;
        ///     ServiceControl.StartHost(true);
        /// 
        ///     Talker talker = new Talker();
        /// 
        ///     // キャスト設定
        ///     talker.Cast = "すずきつづみ";
        /// 
        ///     // （例）音量設定
        ///     talker.Volume = 100;
        /// 
        ///     dOut = talker.GetTextDuration(input);
        /// 
        ///     // ServiceControl.CloseHost();
        ///     // talker.Dispse
        /// 
        ///     return dOut;
        /// }
        /*
        public static bool RemoveFileDirectory(string inputPath)
        {
            try
            {
                DirectoryInfo target = new DirectoryInfo(inputPath);
                //ファイル消す
                foreach (FileInfo file in target.GetFiles())
                {
                    file.Delete();
                }
                //フォルダも消す
                foreach (DirectoryInfo dir in target.GetDirectories())
                {
                    dir.Delete(true);
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        */

        public static string OutputYomigana(string text)
        {
            IFELanguage ifelang = null;
            string stryomi = "";
            try
            {
                ifelang = Activator.CreateInstance(Type.GetTypeFromProgID("MSIME.Japan")) as IFELanguage;
                int hr = ifelang.Open();
                if (hr != 0)
                {
                    throw Marshal.GetExceptionForHR(hr);
                }
                //string yomigana;
                hr = ifelang.GetPhonetic(text, 1, -1, out string yomigana);
                if (hr != 0)
                {
                    throw Marshal.GetExceptionForHR(hr);
                }
                else
                {
                    stryomi = yomigana;
                }
                //uint mode = 0;
                //ifelang.GetConversionModeCaps(ref mode);
                ifelang.Close();

                return stryomi;
            }
            catch (COMException ex)
            {
                if (ifelang != null) ifelang.Close();
                return stryomi;
            }
        }

        [Guid("00000118-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IOleClientSite
        {
            void SaveObject();
            void GetMoniker(int dwAssign, int dwWhichMoniker, ref object ppmk);
            void GetContainer(ref object ppContainer);
            void ShowObject();
            void OnShowWindow(bool fShow);
            void RequestNewObjectLayout();
        }

        // IFELanguage2 Interface ID
        //[Guid("21164102-C24A-11d1-851A-00C04FCC6B14")]
        [ComImport]
        [Guid("019F7152-E6DB-11d0-83C3-00C04FDDB82E")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IFELanguage
        {
            int Open();
            int Close();
            int GetJMorphResult(uint dwRequest, uint dwCMode, int cwchInput, [MarshalAs(UnmanagedType.LPWStr)] string pwchInput, IntPtr pfCInfo, out object ppResult);
            int GetConversionModeCaps(ref uint pdwCaps);
            int GetPhonetic([MarshalAs(UnmanagedType.BStr)] string @string, int start, int length, [MarshalAs(UnmanagedType.BStr)] out string result);
            int GetConversion([MarshalAs(UnmanagedType.BStr)] string @string, int start, int length, [MarshalAs(UnmanagedType.BStr)] out string result);
        }

        public static string GetNMeCabToFurigana(string strInput)
        {
            string str = string.Empty, strYomi;

            try
            {
                MeCabParam mcp = new MeCabParam();
                MeCabTagger mct = MeCabTagger.Create();
                MeCabNode mcn = mct.ParseToNode(strInput);
                MecabResult mcr = new MecabResult(mcn);

                foreach (MecabResult.MecabResultItem mcri in mcr.nodes)
                {
                    strYomi = String.Empty;
                    if (String.Compare(mcri.読み,"*") == 0)
                    {
                        // 形態素解析を持ってしても読めない場合、OutputYomiganaを使用する。
                        strYomi = ModuleReuseClass.OutputYomigana(mcri.表層形);
                    }
                    else
                    {
                        strYomi = mcri.読み;
                    }
                    str += strYomi;
                }
                //カタカナをひらがなに変換する
                str = Strings.StrConv(str, VbStrConv.Hiragana, 0x411);
                //あいうえおかきくけこｻｼｽｾｿnaninuneno

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return str;
        }


    }

    /// <summary>
    /// /
    /// </summary>
    public class MecabResult
    {
        //結果のリスト
        public List<MecabResultItem> nodes { get; set; }
        //コンストラクタ
        public MecabResult(MeCabNode pnode)
        {
            nodes = new List<MecabResultItem>();
            var itempos = 0;

            try
            {
                while (pnode != null)
                {
                    var addItem = new MecabResultItem();
                    if (pnode.CharType > 0)
                    {
                        addItem.表層形 = pnode.Surface;
                        var tmpStrs = pnode.Feature.Split(',');
                        if (tmpStrs.Length == 9)
                        {
                            addItem.品詞 = tmpStrs[0];
                            addItem.品詞細分類1 = tmpStrs[1];
                            addItem.品詞細分類2 = tmpStrs[2];
                            addItem.品詞細分類3 = tmpStrs[3];
                            addItem.活用形 = tmpStrs[4];
                            addItem.活用型 = tmpStrs[5];
                            addItem.原形 = tmpStrs[6];
                            addItem.読み = tmpStrs[7];
                            addItem.発音 = tmpStrs[8];
                        }
                        else
                        {
                            addItem.読み = "*";
                        }
                        addItem.位置 = itempos;
                        nodes.Add(addItem);
                    }
                    itempos++;
                    pnode = pnode.Next;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// MeCabのよみがな取得
        /// </summary>
        public partial class MecabResultItem
        {
            public string 表層形 { get; set; }
            public string 品詞 { get; set; }
            public string 品詞細分類1 { get; set; }
            public string 品詞細分類2 { get; set; }
            public string 品詞細分類3 { get; set; }
            public string 活用形 { get; set; }
            public string 活用型 { get; set; }
            public string 原形 { get; set; }
            public string 読み { get; set; }
            public string 発音 { get; set; }
            public int 位置 { get; set; }
        }
    }
}
