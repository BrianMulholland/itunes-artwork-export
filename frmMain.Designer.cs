﻿namespace iTunes_Artwork_Export
{
  partial class frmMain
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
      this.txtMain = new System.Windows.Forms.TextBox();
      this.btnDoExport = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // txtMain
      // 
      this.txtMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtMain.BackColor = System.Drawing.SystemColors.Window;
      this.txtMain.Location = new System.Drawing.Point(12, 12);
      this.txtMain.MaxLength = 2000000;
      this.txtMain.Multiline = true;
      this.txtMain.Name = "txtMain";
      this.txtMain.ReadOnly = true;
      this.txtMain.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.txtMain.Size = new System.Drawing.Size(474, 299);
      this.txtMain.TabIndex = 0;
      this.txtMain.WordWrap = false;
      // 
      // btnDoExport
      // 
      this.btnDoExport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.btnDoExport.Location = new System.Drawing.Point(169, 322);
      this.btnDoExport.Name = "btnDoExport";
      this.btnDoExport.Size = new System.Drawing.Size(147, 40);
      this.btnDoExport.TabIndex = 1;
      this.btnDoExport.Text = "Do Export";
      this.btnDoExport.UseVisualStyleBackColor = true;
      this.btnDoExport.Click += new System.EventHandler(this.btnDoExport_Click);
      // 
      // frmMain
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(502, 375);
      this.Controls.Add(this.btnDoExport);
      this.Controls.Add(this.txtMain);
      this.Name = "frmMain";
      this.Text = "iTunes Artwork Export";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox txtMain;
    private System.Windows.Forms.Button btnDoExport;
  }
}
