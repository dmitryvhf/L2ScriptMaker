
namespace L2ScriptMaker.Forms.Modules.AI
{
	partial class AIHandlersChecker
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
            this.btnQuit = new System.Windows.Forms.Button();
            this.btnCheckLines = new System.Windows.Forms.Button();
            this.Label2 = new System.Windows.Forms.Label();
            this.chkLabelsIgnore = new System.Windows.Forms.CheckBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.btnCheckVars = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.chkNoUseLog = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(243, 13);
            this.btnQuit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(88, 27);
            this.btnQuit.TabIndex = 60;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // btnCheckLines
            // 
            this.btnCheckLines.Location = new System.Drawing.Point(17, 50);
            this.btnCheckLines.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCheckLines.Name = "btnCheckLines";
            this.btnCheckLines.Size = new System.Drawing.Size(164, 43);
            this.btnCheckLines.TabIndex = 59;
            this.btnCheckLines.Text = "Handler Lines Amount";
            this.btnCheckLines.UseVisualStyleBackColor = true;
            this.btnCheckLines.Click += new System.EventHandler(this.btnCheckLines_Click);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.Label2.Location = new System.Drawing.Point(13, 9);
            this.Label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(144, 16);
            this.Label2.TabIndex = 61;
            this.Label2.Text = "AI.obj Handler Cheker";
            // 
            // chkLabelsIgnore
            // 
            this.chkLabelsIgnore.AutoSize = true;
            this.chkLabelsIgnore.Enabled = false;
            this.chkLabelsIgnore.Location = new System.Drawing.Point(189, 63);
            this.chkLabelsIgnore.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.chkLabelsIgnore.Name = "chkLabelsIgnore";
            this.chkLabelsIgnore.Size = new System.Drawing.Size(129, 19);
            this.chkLabelsIgnore.TabIndex = 63;
            this.chkLabelsIgnore.Text = "No counting Labels";
            this.toolTip1.SetToolTip(this.chkLabelsIgnore, "Not count \"Lxxxx\" labels.\r\nUse for modded servers, like HR and Kvoxi");
            this.chkLabelsIgnore.UseVisualStyleBackColor = true;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.Label3.Location = new System.Drawing.Point(13, 27);
            this.Label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(97, 13);
            this.Label3.TabIndex = 62;
            this.Label3.Text = "(support C4 scripts)";
            // 
            // btnCheckVars
            // 
            this.btnCheckVars.Location = new System.Drawing.Point(17, 100);
            this.btnCheckVars.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCheckVars.Name = "btnCheckVars";
            this.btnCheckVars.Size = new System.Drawing.Size(164, 43);
            this.btnCheckVars.TabIndex = 64;
            this.btnCheckVars.Text = "Handler Variable Definitions";
            this.btnCheckVars.UseVisualStyleBackColor = true;
            this.btnCheckVars.Click += new System.EventHandler(this.btnCheckVars_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(13, 155);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(314, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 65;
            // 
            // chkNoUseLog
            // 
            this.chkNoUseLog.AutoSize = true;
            this.chkNoUseLog.Location = new System.Drawing.Point(189, 113);
            this.chkNoUseLog.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.chkNoUseLog.Name = "chkNoUseLog";
            this.chkNoUseLog.Size = new System.Drawing.Size(109, 19);
            this.chkNoUseLog.TabIndex = 66;
            this.chkNoUseLog.Text = "No-use logging";
            this.toolTip1.SetToolTip(this.chkNoUseLog, "Not count \"Lxxxx\" labels.\r\nUse for modded servers, like HR and Kvoxi");
            this.chkNoUseLog.UseVisualStyleBackColor = true;
            // 
            // AIHandlersChecker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 190);
            this.Controls.Add(this.chkNoUseLog);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnCheckLines);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.chkLabelsIgnore);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.btnCheckVars);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "AIHandlersChecker";
            this.Text = "AIHandlersChecker";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		internal System.Windows.Forms.Button btnQuit;
		internal System.Windows.Forms.Button btnCheckLines;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.CheckBox chkLabelsIgnore;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.Button btnCheckVars;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.ToolTip toolTip1;
		internal System.Windows.Forms.CheckBox chkNoUseLog;
	}
}