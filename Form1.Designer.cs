namespace IndianSignLanguageGestureRecognition
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fillHolesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extractLargestBlobToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.andImagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x200ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detectEdgesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.doAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.histogramArrayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.multipleImagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.trainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(284, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openImageToolStripMenuItem,
            this.changeImageToolStripMenuItem,
            this.fillHolesToolStripMenuItem,
            this.extractLargestBlobToolStripMenuItem,
            this.andImagesToolStripMenuItem,
            this.x200ToolStripMenuItem,
            this.detectEdgesToolStripMenuItem,
            this.doAllToolStripMenuItem,
            this.histogramArrayToolStripMenuItem,
            this.multipleImagesToolStripMenuItem,
            this.trainToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openImageToolStripMenuItem
            // 
            this.openImageToolStripMenuItem.Name = "openImageToolStripMenuItem";
            this.openImageToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.openImageToolStripMenuItem.Text = "Open Image";
            this.openImageToolStripMenuItem.Click += new System.EventHandler(this.openImageToolStripMenuItem_Click);
            // 
            // changeImageToolStripMenuItem
            // 
            this.changeImageToolStripMenuItem.Name = "changeImageToolStripMenuItem";
            this.changeImageToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.changeImageToolStripMenuItem.Text = "Detect Skin";
            this.changeImageToolStripMenuItem.Click += new System.EventHandler(this.changeImageToolStripMenuItem_Click);
            // 
            // fillHolesToolStripMenuItem
            // 
            this.fillHolesToolStripMenuItem.Name = "fillHolesToolStripMenuItem";
            this.fillHolesToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.fillHolesToolStripMenuItem.Text = "Fill Holes";
            this.fillHolesToolStripMenuItem.Click += new System.EventHandler(this.fillHolesToolStripMenuItem_Click);
            // 
            // extractLargestBlobToolStripMenuItem
            // 
            this.extractLargestBlobToolStripMenuItem.Name = "extractLargestBlobToolStripMenuItem";
            this.extractLargestBlobToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.extractLargestBlobToolStripMenuItem.Text = "Extract Largest Blob";
            this.extractLargestBlobToolStripMenuItem.Click += new System.EventHandler(this.extractLargestBlobToolStripMenuItem_Click);
            // 
            // andImagesToolStripMenuItem
            // 
            this.andImagesToolStripMenuItem.Name = "andImagesToolStripMenuItem";
            this.andImagesToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.andImagesToolStripMenuItem.Text = "And Images";
            this.andImagesToolStripMenuItem.Click += new System.EventHandler(this.andImagesToolStripMenuItem_Click);
            // 
            // x200ToolStripMenuItem
            // 
            this.x200ToolStripMenuItem.Name = "x200ToolStripMenuItem";
            this.x200ToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.x200ToolStripMenuItem.Text = "200x200";
            this.x200ToolStripMenuItem.Click += new System.EventHandler(this.x200ToolStripMenuItem_Click);
            // 
            // detectEdgesToolStripMenuItem
            // 
            this.detectEdgesToolStripMenuItem.Name = "detectEdgesToolStripMenuItem";
            this.detectEdgesToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.detectEdgesToolStripMenuItem.Text = "Detect Edges";
            this.detectEdgesToolStripMenuItem.Click += new System.EventHandler(this.detectEdgesToolStripMenuItem_Click);
            // 
            // doAllToolStripMenuItem
            // 
            this.doAllToolStripMenuItem.Name = "doAllToolStripMenuItem";
            this.doAllToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.doAllToolStripMenuItem.Text = "Do All";
            this.doAllToolStripMenuItem.Click += new System.EventHandler(this.doAllToolStripMenuItem_Click);
            // 
            // histogramArrayToolStripMenuItem
            // 
            this.histogramArrayToolStripMenuItem.Name = "histogramArrayToolStripMenuItem";
            this.histogramArrayToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.histogramArrayToolStripMenuItem.Text = "Histogram Array";
            this.histogramArrayToolStripMenuItem.Click += new System.EventHandler(this.histogramArrayToolStripMenuItem_Click);
            // 
            // multipleImagesToolStripMenuItem
            // 
            this.multipleImagesToolStripMenuItem.Name = "multipleImagesToolStripMenuItem";
            this.multipleImagesToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.multipleImagesToolStripMenuItem.Text = "Multiple Images";
            this.multipleImagesToolStripMenuItem.Click += new System.EventHandler(this.multipleImagesToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(284, 237);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBox1.Location = new System.Drawing.Point(0, 161);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(284, 100);
            this.textBox1.TabIndex = 2;
            // 
            // trainToolStripMenuItem
            // 
            this.trainToolStripMenuItem.Name = "trainToolStripMenuItem";
            this.trainToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.trainToolStripMenuItem.Text = "Train";
            this.trainToolStripMenuItem.Click += new System.EventHandler(this.trainToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openImageToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem changeImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fillHolesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem extractLargestBlobToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem andImagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x200ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detectEdgesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem doAllToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolStripMenuItem histogramArrayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem multipleImagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trainToolStripMenuItem;
    }
}

