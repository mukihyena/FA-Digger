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
    public partial class CookiesTutorial : Form
    {

        ///////////////
        // VARIABLES //
        ///////////////

        #region
        public int pageNum = 0;
        public string browserType = null;
        #endregion

        ////////////
        // SYSTEM //
        ////////////

        #region
        /// <summary>
        /// Initialize
        /// </summary>
        public CookiesTutorial()
        {
            InitializeComponent();
        }

        private void CookiesTutorial_Load(object sender, EventArgs e)
        {
            ct_Start();
        }

        #endregion

        //////////////////
        // INTERACTIONS //
        //////////////////

        #region
        /// <summary>
        /// Click Chrome Icon
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pb_CT_CR_Click(object sender, EventArgs e)
        {
            browserType = "Chrome";
            pageNum = 1;
            UpdatePage();
        }

        /// <summary>
        /// Click FireFox Icon
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pb_CT_FF_Click(object sender, EventArgs e)
        {
            browserType = "FireFox";
            pageNum = 1;
            UpdatePage();
        }

        /// <summary>
        /// Click Cookies Tutorial Next Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_CT_Next_Click(object sender, EventArgs e)
        {
            pageNum++;
            UpdatePage();
        }

        /// <summary>
        /// Click Cookies Tutorial Previous Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_CT_Prev_Click(object sender, EventArgs e)
        {
            pageNum--;
            UpdatePage();
        }

        /// <summary>
        /// Click Cookies Tutorial Close Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_CT_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdatePage()
        {
            if (browserType == "FireFox")
            {
                switch (pageNum)
                {
                    case 0:
                        ct_Start();
                        break;
                    case 1:
                        ff_ct_1();
                        break;
                    case 2:
                        ff_ct_2();
                        break;
                    case 3:
                        ff_ct_3();
                        break;
                    case 4:
                        ff_ct_4();
                        break;
                    case 5:
                        ff_ct_5();
                        break;
                    case 6:
                        ff_ct_6();
                        break;
                    case 7:
                        ff_ct_7();
                        break;
                    case 8:
                        ff_ct_8();
                        break;
                    case 9:
                        pageNum = 8;
                        break;
                    default:
                        break;
                }
            }
            if (browserType == "Chrome")
            {
                switch (pageNum)
                {
                    case 0:
                        ct_Start();
                        break;
                    case 1:
                        cr_ct_1();
                        break;
                    case 2:
                        cr_ct_2();
                        break;
                    case 3:
                        cr_ct_3();
                        break;
                    case 4:
                        cr_ct_4();
                        break;
                    case 5:
                        cr_ct_5();
                        break;
                    case 6:
                        cr_ct_6();
                        break;
                    case 7:
                        cr_ct_7();
                        break;
                    case 8:
                        cr_ct_8();
                        break;
                    case 9:
                        pageNum = 8;
                        break;
                    default:
                        break;
                }
            }

            ctUI();
        }
        #endregion

        ////////////
        // SET UI //
        ////////////

        #region
        /// <summary>
        /// Set UI for Tutorial pages
        /// </summary>
        private void ctUI()
        {
            if (pageNum >= 1)
            {
                pb_Tut.Visible = true;
                btn_CT_Next.Visible = true;
                btn_CT_Prev.Visible = true;
                lbl_CT.Visible = true;

                lbl_ct_title.Visible = false;
                pb_CT_CR.Visible = false;
                pb_CT_FF.Visible = false;
                lbl_ct_pagenum.Visible = true;
                lbl_ct_pagenum.Text = (browserType + " Cookies Tutorial " + pageNum + "/8");
            }
            else if (pageNum == 0)
            {
                pb_Tut.Visible = false;
                btn_CT_Next.Visible = false;
                btn_CT_Prev.Visible = false;
                lbl_CT.Visible = false;

                lbl_ct_title.Visible = true;
                pb_CT_CR.Visible = true;
                pb_CT_FF.Visible = true;
                lbl_ct_pagenum.Visible = false;
            }
            else
            {
                pageNum = 0;
            }
        }
        #endregion

        ///////////
        // PAGES //
        ///////////

        #region
        ////////////////
        // START PAGE //
        ////////////////

        /// <summary>
        /// Start Page
        /// </summary>
        public void ct_Start()
        {
            browserType = null;
            pageNum = 0;
            pb_CT_CR.Image = Properties.Resources.chrome;
            pb_CT_FF.Image = Properties.Resources.firefox;
            ctUI();
            //lbl_ct_title.Text = Strings.ct_Start;
        }

        //////////////////////
        // FIREFOX TUTORIAL //
        //////////////////////

        #region
        /// <summary>
        /// FireFox tutorial page 1
        /// </summary>
        public void ff_ct_1()
        {
            pb_Tut.Image = Properties.Resources.ff_ct_1;
            lbl_CT.Text = Strings.ct_1;
        }

        /// <summary>
        /// FireFox tutorial page 2
        /// </summary>
        public void ff_ct_2()
        {
            pb_Tut.Image = Properties.Resources.ff_ct_2;
            lbl_CT.Text = Strings.ct_2_FF;
        }

        /// <summary>
        /// FireFox tutorial page 3
        /// </summary>
        public void ff_ct_3()
        {
            pb_Tut.Image = Properties.Resources.ff_ct_3;
            lbl_CT.Text = Strings.ct_3;
        }

        /// <summary>
        /// FireFox tutorial page 4
        /// </summary>
        public void ff_ct_4()
        {
            pb_Tut.Image = Properties.Resources.ff_ct_4;
            lbl_CT.Text = Strings.ct_4;
        }

        /// <summary>
        /// FireFox tutorial page 5
        /// </summary>
        public void ff_ct_5()
        {
            pb_Tut.Image = Properties.Resources.ff_ct_5;
            lbl_CT.Text = Strings.ct_5;
        }

        /// <summary>
        /// FireFox tutorial page 6
        /// </summary>
        public void ff_ct_6()
        {
            pb_Tut.Image = Properties.Resources.ff_ct_6;
            lbl_CT.Text = Strings.ct_6;
        }

        /// <summary>
        /// FireFox tutorial page 7
        /// </summary>
        public void ff_ct_7()
        {
            pb_Tut.Image = Properties.Resources.ff_ct_7;
            lbl_CT.Text = Strings.ct_7;
        }

        /// <summary>
        /// FireFox tutorial page 8
        /// </summary>
        public void ff_ct_8()
        {
            pb_Tut.Image = Properties.Resources.ff_ct_8;
            lbl_CT.Text = Strings.ct_8;
        }
        #endregion

        /////////////////////
        // CHROME TUTORIAL //
        /////////////////////

        #region
        /// <summary>
        /// Chrome tutorial page 1
        /// </summary>
        public void cr_ct_1()
        {
            pb_Tut.Image = Properties.Resources.cr_ct_1;
            lbl_CT.Text = Strings.ct_1;
        }

        /// <summary>
        /// Chrome tutorial page 2
        /// </summary>
        public void cr_ct_2()
        {
            pb_Tut.Image = Properties.Resources.cr_ct_2;
            lbl_CT.Text = Strings.ct_2_CR;
        }

        /// <summary>
        /// Chrome tutorial page 3
        /// </summary>
        public void cr_ct_3()
        {
            pb_Tut.Image = Properties.Resources.cr_ct_3;
            lbl_CT.Text = Strings.ct_3;
        }

        /// <summary>
        /// Chrome tutorial page 4
        /// </summary>
        public void cr_ct_4()
        {
            pb_Tut.Image = Properties.Resources.cr_ct_4;
            lbl_CT.Text = Strings.ct_4;
        }

        /// <summary>
        /// Chrome tutorial page 5
        /// </summary>
        public void cr_ct_5()
        {
            pb_Tut.Image = Properties.Resources.cr_ct_5;
            lbl_CT.Text = Strings.ct_5;
        }

        /// <summary>
        /// Chrome tutorial page 6
        /// </summary>
        public void cr_ct_6()
        {
            pb_Tut.Image = Properties.Resources.cr_ct_6;
            lbl_CT.Text = Strings.ct_6;
        }

        /// <summary>
        /// Chrome tutorial page 7
        /// </summary>
        public void cr_ct_7()
        {
            pb_Tut.Image = Properties.Resources.cr_ct_7;
            lbl_CT.Text = Strings.ct_7;
        }

        /// <summary>
        /// Chrome tutorial page 8
        /// </summary>
        public void cr_ct_8()
        {
            pb_Tut.Image = Properties.Resources.cr_ct_8;
            lbl_CT.Text = Strings.ct_8;
        }
        #endregion

        #endregion
    }
}
