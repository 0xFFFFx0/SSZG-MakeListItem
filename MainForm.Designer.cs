/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 07/19/2022
 * Time: 4:52 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace SSZG_MakeListItem
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button cmdSelectFolderItem;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtFolderItem;
		private System.Windows.Forms.Button cmdRun;
		private System.Windows.Forms.TextBox txtLanguage;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button cmdSelectFolderLang;
		private System.Windows.Forms.Button cmdReplaceText;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.cmdSelectFolderItem = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.txtFolderItem = new System.Windows.Forms.TextBox();
			this.cmdRun = new System.Windows.Forms.Button();
			this.txtLanguage = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.cmdSelectFolderLang = new System.Windows.Forms.Button();
			this.cmdReplaceText = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// cmdSelectFolderItem
			// 
			this.cmdSelectFolderItem.Location = new System.Drawing.Point(336, 38);
			this.cmdSelectFolderItem.Name = "cmdSelectFolderItem";
			this.cmdSelectFolderItem.Size = new System.Drawing.Size(75, 23);
			this.cmdSelectFolderItem.TabIndex = 14;
			this.cmdSelectFolderItem.Text = "Chọn";
			this.cmdSelectFolderItem.UseVisualStyleBackColor = true;
			this.cmdSelectFolderItem.Click += new System.EventHandler(this.CmdSelectFolderItemClick);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(12, 15);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(163, 23);
			this.label3.TabIndex = 13;
			this.label3.Text = "Chọn folder chứa file item";
			// 
			// txtFolderItem
			// 
			this.txtFolderItem.Location = new System.Drawing.Point(12, 41);
			this.txtFolderItem.Name = "txtFolderItem";
			this.txtFolderItem.Size = new System.Drawing.Size(300, 20);
			this.txtFolderItem.TabIndex = 12;
			// 
			// cmdRun
			// 
			this.cmdRun.Location = new System.Drawing.Point(12, 132);
			this.cmdRun.Name = "cmdRun";
			this.cmdRun.Size = new System.Drawing.Size(184, 54);
			this.cmdRun.TabIndex = 15;
			this.cmdRun.Text = "TẠO LIST ITEM";
			this.cmdRun.UseVisualStyleBackColor = true;
			this.cmdRun.Click += new System.EventHandler(this.CmdRunClick);
			// 
			// txtLanguage
			// 
			this.txtLanguage.Location = new System.Drawing.Point(12, 94);
			this.txtLanguage.Name = "txtLanguage";
			this.txtLanguage.Size = new System.Drawing.Size(300, 20);
			this.txtLanguage.TabIndex = 16;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 68);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(163, 23);
			this.label1.TabIndex = 17;
			this.label1.Text = "Chọn folder language";
			// 
			// cmdSelectFolderLang
			// 
			this.cmdSelectFolderLang.Location = new System.Drawing.Point(336, 92);
			this.cmdSelectFolderLang.Name = "cmdSelectFolderLang";
			this.cmdSelectFolderLang.Size = new System.Drawing.Size(75, 23);
			this.cmdSelectFolderLang.TabIndex = 18;
			this.cmdSelectFolderLang.Text = "Chọn";
			this.cmdSelectFolderLang.UseVisualStyleBackColor = true;
			this.cmdSelectFolderLang.Click += new System.EventHandler(this.CmdSelectFolderLangClick);
			// 
			// cmdReplaceText
			// 
			this.cmdReplaceText.Location = new System.Drawing.Point(227, 132);
			this.cmdReplaceText.Name = "cmdReplaceText";
			this.cmdReplaceText.Size = new System.Drawing.Size(184, 54);
			this.cmdReplaceText.TabIndex = 19;
			this.cmdReplaceText.Text = "REPLACE TEXT";
			this.cmdReplaceText.UseVisualStyleBackColor = true;
			this.cmdReplaceText.Click += new System.EventHandler(this.CmdReplaceTextClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(424, 202);
			this.Controls.Add(this.cmdReplaceText);
			this.Controls.Add(this.cmdSelectFolderLang);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtLanguage);
			this.Controls.Add(this.cmdRun);
			this.Controls.Add(this.cmdSelectFolderItem);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtFolderItem);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "SSZG_MakeListItem + replace text - v2022.10.01 b3";
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
