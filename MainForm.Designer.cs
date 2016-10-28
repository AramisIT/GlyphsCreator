namespace GlyphsCreator
    {
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.glyphPictureBox = new System.Windows.Forms.PictureBox();
            this.glyphDataTextBox = new System.Windows.Forms.TextBox();
            this.glyphTypeTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.autoUpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.runAutoDataUpdateButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.glyphPictureBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // glyphPictureBox
            // 
            this.glyphPictureBox.Location = new System.Drawing.Point(259, 28);
            this.glyphPictureBox.Name = "glyphPictureBox";
            this.glyphPictureBox.Size = new System.Drawing.Size(207, 207);
            this.glyphPictureBox.TabIndex = 0;
            this.glyphPictureBox.TabStop = false;
            // 
            // glyphDataTextBox
            // 
            this.glyphDataTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.glyphDataTextBox.Location = new System.Drawing.Point(527, 14);
            this.glyphDataTextBox.Name = "glyphDataTextBox";
            this.glyphDataTextBox.Size = new System.Drawing.Size(180, 26);
            this.glyphDataTextBox.TabIndex = 1;
            this.glyphDataTextBox.Text = "1";
            // 
            // glyphTypeTextBox
            // 
            this.glyphTypeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.glyphTypeTextBox.Location = new System.Drawing.Point(527, 48);
            this.glyphTypeTextBox.Name = "glyphTypeTextBox";
            this.glyphTypeTextBox.Size = new System.Drawing.Size(180, 26);
            this.glyphTypeTextBox.TabIndex = 2;
            this.glyphTypeTextBox.Text = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(14, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(507, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Glyph code data: int number between 1 and (2^35-1) = 34 359 738 367";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(14, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(328, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Glyph code type: int number between 0 and 3";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.glyphPictureBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 144);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(723, 259);
            this.panel1.TabIndex = 5;
            // 
            // autoUpdateTimer
            // 
            this.autoUpdateTimer.Tick += new System.EventHandler(this.autoUpdateTimer_Tick);
            // 
            // button1
            // 
            this.runAutoDataUpdateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.runAutoDataUpdateButton.Location = new System.Drawing.Point(18, 91);
            this.runAutoDataUpdateButton.Name = "button1";
            this.runAutoDataUpdateButton.Size = new System.Drawing.Size(187, 30);
            this.runAutoDataUpdateButton.TabIndex = 6;
            this.runAutoDataUpdateButton.Text = "Run auto data update timer";
            this.runAutoDataUpdateButton.UseVisualStyleBackColor = true;
            this.runAutoDataUpdateButton.Click += new System.EventHandler(this.runAutoDataUpdateButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 403);
            this.Controls.Add(this.runAutoDataUpdateButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.glyphTypeTextBox);
            this.Controls.Add(this.glyphDataTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Glyphs creator";
            ((System.ComponentModel.ISupportInitialize)(this.glyphPictureBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

            }

        #endregion
        private System.Windows.Forms.PictureBox glyphPictureBox;
        private System.Windows.Forms.TextBox glyphDataTextBox;
        private System.Windows.Forms.TextBox glyphTypeTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer autoUpdateTimer;
        private System.Windows.Forms.Button runAutoDataUpdateButton;
        }
    }

