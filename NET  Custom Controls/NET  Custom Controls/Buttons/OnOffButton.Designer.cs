namespace NET__Custom_Controls.Buttons
{
    partial class OnOffButton
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
            this.panelOFF = new NET__Custom_Controls.Panel.Panel();
            this.lblOFF = new System.Windows.Forms.Label();
            this.panelON = new NET__Custom_Controls.Panel.Panel();
            this.lblON = new System.Windows.Forms.Label();
            this.panelOFF.SuspendLayout();
            this.panelON.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelOFF
            // 
            this.panelOFF.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelOFF.GradientColorList = null;
            this.panelOFF.ColorMode = NET__Custom_Controls.ColorMode.Solid;
            this.panelOFF.Controls.Add(this.lblOFF);
            this.panelOFF.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelOFF.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelOFF.GradientColorDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.panelOFF.Location = new System.Drawing.Point(64, 0);
            this.panelOFF.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.panelOFF.Name = "panelOFF";
            this.panelOFF.Size = new System.Drawing.Size(70, 32);
            this.panelOFF.TabIndex = 1;
            // 
            // lblOFF
            // 
            this.lblOFF.BackColor = System.Drawing.Color.Transparent;
            this.lblOFF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOFF.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOFF.ForeColor = System.Drawing.Color.White;
            this.lblOFF.Location = new System.Drawing.Point(0, 0);
            this.lblOFF.Name = "lblOFF";
            this.lblOFF.Size = new System.Drawing.Size(70, 32);
            this.lblOFF.TabIndex = 1;
            this.lblOFF.Text = "OFF";
            this.lblOFF.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelON
            // 
            this.panelON.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panelON.GradientColorList = null;
            this.panelON.ColorMode = NET__Custom_Controls.ColorMode.Solid;
            this.panelON.Controls.Add(this.lblON);
            this.panelON.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelON.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelON.GradientColorDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.panelON.Location = new System.Drawing.Point(0, 0);
            this.panelON.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.panelON.Name = "panelON";
            this.panelON.Size = new System.Drawing.Size(70, 32);
            this.panelON.TabIndex = 0;
            // 
            // lblON
            // 
            this.lblON.BackColor = System.Drawing.Color.Transparent;
            this.lblON.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblON.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblON.ForeColor = System.Drawing.Color.White;
            this.lblON.Location = new System.Drawing.Point(0, 0);
            this.lblON.Name = "lblON";
            this.lblON.Size = new System.Drawing.Size(70, 32);
            this.lblON.TabIndex = 0;
            this.lblON.Text = "ON";
            this.lblON.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OnOffButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelOFF);
            this.Controls.Add(this.panelON);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "OnOffButton";
            this.Size = new System.Drawing.Size(134, 32);
            this.panelOFF.ResumeLayout(false);
            this.panelON.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel.Panel panelON;
        private Panel.Panel panelOFF;
        private System.Windows.Forms.Label lblOFF;
        private System.Windows.Forms.Label lblON;
    }
}
