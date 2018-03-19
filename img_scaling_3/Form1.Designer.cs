namespace img_scaling_3
{
    partial class frm_main
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
            this.pbx_original = new System.Windows.Forms.PictureBox();
            this.pbx_edited = new System.Windows.Forms.PictureBox();
            this.btn_load = new System.Windows.Forms.Button();
            this.ofd_original = new System.Windows.Forms.OpenFileDialog();
            this.btn_resize = new System.Windows.Forms.Button();
            this.lbl_height = new System.Windows.Forms.Label();
            this.lbl_width = new System.Windows.Forms.Label();
            this.lbl_saved = new System.Windows.Forms.Label();
            this.sfd_edited = new System.Windows.Forms.SaveFileDialog();
            this.btn_save = new System.Windows.Forms.Button();
            this.nmr_height = new System.Windows.Forms.NumericUpDown();
            this.nmr_width = new System.Windows.Forms.NumericUpDown();
            this.lbl_orig_size = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_edit_size = new System.Windows.Forms.Label();
            this.btn_reset = new System.Windows.Forms.Button();
            this.lbl_info = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_original)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_edited)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmr_height)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmr_width)).BeginInit();
            this.SuspendLayout();
            // 
            // pbx_original
            // 
            this.pbx_original.BackColor = System.Drawing.Color.DimGray;
            this.pbx_original.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbx_original.Location = new System.Drawing.Point(11, 63);
            this.pbx_original.Name = "pbx_original";
            this.pbx_original.Size = new System.Drawing.Size(400, 400);
            this.pbx_original.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbx_original.TabIndex = 0;
            this.pbx_original.TabStop = false;
            this.pbx_original.Tag = "Original image";
            // 
            // pbx_edited
            // 
            this.pbx_edited.BackColor = System.Drawing.Color.DimGray;
            this.pbx_edited.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbx_edited.Location = new System.Drawing.Point(417, 63);
            this.pbx_edited.Name = "pbx_edited";
            this.pbx_edited.Size = new System.Drawing.Size(400, 400);
            this.pbx_edited.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbx_edited.TabIndex = 0;
            this.pbx_edited.TabStop = false;
            this.pbx_edited.Tag = "Edited image";
            // 
            // btn_load
            // 
            this.btn_load.Location = new System.Drawing.Point(11, 34);
            this.btn_load.Name = "btn_load";
            this.btn_load.Size = new System.Drawing.Size(92, 23);
            this.btn_load.TabIndex = 1;
            this.btn_load.Tag = "Load an image";
            this.btn_load.Text = "Load";
            this.btn_load.UseVisualStyleBackColor = true;
            this.btn_load.Click += new System.EventHandler(this.btn_load_Click);
            // 
            // btn_resize
            // 
            this.btn_resize.Enabled = false;
            this.btn_resize.Location = new System.Drawing.Point(586, 34);
            this.btn_resize.Name = "btn_resize";
            this.btn_resize.Size = new System.Drawing.Size(92, 23);
            this.btn_resize.TabIndex = 3;
            this.btn_resize.Tag = "Scale to set size";
            this.btn_resize.Text = "Resize";
            this.btn_resize.UseVisualStyleBackColor = true;
            this.btn_resize.Click += new System.EventHandler(this.btn_resize_Click);
            // 
            // lbl_height
            // 
            this.lbl_height.AutoSize = true;
            this.lbl_height.Location = new System.Drawing.Point(415, 15);
            this.lbl_height.Name = "lbl_height";
            this.lbl_height.Size = new System.Drawing.Size(64, 13);
            this.lbl_height.TabIndex = 4;
            this.lbl_height.Text = "New height:";
            // 
            // lbl_width
            // 
            this.lbl_width.AutoSize = true;
            this.lbl_width.Location = new System.Drawing.Point(415, 39);
            this.lbl_width.Name = "lbl_width";
            this.lbl_width.Size = new System.Drawing.Size(60, 13);
            this.lbl_width.TabIndex = 5;
            this.lbl_width.Text = "New width:";
            // 
            // lbl_saved
            // 
            this.lbl_saved.AutoSize = true;
            this.lbl_saved.ForeColor = System.Drawing.Color.Green;
            this.lbl_saved.Location = new System.Drawing.Point(776, 466);
            this.lbl_saved.Name = "lbl_saved";
            this.lbl_saved.Size = new System.Drawing.Size(41, 13);
            this.lbl_saved.TabIndex = 6;
            this.lbl_saved.Text = "Saved!";
            this.lbl_saved.Visible = false;
            // 
            // sfd_edited
            // 
            this.sfd_edited.FileName = "*.jpg";
            // 
            // btn_save
            // 
            this.btn_save.Enabled = false;
            this.btn_save.Location = new System.Drawing.Point(684, 34);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(92, 23);
            this.btn_save.TabIndex = 7;
            this.btn_save.Tag = "Save";
            this.btn_save.Text = "Save!";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // nmr_height
            // 
            this.nmr_height.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nmr_height.Location = new System.Drawing.Point(485, 13);
            this.nmr_height.Maximum = new decimal(new int[] {
            11000,
            0,
            0,
            0});
            this.nmr_height.Name = "nmr_height";
            this.nmr_height.Size = new System.Drawing.Size(99, 20);
            this.nmr_height.TabIndex = 8;
            this.nmr_height.Tag = "New height (width must be 0)";
            // 
            // nmr_width
            // 
            this.nmr_width.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nmr_width.Location = new System.Drawing.Point(485, 37);
            this.nmr_width.Maximum = new decimal(new int[] {
            11000,
            0,
            0,
            0});
            this.nmr_width.Name = "nmr_width";
            this.nmr_width.Size = new System.Drawing.Size(99, 20);
            this.nmr_width.TabIndex = 8;
            this.nmr_width.Tag = "New width (height must be 0)";
            // 
            // lbl_orig_size
            // 
            this.lbl_orig_size.AutoSize = true;
            this.lbl_orig_size.Location = new System.Drawing.Point(167, 466);
            this.lbl_orig_size.Name = "lbl_orig_size";
            this.lbl_orig_size.Size = new System.Drawing.Size(0, 13);
            this.lbl_orig_size.TabIndex = 9;
            this.lbl_orig_size.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(415, 466);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 9;
            this.label1.Visible = false;
            // 
            // lbl_edit_size
            // 
            this.lbl_edit_size.AutoSize = true;
            this.lbl_edit_size.Location = new System.Drawing.Point(589, 464);
            this.lbl_edit_size.Name = "lbl_edit_size";
            this.lbl_edit_size.Size = new System.Drawing.Size(0, 13);
            this.lbl_edit_size.TabIndex = 9;
            this.lbl_edit_size.Visible = false;
            // 
            // btn_reset
            // 
            this.btn_reset.Enabled = false;
            this.btn_reset.Location = new System.Drawing.Point(586, 10);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(92, 23);
            this.btn_reset.TabIndex = 1;
            this.btn_reset.Tag = "Reset to orig. img.";
            this.btn_reset.Text = "Reset";
            this.btn_reset.UseVisualStyleBackColor = true;
            this.btn_reset.Click += new System.EventHandler(this.btn_reset_Click);
            // 
            // lbl_info
            // 
            this.lbl_info.AutoSize = true;
            this.lbl_info.Location = new System.Drawing.Point(12, 466);
            this.lbl_info.Name = "lbl_info";
            this.lbl_info.Size = new System.Drawing.Size(0, 13);
            this.lbl_info.TabIndex = 10;
            // 
            // frm_main
            // 
            this.AcceptButton = this.btn_resize;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 486);
            this.Controls.Add(this.lbl_info);
            this.Controls.Add(this.lbl_edit_size);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_orig_size);
            this.Controls.Add(this.nmr_width);
            this.Controls.Add(this.nmr_height);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.lbl_saved);
            this.Controls.Add(this.lbl_width);
            this.Controls.Add(this.lbl_height);
            this.Controls.Add(this.btn_resize);
            this.Controls.Add(this.btn_reset);
            this.Controls.Add(this.btn_load);
            this.Controls.Add(this.pbx_edited);
            this.Controls.Add(this.pbx_original);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frm_main";
            this.Text = "Bildskalierung 2.0";
            this.Load += new System.EventHandler(this.frm_main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbx_original)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_edited)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmr_height)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmr_width)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbx_original;
        private System.Windows.Forms.PictureBox pbx_edited;
        private System.Windows.Forms.Button btn_load;
        private System.Windows.Forms.OpenFileDialog ofd_original;
        private System.Windows.Forms.Button btn_resize;
        private System.Windows.Forms.Label lbl_height;
        private System.Windows.Forms.Label lbl_width;
        private System.Windows.Forms.Label lbl_saved;
        private System.Windows.Forms.SaveFileDialog sfd_edited;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.NumericUpDown nmr_height;
        private System.Windows.Forms.NumericUpDown nmr_width;
        private System.Windows.Forms.Label lbl_orig_size;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_edit_size;
        private System.Windows.Forms.Button btn_reset;
        private System.Windows.Forms.Label lbl_info;
    }
}

