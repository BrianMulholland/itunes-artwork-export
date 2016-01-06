namespace iTunes_Artwork_Export
{
  partial class frmSettings
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
      this.btnOK = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.txtFileName = new System.Windows.Forms.TextBox();
      this.groupBoxUserSeverity = new System.Windows.Forms.GroupBox();
      this.rbDebug = new System.Windows.Forms.RadioButton();
      this.rbSuccess = new System.Windows.Forms.RadioButton();
      this.rbWarning = new System.Windows.Forms.RadioButton();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.numAlbumMatchPercentage = new System.Windows.Forms.NumericUpDown();
      this.label6 = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.label8 = new System.Windows.Forms.Label();
      this.numMinTracks = new System.Windows.Forms.NumericUpDown();
      this.groupBoxUserSeverity.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.numAlbumMatchPercentage)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.numMinTracks)).BeginInit();
      this.SuspendLayout();
      // 
      // btnOK
      // 
      this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.btnOK.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnOK.Location = new System.Drawing.Point(122, 337);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new System.Drawing.Size(91, 30);
      this.btnOK.TabIndex = 0;
      this.btnOK.Text = "OK";
      this.btnOK.UseVisualStyleBackColor = true;
      this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
      // 
      // btnCancel
      // 
      this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnCancel.Location = new System.Drawing.Point(239, 337);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(88, 30);
      this.btnCancel.TabIndex = 1;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(55, 20);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(99, 13);
      this.label1.TabIndex = 2;
      this.label1.Text = "Export File Name:";
      // 
      // txtFileName
      // 
      this.txtFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtFileName.Location = new System.Drawing.Point(160, 20);
      this.txtFileName.Name = "txtFileName";
      this.txtFileName.Size = new System.Drawing.Size(272, 22);
      this.txtFileName.TabIndex = 3;
      // 
      // groupBoxUserSeverity
      // 
      this.groupBoxUserSeverity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.groupBoxUserSeverity.Controls.Add(this.rbDebug);
      this.groupBoxUserSeverity.Controls.Add(this.rbSuccess);
      this.groupBoxUserSeverity.Controls.Add(this.rbWarning);
      this.groupBoxUserSeverity.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.groupBoxUserSeverity.Location = new System.Drawing.Point(12, 222);
      this.groupBoxUserSeverity.Name = "groupBoxUserSeverity";
      this.groupBoxUserSeverity.Size = new System.Drawing.Size(420, 98);
      this.groupBoxUserSeverity.TabIndex = 4;
      this.groupBoxUserSeverity.TabStop = false;
      this.groupBoxUserSeverity.Text = "Output Text:";
      // 
      // rbDebug
      // 
      this.rbDebug.AutoSize = true;
      this.rbDebug.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.rbDebug.Location = new System.Drawing.Point(16, 67);
      this.rbDebug.Name = "rbDebug";
      this.rbDebug.Size = new System.Drawing.Size(365, 17);
      this.rbDebug.TabIndex = 2;
      this.rbDebug.TabStop = true;
      this.rbDebug.Text = "Show warnings, success messages, and debug info (most verbose)";
      this.rbDebug.UseVisualStyleBackColor = true;
      // 
      // rbSuccess
      // 
      this.rbSuccess.AutoSize = true;
      this.rbSuccess.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.rbSuccess.Location = new System.Drawing.Point(16, 44);
      this.rbSuccess.Name = "rbSuccess";
      this.rbSuccess.Size = new System.Drawing.Size(221, 17);
      this.rbSuccess.TabIndex = 1;
      this.rbSuccess.TabStop = true;
      this.rbSuccess.Text = "Show warnings and success messages";
      this.rbSuccess.UseVisualStyleBackColor = true;
      // 
      // rbWarning
      // 
      this.rbWarning.AutoSize = true;
      this.rbWarning.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.rbWarning.Location = new System.Drawing.Point(16, 21);
      this.rbWarning.Name = "rbWarning";
      this.rbWarning.Size = new System.Drawing.Size(206, 17);
      this.rbWarning.TabIndex = 0;
      this.rbWarning.TabStop = true;
      this.rbWarning.Text = "Show warnings only (least verbose)";
      this.rbWarning.UseVisualStyleBackColor = true;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(157, 45);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(246, 13);
      this.label2.TabIndex = 5;
      this.label2.Text = "The file name for the artwork (eg, \"folder.jpg\").";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label3.Location = new System.Drawing.Point(34, 79);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(120, 13);
      this.label3.TabIndex = 6;
      this.label3.Text = "Minimum # of Tracks:";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(157, 101);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(265, 26);
      this.label4.TabIndex = 8;
      this.label4.Text = "The minimum number of tracks that must exist in a\r\ndirectory in order to export a" +
    "rtwork to it.";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label5.Location = new System.Drawing.Point(12, 146);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(142, 13);
      this.label5.TabIndex = 9;
      this.label5.Text = "Album Match Percentage:";
      // 
      // numAlbumMatchPercentage
      // 
      this.numAlbumMatchPercentage.Location = new System.Drawing.Point(160, 144);
      this.numAlbumMatchPercentage.Name = "numAlbumMatchPercentage";
      this.numAlbumMatchPercentage.Size = new System.Drawing.Size(64, 22);
      this.numAlbumMatchPercentage.TabIndex = 10;
      this.numAlbumMatchPercentage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.numAlbumMatchPercentage.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(157, 169);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(269, 39);
      this.label6.TabIndex = 11;
      this.label6.Text = "The percentage of tracks in the directory where the\r\nartist and album must match " +
    "in order to export\r\nartwork to it.";
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label7.Location = new System.Drawing.Point(238, 79);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(53, 13);
      this.label7.TabIndex = 12;
      this.label7.Text = "Default: 3";
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label8.Location = new System.Drawing.Point(238, 146);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(68, 13);
      this.label8.TabIndex = 13;
      this.label8.Text = "Default: 90%";
      // 
      // numMinTracks
      // 
      this.numMinTracks.Location = new System.Drawing.Point(160, 76);
      this.numMinTracks.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
      this.numMinTracks.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.numMinTracks.Name = "numMinTracks";
      this.numMinTracks.Size = new System.Drawing.Size(64, 22);
      this.numMinTracks.TabIndex = 14;
      this.numMinTracks.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.numMinTracks.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
      // 
      // frmSettings
      // 
      this.AcceptButton = this.btnOK;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btnCancel;
      this.ClientSize = new System.Drawing.Size(440, 375);
      this.ControlBox = false;
      this.Controls.Add(this.numMinTracks);
      this.Controls.Add(this.label8);
      this.Controls.Add(this.label7);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.numAlbumMatchPercentage);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.groupBoxUserSeverity);
      this.Controls.Add(this.txtFileName);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.btnOK);
      this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "frmSettings";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Settings";
      this.groupBoxUserSeverity.ResumeLayout(false);
      this.groupBoxUserSeverity.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.numAlbumMatchPercentage)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.numMinTracks)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btnOK;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txtFileName;
    private System.Windows.Forms.GroupBox groupBoxUserSeverity;
    private System.Windows.Forms.RadioButton rbWarning;
    private System.Windows.Forms.RadioButton rbDebug;
    private System.Windows.Forms.RadioButton rbSuccess;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.NumericUpDown numAlbumMatchPercentage;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.NumericUpDown numMinTracks;
  }
}