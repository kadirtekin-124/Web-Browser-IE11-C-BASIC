using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Text.RegularExpressions;
using System.IO;
using System.Diagnostics;
using System.Net;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {

        string baslangicSayfasi = "https://www.google.com/";
        string baslangicSayfasi2 = "https://yandex.com.tr/";
        string baslangicSayfasi3 = "https://www.search.ask.com/";
        string baslangicSayfasi4 = "https://www.bing.com/?toWww=1&redig=49C6A2B1797146EC9CADB3BBBC42EACC";
        string baslangicSayfasi5 = "https://tr.search.yahoo.com/";


        ProgressBar pb;







        public Form1()
        {









            InitializeComponent();







        }







       
        Gecmis g = new Gecmis();
        private Control tab;














        //IE 11
        public class WebBrowserHelper
        {
            public static int GetEmbVersion()
            {
                int ieVer = GetBrowserVersion();

                if (ieVer > 9)
                    return ieVer * 1000 + 1;

                if (ieVer > 7)
                    return ieVer * 1111;

                return 7000;
            }
            public static void FixBrowserVersion()
            {
                string appName = System.IO.Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetExecutingAssembly().Location);
                FixBrowserVersion(appName);
            }
            public static void FixBrowserVersion(string appName)
            {
                FixBrowserVersion(appName, GetEmbVersion());
            }
            // FixBrowserVersion("<YourAppName>", 9000);
            public static void FixBrowserVersion(string appName, int ieVer)
            {
                FixBrowserVersion_Internal("HKEY_LOCAL_MACHINE", appName + ".exe", ieVer);
                FixBrowserVersion_Internal("HKEY_CURRENT_USER", appName + ".exe", ieVer);
                FixBrowserVersion_Internal("HKEY_LOCAL_MACHINE", appName + ".vshost.exe", ieVer);
                FixBrowserVersion_Internal("HKEY_CURRENT_USER", appName + ".vshost.exe", ieVer);

                WebBrowserHelper.FixBrowserVersion();
                WebBrowserHelper.FixBrowserVersion("SomeAppName");
                WebBrowserHelper.FixBrowserVersion("SomeAppName", ieVer);
            }
            private static void FixBrowserVersion_Internal(string root, string appName, int ieVer)
            {
                try
                {
                    //64 bit makina 
                    if (Environment.Is64BitOperatingSystem)
                        Microsoft.Win32.Registry.SetValue(root + @"\Software\Wow6432Node\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", appName, ieVer);
                    else  // 32 bit makina 
                        Microsoft.Win32.Registry.SetValue(root + @"\Software\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", appName, ieVer);
                }
                catch (Exception)
                {
                    // bazı yapılandırmalar erişim hakları istisnalarına çarpacak
                    // bu yüzden hem LOCAL_MACHINE hem de CURRENT_USER ile deniyoruz.
                }
            }
            public static int GetBrowserVersion()
            {
                // string strKeyPath = @"HKLM\SOFTWARE\Microsoft\Internet Explorer";
                string strKeyPath = @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Internet Explorer";
                string[] ls = new string[] { "svcVersion", "svcUpdateVersion", "Version", "W2kVersion" };

                int maxVer = 0;
                for (int i = 0; i < ls.Length; ++i)
                {
                    object objVal = Microsoft.Win32.Registry.GetValue(strKeyPath, ls[i], "0");
                    string strVal = System.Convert.ToString(objVal);
                    if (strVal != null)
                    {
                        int iPos = strVal.IndexOf('.');
                        if (iPos > 0)
                            strVal = strVal.Substring(0, iPos);

                        int res = 0;
                        if (int.TryParse(strVal, out res))
                            maxVer = Math.Max(maxVer, res);
                    }
                }
                return maxVer;
            }
        }




        //KEY DOWN
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonGit.PerformClick();
            }
        }


        //LOAD FORM1
        private void Form1_Load(object sender, EventArgs e)
        {
            

            cburl2.Visible = false;
            buttonGit2.Visible = false;

            //ARAMA MOTORLARI (VARSAYILAN YAPILABILENLER)

            yandex_git.Visible = false;
            ask_git.Visible = false;
            bing_git.Visible = false;
            yahoo_git.Visible = false;

            //ARAMA MOTORLARI (VARSAYILAN YAPILABILENLER)


            YeniSekmeOlustur();


        }


        //Sekme Olustur (INDEX)
        private void YeniSekmeOlustur()
        {

            TabPage tp = new TabPage();
            tp.Text = "Yeni Sekme";
            tcSekmeler.TabPages.Add(tp);
            tcSekmeler.SelectTab(tp); //go to tab


            WebBrowser wb = new WebBrowser();
            wb.Dock = DockStyle.Fill;
            wb.Navigate(baslangicSayfasi);
            wb.Parent = tab;

            tp.Controls.Add(wb);

            int count = tcSekmeler.TabPages.Count;
            tcSekmeler.SelectedIndex = count = -1;





        }

        //Sekme Olustur (YANDEX)
        private void YeniSekmeOlustur2()
        {

            TabPage tp = new TabPage();
            tp.Text = "Yeni Sekme";
            tcSekmeler.TabPages.Add(tp);
            tcSekmeler.SelectTab(tp); //go to tab


            WebBrowser wb = new WebBrowser();
            wb.Dock = DockStyle.Fill;
            wb.Navigate(baslangicSayfasi2);
            wb.Parent = tab;

            tp.Controls.Add(wb);

            int count = tcSekmeler.TabPages.Count;
            tcSekmeler.SelectedIndex = count = -1;





        }

        //Sekme Olustur (ASK)
        private void YeniSekmeOlustur3()
        {

            TabPage tp = new TabPage();
            tp.Text = "Yeni Sekme";
            tcSekmeler.TabPages.Add(tp);
            tcSekmeler.SelectTab(tp); //go to tab


            WebBrowser wb = new WebBrowser();
            wb.Dock = DockStyle.Fill;
            wb.Navigate(baslangicSayfasi3);
            wb.Parent = tab;

            tp.Controls.Add(wb);

            int count = tcSekmeler.TabPages.Count;
            tcSekmeler.SelectedIndex = count = -1;





        }

        //Sekme Olustur (BING)
        private void YeniSekmeOlustur4()
        {

            TabPage tp = new TabPage();
            tp.Text = "Yeni Sekme";
            tcSekmeler.TabPages.Add(tp);
            tcSekmeler.SelectTab(tp); //go to tab


            WebBrowser wb = new WebBrowser();
            wb.Dock = DockStyle.Fill;
            wb.Navigate(baslangicSayfasi4);
            wb.Parent = tab;

            tp.Controls.Add(wb);

            int count = tcSekmeler.TabPages.Count;
            tcSekmeler.SelectedIndex = count = -1;





        }

        //Sekme Olustur (YAHOO)
        private void YeniSekmeOlustur5()
        {

            TabPage tp = new TabPage();
            tp.Text = "Yeni Sekme";
            tcSekmeler.TabPages.Add(tp);
            tcSekmeler.SelectTab(tp); //go to tab


            WebBrowser wb = new WebBrowser();
            wb.Dock = DockStyle.Fill;
            wb.Navigate(baslangicSayfasi5);
            wb.Parent = tab;

            tp.Controls.Add(wb);

            int count = tcSekmeler.TabPages.Count;
            tcSekmeler.SelectedIndex = count = -1;





        }







        private void favorilerToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Favoriler fav = new Favoriler();



            fav.urlTxt.Text = WebBrowser1.Url.ToString();
            fav.StartPosition = FormStartPosition.CenterParent;
            fav.ShowDialog(this);

        }

        private void Yonlendir(string url)
        {
            TabPage tp = tcSekmeler.SelectedTab;

            foreach (Control item in tp.Controls)
            {
                if (item is WebBrowser)
                {
                    WebBrowser wb = (WebBrowser)item;
                    wb.Navigate(url);
                    gecmisyukle();
                }
            }
        }

        private void Yonlendir2(string url)
        {
            TabPage tp = tcSekmeler.SelectedTab;

            foreach (Control item in tp.Controls)
            {
                if (item is WebBrowser)
                {
                    WebBrowser wb = (WebBrowser)item;
                    wb.Navigate(url);

                }
            }
        }



        private void button4_Click(object sender, EventArgs e)
        {


            Yonlendir(cburl.Text);
            WebBrowser1.Refresh();
            gecmisyukle();


        }






        private void buttonGeri_Click(object sender, EventArgs e)
        {

            TabPage tp = tcSekmeler.SelectedTab;

            foreach (Control item in tp.Controls)
            {
                if (item is WebBrowser)
                {
                    WebBrowser wb = (WebBrowser)item;
                    wb.GoBack();


                }
            }
        }



        private void buttonİleri_Click(object sender, EventArgs e)
        {

            TabPage tp = tcSekmeler.SelectedTab;

            foreach (Control item in tp.Controls)
            {
                if (item is WebBrowser)
                {
                    WebBrowser wb = (WebBrowser)item;
                    wb.GoForward();


                }
            }
        }


        private void buttonYenile_Click(object sender, EventArgs e)
        {
            TabPage tp = tcSekmeler.SelectedTab;

            foreach (Control item in tp.Controls)
            {
                if (item is WebBrowser)
                {
                    WebBrowser wb = (WebBrowser)item;
                    wb.Refresh();
                    tcSekmeler.Refresh();
                    gecmisyukle();

                }
            }
        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {

            tcSekmeler.TabPages.RemoveAt(tcSekmeler.SelectedIndex);
        }








        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {


            string curDir = Directory.GetCurrentDirectory();


        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            YeniSekmeOlustur();



        }







        private void panel1_Paint(object sender, PaintEventArgs e)
        {


        }

        private void cburl_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.WebBrowser1.Navigate("http://www.google.com/search?q=" + cburl.Text);
            urlyukle();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Yonlendir("https://www.webartoffical.site/");
        }




        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Yonlendir("https://www.google.com/");

        }















        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void tcFlashdur_Click(object sender, EventArgs e)
        {
            axShockwaveFlash1.Stop();
        }

        private void Flash_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void flashEtkinlestirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            axShockwaveFlash1.LoadMovie(0, "D:/utku.swf");  // Bu kısma animasyonun yolu yazılacak
            axShockwaveFlash1.Loop = false;                 // Bu satır animasyonun sadece bir defa çalışması için yazıldı
            axShockwaveFlash1.Play();
        }

        private void ayarlarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void flashKapatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            axShockwaveFlash1.Stop();
        }

        private void sayfaBaşlığıToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

















        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tcBrowser_ControlRemoved(object sender, ControlEventArgs e)
        {

        }

        private void scriptyukle()
        {

            TabPage tp = tcSekmeler.SelectedTab;

            foreach (Control item in tp.Controls)
            {
                if (item is WebBrowser)
                {
                    WebBrowser wb = (WebBrowser)item;
                    wb.ScriptErrorsSuppressed = true;

                }
            }
        }

        private void scriptyukleme()
        {

            TabPage tp = tcSekmeler.SelectedTab;

            foreach (Control item in tp.Controls)
            {
                if (item is WebBrowser)
                {
                    WebBrowser wb = (WebBrowser)item;
                    wb.ScriptErrorsSuppressed = false;

                }
            }
        }



        private void urlyukle()
        {
            TabPage tp = tcSekmeler.SelectedTab;

            foreach (Control item in tp.Controls)
            {
                if (item is WebBrowser)
                {
                    WebBrowser wb = (WebBrowser)item;
                    cburl.Items.Add(wb.Url.ToString());
                }
            }
        }

        private void gizlimod()
        {
            TabPage tp = tcSekmeler.SelectedTab;

            foreach (Control item in tp.Controls)
            {
                if (item is WebBrowser)
                {
                    WebBrowser wb = (WebBrowser)item;
                    tcSekmeler.SelectedTab.Text = "Gizli Mod";
                    wb.Document.InvokeScript("loaded");
                }


            }
        }





        private void tcBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

            TabPage tp = tcSekmeler.SelectedTab;

            foreach (Control item in tp.Controls)
            {
                if (item is WebBrowser)
                {
                    WebBrowser wb = (WebBrowser)item;
                    tcSekmeler.SelectedTab.Text = wb.DocumentTitle;
                    wb.Document.InvokeScript("loaded");

                    HtmlElement htmlButton = wb.Document.GetElementById("buton");




















                    string zaman = DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year;
                    string zaman2 = DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;

                    FileStream f = new FileStream("Gecmis.txt", FileMode.Append);
                    StreamWriter yaz = new StreamWriter(f);
                    yaz.WriteLine(zaman + "/" + zaman2 + "/" + " " + cburl.Text);
                    yaz.Close();
                    gecmisyukle();








                }
            }
        }







        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }





        private void yazdırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WebBrowser1.ShowPrintDialog();
        }










        private void sayfaOzellikleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage tp = tcSekmeler.SelectedTab;

            foreach (Control item in tp.Controls)
            {
                if (item is WebBrowser)
                {
                    WebBrowser wb = (WebBrowser)item;

                    wb.ShowPropertiesDialog();


                }
            }



        }



        private void dosyaAcToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

            TabPage tp = tcSekmeler.SelectedTab;

            foreach (Control item in tp.Controls)
            {
                if (item is WebBrowser)
                {
                    WebBrowser wb = (WebBrowser)item;

                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    openFileDialog.FileName = "";
                    openFileDialog.Filter = "Webpages|*.html|All Files|*.*";
                    openFileDialog.Title = "Open Webpage";
                    if (openFileDialog.ShowDialog(this) == DialogResult.OK)
                    {
                        wb.DocumentText = System.IO.File.ReadAllText(openFileDialog.FileName);
                    }



                }



            }
        }




        private void kaynakToolStripMenuItem_Click(object sender, EventArgs e)
        {


            TabPage tp = tcSekmeler.SelectedTab;

            foreach (Control item in tp.Controls)
            {
                if (item is WebBrowser)
                {
                    WebBrowser wb = (WebBrowser)item;


                    Form sourceForm = new Form();
                    TextBox sourceCode = new TextBox();
                    sourceCode.Dock = DockStyle.Fill;
                    sourceCode.Multiline = true;
                    sourceCode.ScrollBars = ScrollBars.Both;
                    sourceForm.Width = 450;
                    sourceForm.Height = 350;
                    sourceForm.StartPosition = FormStartPosition.CenterParent;
                    sourceForm.ShowIcon = false;
                    sourceForm.ShowInTaskbar = true;
                    sourceForm.Text = "Kaynak Kodu " + wb.Url;
                    sourceCode.Text = wb.DocumentText;
                    sourceForm.Controls.Add(sourceCode);
                    sourceForm.Show(this);


                }
            }
        }







        private void tarayıcıGecmisiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gecmisyukle();

            g.ShowDialog();





        }


        private void tarayıcıGecmisiSilToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }






        private void gecmisyukle()
        {





            g.listBox2.Items.Clear();
            StreamReader dosya = new StreamReader("Gecmis.txt");
            while (!dosya.EndOfStream)
            {


                g.listBox2.Items.Add(dosya.ReadLine());


            }
            dosya.Close();





        }

        private void pictureBox5_Click_1(object sender, EventArgs e)
        {
            WebBrowser1.ShowPropertiesDialog();
        }

        private void pictureBox5_Click_2(object sender, EventArgs e)
        {
            Yonlendir("https://ru-clip.com/");
        }

        private void WebBrowser1_NewWindow(object sender, CancelEventArgs e)
        {

        }



        private void scriptHatalariKapatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult secenek = MessageBox.Show("Script Hatalarını Kapatmak istiyormusunuz?", "Web Art Browser", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (secenek == DialogResult.Yes)
            {
                scriptyukle();
            }
            else if (secenek == DialogResult.No)
            {
                scriptyukleme();
            }


        }

        private void dosyaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }



        private void yazdırToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TabPage tp = tcSekmeler.SelectedTab;

            foreach (Control item in tp.Controls)
            {
                if (item is WebBrowser)
                {
                    WebBrowser wb = (WebBrowser)item;

                    wb.ShowPrintDialog();


                }
            }
        }

        private void mmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scriptyukle();
        }





        private void hatalariAcToolStripMenuItem_Click(object sender, EventArgs e)
        {

            TabPage tp = tcSekmeler.SelectedTab;

            foreach (Control item in tp.Controls)
            {
                if (item is WebBrowser)
                {
                    WebBrowser wb = (WebBrowser)item;
                    wb.ScriptErrorsSuppressed = false;

                }
            }

        }

        private void tarayıcıGecmisiSilToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip3_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void favorilerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Favoriler fav = new Favoriler();



            fav.urlTxt.Text = WebBrowser1.Url.ToString();
            fav.StartPosition = FormStartPosition.CenterParent;
            fav.ShowDialog(this);
        }

        private void gecmisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gecmisyukle();
            g.ShowDialog();
        }

        private void tarayıcıGecmisiniSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StreamWriter dosya = new StreamWriter("Gecmis.txt");
            dosya.WriteLine("");
            dosya.Close();
            gecmisyukle();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            TabPage tp = tcSekmeler.SelectedTab;

            foreach (Control item in tp.Controls)
            {
                if (item is WebBrowser)
                {
                    WebBrowser wb = (WebBrowser)item;
                    wb.GoBack();


                }
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            TabPage tp = tcSekmeler.SelectedTab;

            foreach (Control item in tp.Controls)
            {
                if (item is WebBrowser)
                {
                    WebBrowser wb = (WebBrowser)item;
                    wb.GoForward();


                }
            }
        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            TabPage tp = tcSekmeler.SelectedTab;

            foreach (Control item in tp.Controls)
            {
                if (item is WebBrowser)
                {
                    WebBrowser wb = (WebBrowser)item;
                    wb.Refresh();
                    tcSekmeler.Refresh();
                    gecmisyukle();

                }
            }
        }

        private void pictureBox5_Click_3(object sender, EventArgs e)
        {
            Yonlendir(cburl.Text);
            WebBrowser1.Refresh();
            gecmisyukle();
        }

        private void tarayıcıSürümüToolStripMenuItem_Click(object sender, EventArgs e)
        {


            DialogResult secenek = MessageBox.Show("Tarayıcınız Günceldir. Sürümü öğrenmek istiyormusunuz?", "Web Art Browser", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (secenek == DialogResult.Yes)
            {
                MessageBox.Show("Mevcut Sürüm: 2.6", "Web Art Browser");
            }
            else if (secenek == DialogResult.No)
            {
                //Çıkış işlemi
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            TabPage tp = tcSekmeler.SelectedTab;

            foreach (Control item in tp.Controls)
            {
                if (item is WebBrowser)
                {
                    WebBrowser wb = (WebBrowser)item;

                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    openFileDialog.FileName = "";
                    openFileDialog.Filter = "HTML Dosyaları|*.html|PHP Dosyaları|*.php|TXT Dosyaları|*.txt|PDF Dosyaları|*.pdf|Tum Dosyalar|*.*";
                    openFileDialog.Title = "Open Webpage";
                    if (openFileDialog.ShowDialog(this) == DialogResult.OK)
                    {
                        wb.DocumentText = System.IO.File.ReadAllText(openFileDialog.FileName);
                    }



                }



            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            TabPage tp = tcSekmeler.SelectedTab;

            foreach (Control item in tp.Controls)
            {
                if (item is WebBrowser)
                {
                    WebBrowser wb = (WebBrowser)item;

                    wb.ShowPropertiesDialog();
                }

            }







        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            TabPage tp = tcSekmeler.SelectedTab;

            foreach (Control item in tp.Controls)
            {
                if (item is WebBrowser)
                {
                    WebBrowser wb = (WebBrowser)item;

                    wb.ShowPrintDialog();
                }
            }
        }









        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            TabPage tp = tcSekmeler.SelectedTab;

            foreach (Control item in tp.Controls)
            {
                if (item is WebBrowser)
                {
                    WebBrowser wb = (WebBrowser)item;


                    Form sourceForm = new Form();
                    TextBox sourceCode = new TextBox();
                    sourceCode.Dock = DockStyle.Fill;
                    sourceCode.Multiline = true;
                    sourceCode.ScrollBars = ScrollBars.Both;
                    sourceForm.Width = 450;
                    sourceForm.Height = 350;
                    sourceForm.StartPosition = FormStartPosition.CenterParent;
                    sourceForm.ShowIcon = false;
                    sourceForm.ShowInTaskbar = true;
                    sourceForm.Text = "Kaynak Kodu " + wb.Url;
                    sourceCode.Text = wb.DocumentText;
                    sourceForm.Controls.Add(sourceCode);
                    sourceForm.Show(this);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            this.WebBrowser1.Navigate("http://www.google.com/search?q=" + cburl.Text);
        }

        private void gizliModToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gizlimod();


            cburl2.Visible = true;

            if (cburl.Visible)
                cburl.Visible = false;

            buttonGit2.Visible = true;

            if (buttonGit.Visible)
                buttonGit.Visible = false;












            StreamWriter dosya = new StreamWriter("Gecmis.txt");
            dosya.WriteLine("");
            dosya.Close();
            gecmisyukle();
        }

        private void gizliModuKapatToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cburl2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void kapatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cburl.Visible = true;
            cburl2.Visible = false;

            buttonGit.Visible = true;
            buttonGit2.Visible = false;
        }

        private void buttonGit2_Click(object sender, EventArgs e)
        {
            Yonlendir2(cburl2.Text);
            WebBrowser1.Refresh();
        }

        private void yandexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Yonlendir("https://yandex.com.tr/");
            yandex_git.Visible = true;

            if (pictureBox2.Visible)
                pictureBox2.Visible = false;







        }

        private void yandex_git_Click(object sender, EventArgs e)
        {
            YeniSekmeOlustur2();
        }

        private void pictureBox5_Click_4(object sender, EventArgs e)
        {
            YeniSekmeOlustur3();
        }

        private void webArtSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Yonlendir("https://www.search.ask.com/");
            ask_git.Visible = true;

            if (yandex_git.Visible)
                yandex_git.Visible = false;

            if (bing_git.Visible)
                bing_git.Visible = false;

            if (yahoo_git.Visible)
                yahoo_git.Visible = false;


            if (pictureBox2.Visible)
                pictureBox2.Visible = false;
        }

        private void bing_git_Click(object sender, EventArgs e)
        {
            YeniSekmeOlustur4();
        }

        private void bingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Yonlendir("https://www.bing.com/?toWww=1&redig=2DFD583AF6A14E9DAE75A7A0BDA782DA");
            bing_git.Visible = true;

            if (yandex_git.Visible)
                yandex_git.Visible = false;

            if (ask_git.Visible)
                ask_git.Visible = false;

            if (yahoo_git.Visible)
                yahoo_git.Visible = false;

            if (pictureBox2.Visible)
                pictureBox2.Visible = false;
        }

        private void yahooToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Yonlendir("https://tr.search.yahoo.com/");
            yahoo_git.Visible = true;

            if (yandex_git.Visible)
                yandex_git.Visible = false;

            if (ask_git.Visible)
                ask_git.Visible = false;

            if (bing_git.Visible)
                bing_git.Visible = false;

            if (pictureBox2.Visible)
                pictureBox2.Visible = false;
        }

        private void yahoo_git_Click(object sender, EventArgs e)
        {
            YeniSekmeOlustur5();
        }

        private void varsayılanTarayıcıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Yonlendir("https://www.google.com/");
            pictureBox2.Visible = true;

            if (yandex_git.Visible)
                yandex_git.Visible = false;

            if (ask_git.Visible)
                ask_git.Visible = false;

            if (bing_git.Visible)
                bing_git.Visible = false;

            if (yahoo_git.Visible)
                yahoo_git.Visible = false;


        }

        private void pictureBox5_Click_5(object sender, EventArgs e)
        {
            string filename2 = "Kullanım Kılavuzu.pdf";
            System.Diagnostics.Process.Start(filename2);
        }


        private void pDFDosyalarıAçToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
                }

        private void tarayıcıyıSıırlaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("Setup_browser.exe");
        }
            }
        }
    
