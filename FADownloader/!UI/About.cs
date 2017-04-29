using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FADownloader
{
    public partial class aboutForm : Form
    {
        public aboutForm()
        {
            InitializeComponent();
            //this.btnClose.BackColor = Color.Transparent; // not workinig
            //this.btnClose.ForeColor = Color.Transparent; // not working
            // btnClose.ForeColor = Color.White; // uncomment when working
               
        }

        private void aboutForm_Load(object sender, EventArgs e)
        {

        }
        private void pbMukihyena_MouseHover(object sender, EventArgs e)
        {
            pbMukihyena.Cursor = Cursors.Hand;
        }
        private void pbPervdragon_MouseHover(object sender, EventArgs e)
        {
            pbPervdragon.Cursor = Cursors.Hand;
        }
        private void pbMukihyena_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.furaffinity.net/user/mukihyena");
        }
        private void pbPervdragon_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.furaffinity.net/user/pervdragon");
        }
        private void pbVariableMog_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.furaffinity.net/user/variablemog");
        }
        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
