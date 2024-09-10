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
using System.Windows.Controls;
using System.Windows.Forms;


namespace TpWinForms
{
    public partial class FormArticles : Form
    {
        List<Article> articlelist;
        public FormArticles()
        {
            InitializeComponent();
        }

        private void FormArticle_Load(object sender, EventArgs e)
        {
            LoadCboxField();
            LoadGrid();
        }
        private void LoadGrid()
        {
            BusinessArticle business = new BusinessArticle();
            try
            {
                articlelist = business.list();
                dgvArticles.DataSource = articlelist;
                hideColumns();
                //CHEQUEAR:
                if (dgvArticles.CurrentRow != null)
                {
                    Article selected = (Article)dgvArticles.CurrentRow.DataBoundItem;
                    if (selected.UrlImages.Count > 0)
                        LoadImg(selected.UrlImages[0].UrlImage);
                    else
                        LoadImg("");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void LoadCboxField()
        {
            cboxField.Items.Add("Name");
            cboxField.Items.Add("Brand");
            cboxField.Items.Add("Price");
            cboxField.Items.Add("Category");
        }
        private void LoadImg(string imagen)
        {
            try
            {
                pboxImg.Load(imagen);
            }
            catch (Exception ex)
            {
                pboxImg.Load("https://faculty.eng.ufl.edu/elliot-douglas/wp-content/uploads/sites/70/2015/11/img-placeholder.png");
            }
        }
        private void dgvArticles_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvArticles.CurrentRow != null)
            {
                Article selected = (Article)dgvArticles.CurrentRow.DataBoundItem;
                //CHEQUEAR:
                if (!string.IsNullOrEmpty(selected.UrlImages[0].ToString()))
                    LoadImg(selected.UrlImages[0].UrlImage);
                else
                    LoadImg("");
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormArticle form = new FormArticle();
            form.ShowDialog();
            LoadGrid();
        }
        private void btnModify_Click(object sender, EventArgs e)
        {
             
            Article art = (Article)dgvArticles.CurrentRow.DataBoundItem;
            FormArticle form = new FormArticle(art, "Modify");
            form.ShowDialog();
            LoadGrid();
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            Article art = (Article)dgvArticles.CurrentRow.DataBoundItem;
            FormArticle form = new FormArticle(art, "Details");
            form.ShowDialog();
            LoadGrid();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            BusinessArticle business = new BusinessArticle();
            Article select;
            try
            {
                DialogResult response = MessageBox.Show("Are you sure you want to delete?", "Eliminating", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (response == DialogResult.Yes)
                {
                    select = (Article)dgvArticles.CurrentRow.DataBoundItem;
                    business.deleteArticle(select.Id);
                    LoadGrid();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            List<Article> filteredList;

            string filter = txtFilter.Text;
            if (filter.Length >= 3)
                filteredList = articlelist.FindAll(art => art.Name.ToUpper().Contains(filter.ToUpper()) || art.Brand.Description.ToUpper().Contains(filter.ToUpper()) || art.Category.Description.ToUpper().Contains(filter.ToUpper()) || art.Description.ToUpper().Contains(filter.ToUpper()) || art.Price.ToString().Contains(filter));
            else
                filteredList = articlelist;

            dgvArticles.DataSource = null;
            dgvArticles.DataSource = filteredList;
            hideColumns();

        }

        private void cboxField_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboxMatch.Items.Clear();
            if (cboxField.SelectedIndex != -1)
            {
                string field = cboxField.SelectedItem.ToString();
                switch (field)
                {
                    case "Price":
                        cboxMatch.Items.Add("Less than");
                        cboxMatch.Items.Add("Greater than");
                        cboxMatch.Items.Add("Equals to");
                        break;
                    default:
                        cboxMatch.Items.Add("Starts with");
                        cboxMatch.Items.Add("End with");
                        cboxMatch.Items.Add("Contains");
                        break;
                }
            }
            else
                cboxMatch.Items.Clear();
        }
        private void advFilter()
        {
            BusinessArticle business = new BusinessArticle();
            try
            {
                if (!Model.Validation.FilterValidation(cboxField, cboxMatch, txtAdvFilter))
                    return;

                string field = cboxField.SelectedItem.ToString();
                if (field == "")
                {
                    LoadGrid();
                    return;
                }
                string match = cboxMatch.SelectedItem.ToString();
                string filterText = txtAdvFilter.Text;
                dgvArticles.DataSource = business.filter(field, match, filterText);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            advFilter();
        }

        private void txtAdvFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
               advFilter();
                e.Handled = true; // evita que se genere el sonido de la tecla Enter
            }
        }

        private void hideColumns()
        {
            //dgvArticles.Columns["UrlImages"].Visible = false;
            dgvArticles.Columns["Code"].Visible = false;
            dgvArticles.Columns["Description"].Visible = false;
            dgvArticles.Columns["Id"].Visible = false;
        }

        
    }
}
