namespace GDC_Proyecto
{
    partial class GameForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameForm));
            this.SpaceCraft = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.SpaceCraft)).BeginInit();
            this.SuspendLayout();
            // 
            // SpaceCraft
            // 
            this.SpaceCraft.BackColor = System.Drawing.Color.Transparent;
            this.SpaceCraft.Location = new System.Drawing.Point(544, 658);
            this.SpaceCraft.Name = "SpaceCraft";
            this.SpaceCraft.Size = new System.Drawing.Size(347, 207);
            this.SpaceCraft.TabIndex = 0;
            this.SpaceCraft.TabStop = false;
            this.SpaceCraft.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SpaceCraft_MouseMove);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GDC_Proyecto.Properties.Resources._131206_abstract_dark_blue_polygon_background_template;
            this.ClientSize = new System.Drawing.Size(1480, 1010);
            this.Controls.Add(this.SpaceCraft);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "GameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ARKANOID";
            this.Load += new System.EventHandler(this.GameForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GameForm_KeyPress);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SpaceCraft_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.SpaceCraft)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox SpaceCraft;
    }
}