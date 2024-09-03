namespace TpWinForms
{
    partial class FormArticles
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvArticles = new System.Windows.Forms.DataGridView();
            this.pboxImg = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxImg)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvArticles
            // 
            this.dgvArticles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArticles.Location = new System.Drawing.Point(50, 69);
            this.dgvArticles.Margin = new System.Windows.Forms.Padding(6);
            this.dgvArticles.Name = "dgvArticles";
            this.dgvArticles.RowHeadersWidth = 82;
            this.dgvArticles.Size = new System.Drawing.Size(946, 440);
            this.dgvArticles.TabIndex = 0;
            this.dgvArticles.SelectionChanged += new System.EventHandler(this.dgvArticles_SelectionChanged);
            // 
            // pboxImg
            // 
            this.pboxImg.Location = new System.Drawing.Point(1043, 64);
            this.pboxImg.Name = "pboxImg";
            this.pboxImg.Size = new System.Drawing.Size(482, 444);
            this.pboxImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pboxImg.TabIndex = 1;
            this.pboxImg.TabStop = false;
            // 
            // FormArticles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 865);
            this.Controls.Add(this.pboxImg);
            this.Controls.Add(this.dgvArticles);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FormArticles";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormArticle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxImg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvArticles;
        private System.Windows.Forms.PictureBox pboxImg;
    }
}

