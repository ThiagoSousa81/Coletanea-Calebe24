using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Diagnostics;

namespace Calebe2024
{
    public partial class frmPrincipal : Form
    {
        frmMusic frm;
        string[] Music = new string[11];
        string[] URL = new string[11];
        public frmPrincipal()
        {
            InitializeComponent();
            CarregarMusicasDoXML(@"C:\Program Files\Missão Calebe 2024\musics.xml");
        }

        private void CarregarMusicasDoXML(string caminhoXML)
        {
            try
            {
                XDocument doc = XDocument.Load(caminhoXML);
                try
                {
                    for (int i = 0; i <= 10; i++)
                    {
                        // Use ElementAt(i) para acessar o elemento específico no índice i
                        XElement elementoMusica = doc.Descendants("musica").ElementAt(i);

                        string titulo = elementoMusica.Element("titulo").Value;
                        string caminho = elementoMusica.Element("caminho").Value;

                        Music[i] = titulo;
                        URL[i] = caminho;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar as músicas: " + ex.Message, "Missão Calebe 2024", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar lista de músicas: " + ex.Message, "Missão Calebe 2024", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void frmPrincipal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == Convert.ToChar(Keys.Escape))
            {
                Application.Exit();
            }
        }

        private void lblMaranata_Click(object sender, EventArgs e)
        {
            frm = new frmMusic(Music[0], URL[0]);
            frm.ShowDialog();

        }

        private void lblEuSouCalebe_Click(object sender, EventArgs e)
        {
            frm = new frmMusic(Music[1], URL[1]);
            frm.ShowDialog();
        }

        private void lblMaravilhas_Click(object sender, EventArgs e)
        {
            frm = new frmMusic(Music[2], URL[2]);
            frm.ShowDialog();
        }

        private void lblEntrega_Click(object sender, EventArgs e)
        {
            frm = new frmMusic(Music[5], URL[5]);
            frm.ShowDialog();
        }

        private void lblOPoderDoAmor_Click(object sender, EventArgs e)
        {
            frm = new frmMusic(Music[3], URL[3]);
            frm.ShowDialog();
        }

        private void lblTomaOMeuCoracao_Click(object sender, EventArgs e)
        {
            frm = new frmMusic(Music[4], URL[4]);
            frm.ShowDialog();
        }

        private void lblMeuFarol_Click(object sender, EventArgs e)
        {
            frm = new frmMusic(Music[6], URL[6]);
            frm.ShowDialog();
        }

        private void lblSomosTeus_Click(object sender, EventArgs e)
        {
            frm = new frmMusic(Music[7], URL[7]);
            frm.ShowDialog();
        }

        private void lblOracao_Click(object sender, EventArgs e)
        {
            frm = new frmMusic(Music[8], URL[8]);
            frm.ShowDialog();
        }

        private void lblSorteio_Click(object sender, EventArgs e)
        {
            frm = new frmMusic(Music[9], URL[9]);
            frm.ShowDialog();
        }

        private void lblApelo_Click(object sender, EventArgs e)
        {
            frm = new frmMusic(Music[10], URL[10]);
            frm.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("https://thiagosousa81.wordpress.com/");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
