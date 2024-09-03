namespace TpWinForms
{
    partial class FormNewArticle
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblCode = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblImage = new System.Windows.Forms.Label();
            this.txtUrlImage = new System.Windows.Forms.TextBox();
            this.btnAddImage = new System.Windows.Forms.Button();
            this.lBoxUrl = new System.Windows.Forms.ListBox();
            this.ptbUrlImagen = new System.Windows.Forms.PictureBox();
            this.btnAddNew = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ptbUrlImagen)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(255, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(179, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Add New Article";
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(59, 57);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(32, 13);
            this.lblCode.TabIndex = 1;
            this.lblCode.Text = "Code";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(55, 90);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Name";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(59, 128);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(31, 13);
            this.lblPrice.TabIndex = 3;
            this.lblPrice.Text = "Price";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(30, 161);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(60, 13);
            this.lblDescription.TabIndex = 4;
            this.lblDescription.Text = "Description";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(96, 54);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(196, 20);
            this.txtCode.TabIndex = 5;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(96, 87);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(196, 20);
            this.txtName.TabIndex = 6;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(96, 125);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(196, 20);
            this.txtPrice.TabIndex = 7;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(96, 158);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(196, 173);
            this.txtDescription.TabIndex = 8;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(398, 394);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblImage
            // 
            this.lblImage.AutoSize = true;
            this.lblImage.Location = new System.Drawing.Point(340, 54);
            this.lblImage.Name = "lblImage";
            this.lblImage.Size = new System.Drawing.Size(52, 13);
            this.lblImage.TabIndex = 10;
            this.lblImage.Text = "Url Image";
            // 
            // txtUrlImage
            // 
            this.txtUrlImage.Location = new System.Drawing.Point(398, 51);
            this.txtUrlImage.Name = "txtUrlImage";
            this.txtUrlImage.Size = new System.Drawing.Size(196, 20);
            this.txtUrlImage.TabIndex = 11;
            // 
            // btnAddImage
            // 
            this.btnAddImage.Location = new System.Drawing.Point(614, 48);
            this.btnAddImage.Name = "btnAddImage";
            this.btnAddImage.Size = new System.Drawing.Size(75, 23);
            this.btnAddImage.TabIndex = 12;
            this.btnAddImage.Text = "Add image";
            this.btnAddImage.UseVisualStyleBackColor = true;
            this.btnAddImage.Click += new System.EventHandler(this.btnAddImage_Click);
            // 
            // lBoxUrl
            // 
            this.lBoxUrl.FormattingEnabled = true;
            this.lBoxUrl.Location = new System.Drawing.Point(398, 87);
            this.lBoxUrl.Name = "lBoxUrl";
            this.lBoxUrl.Size = new System.Drawing.Size(196, 56);
            this.lBoxUrl.TabIndex = 13;
            this.lBoxUrl.SelectedIndexChanged += new System.EventHandler(this.lBoxUrl_SelectedIndexChanged);
            // 
            // ptbUrlImagen
            // 
            this.ptbUrlImagen.Location = new System.Drawing.Point(398, 161);
            this.ptbUrlImagen.Name = "ptbUrlImagen";
            this.ptbUrlImagen.Size = new System.Drawing.Size(196, 170);
            this.ptbUrlImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbUrlImagen.TabIndex = 14;
            this.ptbUrlImagen.TabStop = false;
            // 
            // btnAddNew
            // 
            this.btnAddNew.Location = new System.Drawing.Point(213, 394);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(101, 23);
            this.btnAddNew.TabIndex = 15;
            this.btnAddNew.Text = "Add New Article";
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // FormNewArticle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 443);
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.ptbUrlImagen);
            this.Controls.Add(this.lBoxUrl);
            this.Controls.Add(this.btnAddImage);
            this.Controls.Add(this.txtUrlImage);
            this.Controls.Add(this.lblImage);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.lblTitle);
            this.Name = "FormNewArticle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormNewArticle";
            this.Load += new System.EventHandler(this.FormNewArticle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ptbUrlImagen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblImage;
        private System.Windows.Forms.TextBox txtUrlImage;
        private System.Windows.Forms.Button btnAddImage;
        private System.Windows.Forms.ListBox lBoxUrl;
        private System.Windows.Forms.PictureBox ptbUrlImagen;
        private System.Windows.Forms.Button btnAddNew;
    }
}