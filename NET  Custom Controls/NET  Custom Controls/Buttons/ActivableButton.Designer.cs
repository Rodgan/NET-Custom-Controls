namespace NET__Custom_Controls
{
    partial class ActivableButton
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione componenti

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare 
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.LabelText = new System.Windows.Forms.Label();
            this.StatusBar = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // LabelText
            // 
            this.LabelText.BackColor = System.Drawing.Color.Transparent;
            this.LabelText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelText.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelText.Location = new System.Drawing.Point(25, 0);
            this.LabelText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelText.Name = "LabelText";
            this.LabelText.Size = new System.Drawing.Size(204, 41);
            this.LabelText.TabIndex = 3;
            this.LabelText.Text = "Activable Button";
            this.LabelText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StatusBar
            // 
            this.StatusBar.BackColor = System.Drawing.Color.ForestGreen;
            this.StatusBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.StatusBar.Location = new System.Drawing.Point(0, 0);
            this.StatusBar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(25, 41);
            this.StatusBar.TabIndex = 2;
            // 
            // ActivableButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.LabelText);
            this.Controls.Add(this.StatusBar);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "ActivableButton";
            this.Size = new System.Drawing.Size(229, 41);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LabelText;
        private System.Windows.Forms.Panel StatusBar;
    }
}
