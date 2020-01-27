namespace L2ScriptMaker.Modules.Items
{
	partial class ItemDefaultPrice
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
			this.ButtonQuit = new System.Windows.Forms.Button();
			this.DefaultItem = new System.Windows.Forms.Label();
			this.DefaultItemPrice = new System.Windows.Forms.TextBox();
			this.Label5 = new System.Windows.Forms.Label();
			this.ShopPrice = new System.Windows.Forms.TextBox();
			this.Label4 = new System.Windows.Forms.Label();
			this.CastleTax = new System.Windows.Forms.TextBox();
			this.Label3 = new System.Windows.Forms.Label();
			this.TownTax = new System.Windows.Forms.TextBox();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// ButtonQuit
			// 
			this.ButtonQuit.Location = new System.Drawing.Point(279, 114);
			this.ButtonQuit.Name = "ButtonQuit";
			this.ButtonQuit.Size = new System.Drawing.Size(75, 23);
			this.ButtonQuit.TabIndex = 22;
			this.ButtonQuit.Text = "Quit";
			this.ButtonQuit.UseVisualStyleBackColor = true;
			this.ButtonQuit.Click += new System.EventHandler(this.ButtonQuit_Click);
			// 
			// DefaultItem
			// 
			this.DefaultItem.AutoSize = true;
			this.DefaultItem.Location = new System.Drawing.Point(253, 49);
			this.DefaultItem.Name = "DefaultItem";
			this.DefaultItem.Size = new System.Drawing.Size(67, 13);
			this.DefaultItem.TabIndex = 21;
			this.DefaultItem.Text = "Default Item:";
			// 
			// DefaultItemPrice
			// 
			this.DefaultItemPrice.Location = new System.Drawing.Point(253, 65);
			this.DefaultItemPrice.Name = "DefaultItemPrice";
			this.DefaultItemPrice.Size = new System.Drawing.Size(100, 20);
			this.DefaultItemPrice.TabIndex = 20;
			this.DefaultItemPrice.Leave += new System.EventHandler(this.DefaultItemPrice_Leave);
			// 
			// Label5
			// 
			this.Label5.AutoSize = true;
			this.Label5.Location = new System.Drawing.Point(134, 49);
			this.Label5.Name = "Label5";
			this.Label5.Size = new System.Drawing.Size(61, 13);
			this.Label5.TabIndex = 19;
			this.Label5.Text = "Shop price:";
			// 
			// ShopPrice
			// 
			this.ShopPrice.Location = new System.Drawing.Point(134, 65);
			this.ShopPrice.Name = "ShopPrice";
			this.ShopPrice.Size = new System.Drawing.Size(100, 20);
			this.ShopPrice.TabIndex = 18;
			this.ShopPrice.Leave += new System.EventHandler(this.ShopPrice_Leave);
			// 
			// Label4
			// 
			this.Label4.AutoSize = true;
			this.Label4.Location = new System.Drawing.Point(10, 88);
			this.Label4.Name = "Label4";
			this.Label4.Size = new System.Drawing.Size(97, 13);
			this.Label4.TabIndex = 17;
			this.Label4.Text = "Castle City tax rate:";
			// 
			// CastleTax
			// 
			this.CastleTax.Location = new System.Drawing.Point(10, 104);
			this.CastleTax.Name = "CastleTax";
			this.CastleTax.Size = new System.Drawing.Size(100, 20);
			this.CastleTax.TabIndex = 16;
			this.CastleTax.Leave += new System.EventHandler(this.CastleTax_Leave);
			// 
			// Label3
			// 
			this.Label3.AutoSize = true;
			this.Label3.Location = new System.Drawing.Point(10, 49);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(95, 13);
			this.Label3.TabIndex = 15;
			this.Label3.Text = "Town City tax rate:";
			// 
			// TownTax
			// 
			this.TownTax.Location = new System.Drawing.Point(10, 65);
			this.TownTax.Name = "TownTax";
			this.TownTax.Size = new System.Drawing.Size(100, 20);
			this.TownTax.TabIndex = 14;
			this.TownTax.Leave += new System.EventHandler(this.TownTax_Leave);
			// 
			// Label2
			// 
			this.Label2.AutoSize = true;
			this.Label2.Location = new System.Drawing.Point(103, 23);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(135, 13);
			this.Label2.TabIndex = 13;
			this.Label2.Text = "and Shop price for this item";
			// 
			// Label1
			// 
			this.Label1.AutoSize = true;
			this.Label1.Location = new System.Drawing.Point(10, 10);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(344, 13);
			this.Label1.TabIndex = 12;
			this.Label1.Text = "Tool for find default_price from known Castle Tax Rate, Town Tax Rate";
			// 
			// ItemDefaultPrice
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(364, 146);
			this.Controls.Add(this.ButtonQuit);
			this.Controls.Add(this.DefaultItem);
			this.Controls.Add(this.DefaultItemPrice);
			this.Controls.Add(this.Label5);
			this.Controls.Add(this.ShopPrice);
			this.Controls.Add(this.Label4);
			this.Controls.Add(this.CastleTax);
			this.Controls.Add(this.Label3);
			this.Controls.Add(this.TownTax);
			this.Controls.Add(this.Label2);
			this.Controls.Add(this.Label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "ItemDefaultPrice";
			this.Text = "DefaultPrice finder tool";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal System.Windows.Forms.Button ButtonQuit;
		internal System.Windows.Forms.Label DefaultItem;
		internal System.Windows.Forms.TextBox DefaultItemPrice;
		internal System.Windows.Forms.Label Label5;
		internal System.Windows.Forms.TextBox ShopPrice;
		internal System.Windows.Forms.Label Label4;
		internal System.Windows.Forms.TextBox CastleTax;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.TextBox TownTax;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.Label Label1;
	}
}