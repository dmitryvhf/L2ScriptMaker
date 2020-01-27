namespace L2ScriptMaker.Modules.Others
{
	partial class QuestPchMaker
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
			this.Label1 = new System.Windows.Forms.Label();
			this.QuestCacheScript = new System.Windows.Forms.Button();
			this.Label2 = new System.Windows.Forms.Label();
			this.ProgressBar = new System.Windows.Forms.ProgressBar();
			this.ButtonExit = new System.Windows.Forms.Button();
			this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.MakeUndefinedBox = new System.Windows.Forms.CheckBox();
			this.StatusLabel = new System.Windows.Forms.Label();
			this.Label3 = new System.Windows.Forms.Label();
			this.QuestPchButton = new System.Windows.Forms.Button();
			this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
			this.SuspendLayout();
			// 
			// Label1
			// 
			this.Label1.AutoSize = true;
			this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label1.Location = new System.Drawing.Point(243, 30);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(97, 13);
			this.Label1.TabIndex = 64;
			this.Label1.Text = "(support C4 scripts)";
			// 
			// QuestCacheScript
			// 
			this.QuestCacheScript.Location = new System.Drawing.Point(8, 45);
			this.QuestCacheScript.Name = "QuestCacheScript";
			this.QuestCacheScript.Size = new System.Drawing.Size(160, 23);
			this.QuestCacheScript.TabIndex = 63;
			this.QuestCacheScript.Text = "Generate CacheScript";
			this.QuestCacheScript.Click += new System.EventHandler(this.QuestCacheScript_Click);
			// 
			// Label2
			// 
			this.Label2.AutoSize = true;
			this.Label2.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label2.Location = new System.Drawing.Point(243, 16);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(134, 16);
			this.Label2.TabIndex = 62;
			this.Label2.Text = "Questcomp-E Maker";
			// 
			// ProgressBar
			// 
			this.ProgressBar.Location = new System.Drawing.Point(8, 91);
			this.ProgressBar.Name = "ProgressBar";
			this.ProgressBar.Size = new System.Drawing.Size(369, 23);
			this.ProgressBar.Step = 1;
			this.ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.ProgressBar.TabIndex = 60;
			// 
			// ButtonExit
			// 
			this.ButtonExit.Location = new System.Drawing.Point(286, 45);
			this.ButtonExit.Name = "ButtonExit";
			this.ButtonExit.Size = new System.Drawing.Size(91, 23);
			this.ButtonExit.TabIndex = 61;
			this.ButtonExit.Text = "Exit";
			this.ButtonExit.Click += new System.EventHandler(this.ButtonExit_Click);
			// 
			// MakeUndefinedBox
			// 
			this.MakeUndefinedBox.AutoSize = true;
			this.MakeUndefinedBox.Location = new System.Drawing.Point(174, 7);
			this.MakeUndefinedBox.Name = "MakeUndefinedBox";
			this.MakeUndefinedBox.Size = new System.Drawing.Size(73, 43);
			this.MakeUndefinedBox.TabIndex = 68;
			this.MakeUndefinedBox.Text = "Create\r\nundefined\r\nquest";
			this.ToolTip.SetToolTip(this.MakeUndefinedBox, "All quest not included in questdata-e\r\nwill be created and defined into\r\nquestpch" +
        "/pch config files.\r\nNew quest will be named\r\n[autoquestgen_QuestID]");
			this.MakeUndefinedBox.UseVisualStyleBackColor = true;
			// 
			// StatusLabel
			// 
			this.StatusLabel.AutoSize = true;
			this.StatusLabel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.StatusLabel.Location = new System.Drawing.Point(57, 75);
			this.StatusLabel.Name = "StatusLabel";
			this.StatusLabel.Size = new System.Drawing.Size(0, 14);
			this.StatusLabel.TabIndex = 67;
			// 
			// Label3
			// 
			this.Label3.AutoSize = true;
			this.Label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label3.Location = new System.Drawing.Point(12, 75);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(45, 14);
			this.Label3.TabIndex = 66;
			this.Label3.Text = "Status:";
			// 
			// QuestPchButton
			// 
			this.QuestPchButton.Location = new System.Drawing.Point(8, 16);
			this.QuestPchButton.Name = "QuestPchButton";
			this.QuestPchButton.Size = new System.Drawing.Size(160, 23);
			this.QuestPchButton.TabIndex = 65;
			this.QuestPchButton.Text = "Generate pch/pch2";
			this.QuestPchButton.Click += new System.EventHandler(this.QuestPchButton_Click);
			// 
			// QuestPchMaker
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(384, 121);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.QuestCacheScript);
			this.Controls.Add(this.Label2);
			this.Controls.Add(this.ProgressBar);
			this.Controls.Add(this.ButtonExit);
			this.Controls.Add(this.MakeUndefinedBox);
			this.Controls.Add(this.StatusLabel);
			this.Controls.Add(this.Label3);
			this.Controls.Add(this.QuestPchButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "QuestPchMaker";
			this.Text = "QuestPch/Pch2/Comp-e Builder";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.Button QuestCacheScript;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.ProgressBar ProgressBar;
		internal System.Windows.Forms.Button ButtonExit;
		internal System.Windows.Forms.OpenFileDialog OpenFileDialog;
		internal System.Windows.Forms.CheckBox MakeUndefinedBox;
		internal System.Windows.Forms.ToolTip ToolTip;
		internal System.Windows.Forms.Label StatusLabel;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.Button QuestPchButton;
	}
}