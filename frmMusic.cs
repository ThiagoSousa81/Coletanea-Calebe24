using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using WMPLib;

namespace Calebe2024
{
    public partial class frmMusic : Form
    {
        string Music = "";
        string URL = "";
        public frmMusic(string music, string url)
        {
            InitializeComponent();
            Music = music;
            URL = url;
        }

        private void frmMusic_Load(object sender, EventArgs e)
        {
            this.Text = "Missão Calebe 2024 - " + Music;
            axWindowsMediaPlayer1.URL = URL;
            axWindowsMediaPlayer1.Ctlcontrols.play();
            if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                axWindowsMediaPlayer1.fullScreen = true;
            }

        }

        private void axWindowsMediaPlayer1_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            // Verifique se o estado de reprodução é "wmppsMediaEnded" (música encerrada)
            if ((WMPLib.WMPPlayState)e.newState == WMPLib.WMPPlayState.wmppsMediaEnded)
            {                
                this.Close();
            }
        }

        private void frmMusic_FormClosing(object sender, FormClosingEventArgs e)
        {
            axWindowsMediaPlayer1.fullScreen = false;
            axWindowsMediaPlayer1.Ctlcontrols.stop();
        }
       
        private void axWindowsMediaPlayer1_MouseMoveEvent(object sender, AxWMPLib._WMPOCXEvents_MouseMoveEvent e)
        {
            if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                axWindowsMediaPlayer1.fullScreen = true;
            }
        }

        private void axWindowsMediaPlayer1_KeyDownEvent(object sender, AxWMPLib._WMPOCXEvents_KeyDownEvent e)
        {
            if (Convert.ToChar(e.nKeyCode) == Convert.ToChar(Keys.Escape))
            {
                FormClosingEventArgs a = null;
                frmMusic_FormClosing(sender, a);
            }
        }

        private void frmMusic_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == Convert.ToChar(Keys.Escape))
            {
                this.Close();
            }
        }
    }
}
