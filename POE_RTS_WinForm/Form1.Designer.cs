namespace POE_RTS_WinForm
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
      this.components = new System.ComponentModel.Container();
      this.rtbMap = new System.Windows.Forms.RichTextBox();
      this.lblRoundCount = new System.Windows.Forms.Label();
      this.btnStart = new System.Windows.Forms.Button();
      this.btnPause = new System.Windows.Forms.Button();
      this.rtbUnitInfo = new System.Windows.Forms.RichTextBox();
      this.timer1 = new System.Windows.Forms.Timer(this.components);
      this.SuspendLayout();
      // 
      // rtbMap
      // 
      this.rtbMap.Location = new System.Drawing.Point(12, 67);
      this.rtbMap.Name = "rtbMap";
      this.rtbMap.Size = new System.Drawing.Size(350, 350);
      this.rtbMap.TabIndex = 0;
      this.rtbMap.Text = "";
      // 
      // lblRoundCount
      // 
      this.lblRoundCount.AutoSize = true;
      this.lblRoundCount.Location = new System.Drawing.Point(12, 26);
      this.lblRoundCount.Name = "lblRoundCount";
      this.lblRoundCount.Size = new System.Drawing.Size(50, 17);
      this.lblRoundCount.TabIndex = 1;
      this.lblRoundCount.Text = "Round";
      // 
      // btnStart
      // 
      this.btnStart.Location = new System.Drawing.Point(368, 67);
      this.btnStart.Name = "btnStart";
      this.btnStart.Size = new System.Drawing.Size(75, 75);
      this.btnStart.TabIndex = 2;
      this.btnStart.Text = "Start";
      this.btnStart.UseVisualStyleBackColor = true;
      this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
      // 
      // btnPause
      // 
      this.btnPause.Location = new System.Drawing.Point(368, 172);
      this.btnPause.Name = "btnPause";
      this.btnPause.Size = new System.Drawing.Size(75, 75);
      this.btnPause.TabIndex = 2;
      this.btnPause.Text = "Pause";
      this.btnPause.UseVisualStyleBackColor = true;
      this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
      // 
      // rtbUnitInfo
      // 
      this.rtbUnitInfo.Location = new System.Drawing.Point(449, 67);
      this.rtbUnitInfo.Name = "rtbUnitInfo";
      this.rtbUnitInfo.Size = new System.Drawing.Size(350, 350);
      this.rtbUnitInfo.TabIndex = 0;
      this.rtbUnitInfo.Text = "";
      // 
      // timer1
      // 
      this.timer1.Interval = 1000;
      this.timer1.Tick += new System.EventHandler(this.time1_Tick);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(819, 437);
      this.Controls.Add(this.btnPause);
      this.Controls.Add(this.btnStart);
      this.Controls.Add(this.lblRoundCount);
      this.Controls.Add(this.rtbUnitInfo);
      this.Controls.Add(this.rtbMap);
      this.Name = "Form1";
      this.Text = "Form1";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.RichTextBox rtbMap;
    private System.Windows.Forms.Label lblRoundCount;
    private System.Windows.Forms.Button btnStart;
    private System.Windows.Forms.Button btnPause;
    private System.Windows.Forms.RichTextBox rtbUnitInfo;
    private System.Windows.Forms.Timer timer1;
  }
}

