namespace CellularAutomata
{
    partial class StartUpForm
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
            this.buttonWolfram = new System.Windows.Forms.Button();
            this.buttonConway = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonWolfram
            // 
            this.buttonWolfram.Location = new System.Drawing.Point(12, 12);
            this.buttonWolfram.Name = "buttonWolfram";
            this.buttonWolfram.Size = new System.Drawing.Size(226, 23);
            this.buttonWolfram.TabIndex = 0;
            this.buttonWolfram.Text = "WOLFRAM ALPHA";
            this.buttonWolfram.UseVisualStyleBackColor = true;
            this.buttonWolfram.Click += new System.EventHandler(this.buttonWolfram_Click);
            // 
            // buttonConway
            // 
            this.buttonConway.Location = new System.Drawing.Point(12, 41);
            this.buttonConway.Name = "buttonConway";
            this.buttonConway.Size = new System.Drawing.Size(226, 23);
            this.buttonConway.TabIndex = 1;
            this.buttonConway.Text = "CONWAY\'s GAME OF LIFE";
            this.buttonConway.UseVisualStyleBackColor = true;
            this.buttonConway.Click += new System.EventHandler(this.buttonConway_Click);
            // 
            // StartUpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 72);
            this.Controls.Add(this.buttonConway);
            this.Controls.Add(this.buttonWolfram);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StartUpForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonWolfram;
        private System.Windows.Forms.Button buttonConway;
    }
}