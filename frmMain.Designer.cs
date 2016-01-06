namespace iTunes_Artwork_Export
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
      this.prgBarExport = new System.Windows.Forms.ProgressBar();
      this.btnCancel = new System.Windows.Forms.Button();
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.saveOutputToFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.menuStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // txtMain
      // 
      this.txtMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtMain.BackColor = System.Drawing.SystemColors.Window;
      this.txtMain.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtMain.Location = new System.Drawing.Point(12, 39);
      this.txtMain.MaxLength = 2000000;
      this.txtMain.Multiline = true;
      this.txtMain.Name = "txtMain";
      this.txtMain.ReadOnly = true;
      this.txtMain.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.txtMain.Size = new System.Drawing.Size(512, 273);
      this.txtMain.TabIndex = 0;
      this.txtMain.WordWrap = false;
      // 
      // btnDoExport
      // 
      this.btnDoExport.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.btnDoExport.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnDoExport.Location = new System.Drawing.Point(196, 318);
      this.btnDoExport.Name = "btnDoExport";
      this.btnDoExport.Size = new System.Drawing.Size(143, 40);
      this.btnDoExport.TabIndex = 1;
      this.btnDoExport.Text = "Export Artwork";
      this.btnDoExport.UseVisualStyleBackColor = true;
      this.btnDoExport.Click += new System.EventHandler(this.btnDoExport_Click);
      // 
      // prgBarExport
      // 
      this.prgBarExport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.prgBarExport.Location = new System.Drawing.Point(1, 370);
      this.prgBarExport.Name = "prgBarExport";
      this.prgBarExport.Size = new System.Drawing.Size(534, 23);
      this.prgBarExport.TabIndex = 2;
      // 
      // btnCancel
      // 
      this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnCancel.Location = new System.Drawing.Point(98, 327);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(68, 23);
      this.btnCancel.TabIndex = 3;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
      // 
      // menuStrip1
      // 
      this.menuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(536, 24);
      this.menuStrip1.TabIndex = 4;
      // 
      // fileToolStripMenuItem
      // 
      this.fileToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
      this.fileToolStripMenuItem.Text = "&File";
      this.fileToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.fileToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
      // 
      // exitToolStripMenuItem
      // 
      this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
      this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
      this.exitToolStripMenuItem.Text = "E&xit";
      this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
      // 
      // toolsToolStripMenuItem
      // 
      this.toolsToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem,
            this.saveOutputToFileToolStripMenuItem});
      this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
      this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
      this.toolsToolStripMenuItem.Text = "&Tools";
      this.toolsToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // optionsToolStripMenuItem
      // 
      this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
      this.optionsToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
      this.optionsToolStripMenuItem.Text = "&Options...";
      this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
      // 
      // saveOutputToFileToolStripMenuItem
      // 
      this.saveOutputToFileToolStripMenuItem.Name = "saveOutputToFileToolStripMenuItem";
      this.saveOutputToFileToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
      this.saveOutputToFileToolStripMenuItem.Text = "&Save Output to File...";
      this.saveOutputToFileToolStripMenuItem.Click += new System.EventHandler(this.saveOutputToFileToolStripMenuItem_Click);
      // 
      // helpToolStripMenuItem
      // 
      this.helpToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
      this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
      this.helpToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0);
      this.helpToolStripMenuItem.Size = new System.Drawing.Size(36, 20);
      this.helpToolStripMenuItem.Text = "&Help";
      this.helpToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // aboutToolStripMenuItem
      // 
      this.aboutToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
      this.aboutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
      this.aboutToolStripMenuItem.Text = "&About...";
      this.aboutToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.aboutToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
      // 
      // frmMain
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(536, 394);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.prgBarExport);
      this.Controls.Add(this.btnDoExport);
      this.Controls.Add(this.txtMain);
      this.Controls.Add(this.menuStrip1);
      this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.MainMenuStrip = this.menuStrip1;
      this.Name = "frmMain";
      this.Text = "iTunes Artwork Export";
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox txtMain;
    private System.Windows.Forms.Button btnDoExport;
    private System.Windows.Forms.ProgressBar prgBarExport;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem saveOutputToFileToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
  }
}

