using System;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MovieHachiTool.Properties;

namespace MovieHachiTool
{
    public partial class MovieHachiToolForm : Form
    {

        public MovieHachiToolForm()
        {
            InitializeComponent();

            var fontCollection = new System.Drawing.Text.InstalledFontCollection();
            var fontFamillies = fontCollection.Families;
            foreach (FontFamily ff in fontFamillies)
            {
                cbFonts.Items.Add(ff.Name);
            }
            if (!string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["defaultFont"]))
            {
                cbFonts.SelectedItem = ConfigurationManager.AppSettings["defaultFont"];
            }
            else
            {
                cbFonts.SelectedItem = "MS UI Gothic";
            }
        }

        private string ConvertToString()
        {
            return headerTextBox.Text + "\r\n"
                + sourceTextBox.Text + "\r\n"
                + footerTextBox.Text + "\r\n";
        }

        private string MakeOutputPictureName(int nData)
        {
            return string.Format("victure{0:00000}_{0}.png", nData);
        }

       private string MakeOutputHtmleName(int nData)
        {
            return string.Format("victure{0:00000}_{0}.htm", nData);
        }

        private string MakeUrlToString(string sourceStr, int nData, out string strInyou)
        {
            var destString = "";
            strInyou = "";
            try
            {
                var uri = new Uri(sourceStr);
                string strPicture, strHtml, strPicPath, strHtmlPath, strTitle = "";
                string strPictrueExp = PictureExportPathTextBox.Text;
                // DateTime dt = new DateTime()
                // TimeSpan ts = new TimeSpan()

                // textBox2.Text += sourceStr + ":" + sourceStr + "\r\n";
                strInyou = sourceStr + "\r\n";

                // テキストアウトプット
                strPicture = MakeOutputPictureName(nData);
                strHtml = MakeOutputHtmleName(nData);
                destString += "# " + sourceStr + "\r\n";
                strPicPath = Path.Combine(strPictrueExp, strPicture);
                destString += "# " + strPicPath + "\r\n";
                strHtmlPath = Path.Combine(strPictrueExp, strHtml);
                destString += "# " + strHtmlPath + "\r\n";

                // HTML取得
                var htmlFilePath = ModuleReuseClass.getURLToFile(sourceStr, strHtmlPath);

                //タイトル取得
                using(StreamReader sr = new StreamReader(htmlFilePath))
                {
                    var line = "";
                    while((line = sr.ReadLine()) != null)
                    {
                        if(line.ToLower().Contains("<title>"))
                        {
                            strTitle += line;
                        }
                        else if (!strTitle.Equals(""))
                        {
                            strTitle += line;
                        }
                        if(line.ToLower().Contains("</title>"))
                        {
                            strTitle += line;
                            break;
                        }
                    }
                    if (!string.IsNullOrEmpty(strTitle))
                    {
                        strTitle = strTitle.Substring(strTitle.ToLower().IndexOf("<title>") + 7);
                        strTitle = strTitle.Substring(0, strTitle.ToLower().IndexOf("</title>"));

                        if(strTitle.Contains(" - "))
                        {
                            strTitle = strTitle.Substring(0, strTitle.IndexOf(" - "));
                        }
                        if (strTitle.Contains("|"))
                        {
                            strTitle = strTitle.Substring(0, strTitle.IndexOf("|"));
                        }
                    }
                }

                var bmp = ModuleReuseClass.getBitmapFromTitle(strTitle, sourceStr, cbFonts.Text);
                destString += "# " + strTitle + "\r\n";
                // bmp = getBitmapFromUrl(uri.AbsoluteUri);
                bmp.Save(strPicPath, System.Drawing.Imaging.ImageFormat.Png);
                bmp.Dispose();
                destString += "*fgi=" + strPicPath + ",アニメタイプ:Null,透明度:20" + "\r\n";

                // 待ち時間追加(";"一つで0.5秒)
                for (int i = 0; i < 2; i++)
                {
                    destString += ";";
                }

                destString += "\r\n";     //画像
                return destString;
            }
            catch
            {
                return string.Empty;
            }

        }

