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
            this.trainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recordVideoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1353, 24);
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
            this.trainToolStripMenuItem,
            this.recordVideoToolStripMenuItem,
            this.newImageToolStripMenuItem});
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
            // trainToolStripMenuItem
            // 
            this.trainToolStripMenuItem.Name = "trainToolStripMenuItem";
            this.trainToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.trainToolStripMenuItem.Text = "Train";
            this.trainToolStripMenuItem.Click += new System.EventHandler(this.trainToolStripMenuItem_Click);
            // 
            // recordVideoToolStripMenuItem
            // 
            this.recordVideoToolStripMenuItem.Name = "recordVideoToolStripMenuItem";
            this.recordVideoToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.recordVideoToolStripMenuItem.Text = "Record Video";
            this.recordVideoToolStripMenuItem.Click += new System.EventHandler(this.recordVideoToolStripMenuItem_Click);
            // 
            // newImageToolStripMenuItem
            // 
            this.newImageToolStripMenuItem.Name = "newImageToolStripMenuItem";
            this.newImageToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.newImageToolStripMenuItem.Text = "new image";
            this.newImageToolStripMenuItem.Click += new System.EventHandler(this.newImageToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(545, 150);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(252, 211);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(0, 106);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(477, 266);
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(243, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 42);
            this.button1.TabIndex = 5;
            this.button1.Text = "Stop Video";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(583, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 108);
            this.label1.TabIndex = 6;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(162, 28);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 42);
            this.button2.TabIndex = 7;
            this.button2.Text = "Start Video";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(0, 27);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 43);
            this.button3.TabIndex = 8;
            this.button3.Text = "Train";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(81, 28);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 42);
            this.button4.TabIndex = 9;
            this.button4.Text = "Test with static image";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(324, 28);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 42);
            this.button5.TabIndex = 10;
            this.button5.Text = "Train with New Data";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1353, 741);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
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
        private System.Windows.Forms.ToolStripMenuItem histogramArrayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem multipleImagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trainToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recordVideoToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem newImageToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}

