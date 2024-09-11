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
    public partial class FormCategory : Form
    {
        private List<Category> listCategory;
        private Category cat = null;

        public FormCategory()
        {
            InitializeComponent();
        }

        private void load()
        {
            BusinessCategory business = new BusinessCategory();
            try
            {
                listCategory = business.list();
                dgvCategories.DataSource = listCategory;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void FormCategory_Load(object sender, EventArgs e)
        {
            load();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            BusinessCategory business = new BusinessCategory();
            try
            {
                if (cat == null)
                    cat = new Category();

                cat.Description = (string)txtNewCategory.Text;
                business.add(cat);
                MessageBox.Show("Category added successfully");
                load();
                txtNewCategory.Text = "";
            }
            catch (Exception ex)

            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            BusinessCategory negocio = new BusinessCategory();
            Category selected;
            try
            {
                DialogResult response = MessageBox.Show("Are you sure to delete this category?", "Eliminating", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (response == DialogResult.Yes)
                {
                    selected = (Category)dgvCategories.CurrentRow.DataBoundItem;
                    negocio.delete(selected.Id);
                    load();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtNewCategory_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validation.onlyLetters((KeyPressEventArgs)e);
        }
    }
}
