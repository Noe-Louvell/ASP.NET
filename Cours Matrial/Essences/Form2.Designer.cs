﻿
namespace Essences
{
    partial class Form2
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelEss = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.panelEss.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEss
            // 
            this.panelEss.Controls.Add(this.button1);
            this.panelEss.Location = new System.Drawing.Point(337, 85);
            this.panelEss.Name = "panelEss";
            this.panelEss.Size = new System.Drawing.Size(200, 100);
            this.panelEss.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(60, 36);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 590);
            this.Controls.Add(this.panelEss);
            this.Name = "Form2";
            this.Text = "Form1";
            this.panelEss.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelEss;
        private System.Windows.Forms.Button button1;
    }
}

