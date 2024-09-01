using Business;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TpWinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BusinessArticle business = new BusinessArticle();
            List<Article> articlelist = new List<Article>();

            try
            {
                articlelist = business.list();
                dgvArticles.DataSource = articlelist;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