        private string MakeTalkToString(string sourceStr, bool bNextFurigana)
        {
            // 会話か否か
            string strDest;

            try
            {
                // prevTime = ModuleReuseClass.GetVoiceTime(sourceStr);
                strDest = sourceStr + "\r\n";
                // よみがなの追加
                if(!bNextFurigana)
                {
                    var strYomigana = ModuleReuseClass.OutputYomigana(sourceStr);
                    if (!string.IsNullOrEmpty(strYomigana))
                    {
                        strDest += ":" + strYomigana + "\r\n";
                    }
                    else
                    {
                        strYomigana = ModuleReuseClass.GetNMeCabToFurigana(sourceStr);
                        if (!string.IsNullOrEmpty(strYomigana))
                        {
                            strDest += ":" + strYomigana + "\r\n";
                        }
                    }
                }
            }
            catch
            {
                strDest = "";
            }
            return strDest;
        }

        /// <summary>
        /// [->]ボタンクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConvertButton_Click(object sender, EventArgs e)
        {
            //処理中はカーソルを待ち状態にする
            var currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            //inyouTextBox.Text = "";
            //double time = 0;
            //double prevTime = 0;
            int nData = 1, nCount = 0;

            var lines = ConvertToString().Split(new string[] { "\r\n" }, StringSplitOptions.None);
            // 指定フォルダの一括ファイル＆フォルダ削除
            // ModuleReuseClass. RemoveFileDirectory(PictureExportPathTextBox.Text);

            try
            {
                inyouTextBox.Text = "＜引用＞\r\n";
                destinationTextBox.Text = "";

                foreach (string strSources in lines)
                {
                    // URLか否か
                    if (ModuleReuseClass.IsUrl(strSources))
                    {
                        // ワイプテキスト挿入する？
                        if(Settings.Default.WipeYesNo == true)
                        {
                            destinationTextBox.Text += Settings.Default.WipeText;
                        }
                        // Html挿入
                        destinationTextBox.Text += MakeUrlToString(strSources, nData, out string strInyou) + "\r\n";
                        inyouTextBox.Text += strInyou;
                        nData++;
                    }
                    else if (ModuleReuseClass.IsTalk(strSources))
                    {
                        // 会話を変換
                        //time += prevTime;
                        // URLを変換
                        var strFuri = (lines.Length > nCount + 1) ? lines[nCount + 1] : string.Empty;
                        var bNextFurigana = ModuleReuseClass.IsFrigana(strFuri);
                        destinationTextBox.Text += MakeTalkToString(strSources, bNextFurigana);
                    }
                    else
                    {
                        destinationTextBox.Text += strSources + "\r\n";
                    }
                    nCount++;

                }
                MessageBox.Show("変換終了しました。", "変換");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //最後にカーソル状態を戻す
                Cursor.Current = currentCursor;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                PictureExportPathTextBox.Text = ModuleReuseClass.SelectPath(PictureExportPathTextBox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                //アプリケーションの設定を保存する
                Settings.Default.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MovieHachiToolForm_Shown(object sender, EventArgs e)
        {
            try
            {
                var strPath = Settings.Default.PictureHtmlExportPath;
                var thisPath = System.Reflection.Assembly.GetEntryAssembly().Location;
                var strP = Path.Combine(Path.GetDirectoryName(thisPath), "outpic");

                if (strP.Equals(strPath) == false)
                {
                    // 設定保存
                    Settings.Default.PictureHtmlExportPath = strP;
                    strPath = Settings.Default.PictureHtmlExportPath;
                    // ディレクトリパスを作成する。
                    ModuleReuseClass.SafeCreateDirectory(strP);
                    ModuleReuseClass.SafeCreateDirectory(Path.Combine(strPath, "output"));
                    Settings.Default.Save();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
