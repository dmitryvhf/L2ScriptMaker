namespace L2ScriptMaker.Modules.AI
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
			this.QuitButton = new System.Windows.Forms.Button();
			this.StartButton = new System.Windows.Forms.Button();
			this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.StatusStrip = new System.Windows.Forms.StatusStrip();
			this.ToolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
			this.NoLabelsCheckBox = new System.Windows.Forms.CheckBox();
			this.Label3 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.HandlerVariableCheckButton = new System.Windows.Forms.Button();
			this.StatusStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// QuitButton
			// 
			this.QuitButton.Location = new System.Drawing.Point(190, 85);
			this.QuitButton.Name = "QuitButton";
			this.QuitButton.Size = new System.Drawing.Size(75, 23);
			this.QuitButton.TabIndex = 53;
			this.QuitButton.Text = "Quit";
			this.QuitButton.UseVisualStyleBackColor = true;
			this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
			// 
			// StartButton
			// 
			this.StartButton.Location = new System.Drawing.Point(15, 42);
			this.StartButton.Name = "StartButton";
			this.StartButton.Size = new System.Drawing.Size(94, 37);
			this.StartButton.TabIndex = 52;
			this.StartButton.Text = "Handler Lines Amount";
			this.StartButton.UseVisualStyleBackColor = true;
			this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
			// 
			// StatusStrip
			// 
			this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripProgressBar});
			this.StatusStrip.Location = new System.Drawing.Point(0, 119);
			this.StatusStrip.Name = "StatusStrip";
			this.StatusStrip.Size = new System.Drawing.Size(274, 22);
			this.StatusStrip.TabIndex = 57;
			this.StatusStrip.Text = "StatusStrip1";
			// 
			// ToolStripProgressBar
			// 
			this.ToolStripProgressBar.Name = "ToolStripProgressBar";
			this.ToolStripProgressBar.Size = new System.Drawing.Size(250, 16);
			// 
			// NoLabelsCheckBox
			// 
			this.NoLabelsCheckBox.AutoSize = true;
			this.NoLabelsCheckBox.Location = new System.Drawing.Point(15, 85);
			this.NoLabelsCheckBox.Name = "NoLabelsCheckBox";
			this.NoLabelsCheckBox.Size = new System.Drawing.Size(118, 17);
			this.NoLabelsCheckBox.TabIndex = 56;
			this.NoLabelsCheckBox.Text = "No counting Labels";
			this.NoLabelsCheckBox.UseVisualStyleBackColor = true;
			// 
			// Label3
			// 
			this.Label3.AutoSize = true;
			this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label3.Location = new System.Drawing.Point(12, 22);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(97, 13);
			this.Label3.TabIndex = 55;
			this.Label3.Text = "(support C4 scripts)";
			// 
			// Label2
			// 
			this.Label2.AutoSize = true;
			this.Label2.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label2.Location = new System.Drawing.Point(12, 6);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(145, 16);
			this.Label2.TabIndex = 54;
			this.Label2.Text = "AI.obj Handler Cheker";
			// 
			// HandlerVariableCheckButton
			// 
			this.HandlerVariableCheckButton.Location = new System.Drawing.Point(154, 42);
			this.HandlerVariableCheckButton.Name = "HandlerVariableCheckButton";
			this.HandlerVariableCheckButton.Size = new System.Drawing.Size(111, 37);
			this.HandlerVariableCheckButton.TabIndex = 58;
			this.HandlerVariableCheckButton.Text = "Handler Variable Definitions";
			this.HandlerVariableCheckButton.UseVisualStyleBackColor = true;
			this.HandlerVariableCheckButton.Click += new System.EventHandler(this.HandlerVariableCheckButton_Click);
			// 
			// AIHandlersChecker
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(274, 141);
			this.Controls.Add(this.QuitButton);
			this.Controls.Add(this.StartButton);
			this.Controls.Add(this.StatusStrip);
			this.Controls.Add(this.NoLabelsCheckBox);
			this.Controls.Add(this.Label3);
			this.Controls.Add(this.Label2);
			this.Controls.Add(this.HandlerVariableCheckButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "AIHandlersChecker";
			this.Text = "Script check: AI Handlers";
			this.StatusStrip.ResumeLayout(false);
			this.StatusStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal System.Windows.Forms.Button QuitButton;
		internal System.Windows.Forms.Button StartButton;
		internal System.Windows.Forms.OpenFileDialog OpenFileDialog;
		internal System.Windows.Forms.StatusStrip StatusStrip;
		internal System.Windows.Forms.ToolStripProgressBar ToolStripProgressBar;
		internal System.Windows.Forms.CheckBox NoLabelsCheckBox;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.Button HandlerVariableCheckButton;
	}
}