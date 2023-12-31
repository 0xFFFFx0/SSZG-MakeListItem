/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 07/19/2022
 * Time: 4:52 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SSZG_MakeListItem
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public string[] lstFiles;
		public List<string> lstItems = new List<string>();
		public Dictionary<string,string> dict_VN = new Dictionary<string, string>();
		public string FolderPath, DictPath;
		public string _new, fname, pth;
		
		public MainForm()
		{

			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void GetListItem(string sFile)
		{
			try
			{
				string[] tblData = File.ReadAllLines(sFile);
				int i = 0;
				while (i < tblData.Count())
				{
					//^--\s* / Check line is comment
					Regex reg_comment = new Regex(@"^--\s*"); 
					Match mat = reg_comment.Match(tblData[i].Trim());
					
				    if (!mat.Success)
				    {
				
						// [26512] = [[{26512, TI18N("6星水门(火影)"), 26912, 0, 3, 6, 9999, 5, 1, 0, {}, {{effect_type=27,val={30513,6,1}}}, {}, {}, TI18N("品质：<div fontcolor=#3dbf5f>UR</div>\n<div fontcolor=#aa6400>——可获得6星风系忍者-水门(火影)</div>"), 3, 0, 2, {}, 1, 6, 0, {}, TI18N("忍者"), "", 0, 0, 30513, 0}]],
						string sReg = @"\[\[\{\s*(?<id>\d*)\s*,\s*";
						sReg+= @"(TI18N\()*""(?<name>[^""]*)""(\))*";								
						Regex reg_base = new Regex(sReg);
						for (Match m = reg_base.Match(tblData[i]); m.Success; m = m.NextMatch ())
			            {
							string _id = m.Groups["id"].Value;
							string _name = m.Groups["name"].Value;
							if (dict_VN.ContainsKey(_name))
							{
								_name = dict_VN[_name];
							}
							lstItems.Add(String.Format("{0}|{1}",_id,_name));
			            }

				    }
					++i;
				}

			}
			catch (Exception ex) 
			{
				string err = ex.ToString();
				MessageBox.Show("Có lỗi xảy ra với file:\r\n" + sFile + "\r\n" +  err + "\r\nHãy chọn lại file cho đúng và thử lại!","Cảnh báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}
		
		
		public static string ThayText(string sInput, string sFind, string sReplace, bool bCase)
		{
			string result;
			if (bCase)
			{
				result = Regex.Replace(sInput, sFind, sReplace, RegexOptions.None);
			}
			else
			{
				result = Regex.Replace(sInput, sFind, sReplace, RegexOptions.IgnoreCase);
			}
			return result;
		}
		
		void ReplaceTextInFile(string sFile)
		{
			int i = 0; 
			int j = 0;
			try
			{
				string sFName = Path.GetFileName(sFile);
				string FolderInput = Path.GetDirectoryName(sFile);
				FolderInput = Path.GetDirectoryName(FolderInput);
				string[] tblIn = File.ReadAllText(sFile).Split(new string[] { "\r\n" },StringSplitOptions.None);
				
				for (i = 0; i < tblIn.Length; i++)
				{
					//Console.WriteLine("Dict total: {0}", dict_VN.Count());
					if(tblIn[i].Length>0)
					{
						string sReg = @"\?T\(""(?<txt_old>[^""]*)""\)";						
						Regex reg_base = new Regex(sReg);
						for (Match m = reg_base.Match(tblIn[i]); m.Success; m = m.NextMatch ())
			            {
							string old_text = m.Groups["txt_old"].Value;
							if (dict_VN.ContainsKey(old_text))
							{
								tblIn[i] = tblIn[i].Replace(old_text, dict_VN[old_text]);
							}
			            }
						
						string sReg2 = @"TI18N\(""(?<txt_old>[^""]*)""\)";						
						Regex reg_base2 = new Regex(sReg2);
						for (Match m = reg_base2.Match(tblIn[i]); m.Success; m = m.NextMatch ())
			            {
							string old_text = m.Groups["txt_old"].Value;
							if (dict_VN.ContainsKey(old_text))
							{
								tblIn[i] = tblIn[i].Replace(old_text, dict_VN[old_text]);
							}
			            }
						/*
			            foreach (var kv in dict_VN)                    // List file theo template
			            {
							tblIn[i] = tblIn[i].Replace(kv.Key, kv.Value);
							//tblIn[i] = ThayText(tblIn[i], kv.Key, kv.Value, true);
			            }   
			            */
			        }
					Console.WriteLine("Line: {0}", i);
					
				}
				
				string sText = string.Join("\r\n",tblIn);
				string FolderOut = FolderInput + "\\OUT_TXT";
				Directory.CreateDirectory(FolderOut);
				Export(Path.Combine(FolderOut,sFName), sText);
			}
			catch (Exception ex) 
			{
				string err = ex.ToString();
				string xxx = string.Format("Có lỗi xảy ra với file:\n\n{0}\n\nLine: {1}\n\nDict: {2}\n\nErr: ", sFile, i, j, err);
				MessageBox.Show(xxx,"Cảnh báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}
		
		private void Export(string filename, string sText)
		{
			string encode = "UTF-8";
			Encoding utf8WithoutBom = new UTF8Encoding(false);
			/*
			if (rdANSI.Checked) 
				encode = "windows-1252";
			else
				encode = "UTF-8";
			*/
			try
			{
				File.WriteAllText(filename, sText, utf8WithoutBom);
			}
			catch (Exception ex)
			{
				string err = ex.ToString();
				MessageBox.Show("Có lỗi xảy ra khi lưu file:\n\n" + filename + "\n\nHãy chọn lại file cho đúng và thử lại!","Cảnh báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}
		
		public void GetDict(string sFileIn)
		{
			List<string> dsFiles = new List<String>();
			string[] tblData = File.ReadAllLines(sFileIn);
			
			//string sReg = @"\['(?<key>[^\']*)']=";
			//sReg+= @"'(?<value>[\S ]*)'[,;]*";							
			string sReg = @"\[["",'](?<key>[^""]*)["",']]\s*=\s*";
			sReg+= @"["",'](?<value>[\S ]*)["",'][,;]*";											
			Regex reg_base = new Regex(sReg);

			foreach(string sLine in tblData)
			{
				for (Match m = reg_base.Match(sLine); m.Success; m = m.NextMatch ())
	            {
					string _key = m.Groups["key"].Value.Trim();
					string _value = m.Groups["value"].Value;
					if(!dict_VN.ContainsKey(_key) && _key != "")
					{
						dict_VN.Add(_key,_value);
					}
					else
					{
						dict_VN[_key] =_value;
					}
					
	            }
			}
			
		}
		
		
		public void GetAllDict()
		{
			List<string> dsDict = LayDanhSach(DictPath);
			dict_VN.Clear();
			foreach(string sFileDict in dsDict)
			{
				GetDict(sFileDict);
			}
			
		}
		
		public List<string> LayDanhSach(string _pth)
		{
			
			List<string> dsFiles = new List<String>();
			string[] _exts = {"*.*"};
			foreach(var ext in _exts)
			{
				dsFiles.AddRange(Directory.GetFiles(_pth,ext,SearchOption.AllDirectories));
			}
			return dsFiles;
		}
		
		void CmdSelectFolderItemClick(object sender, EventArgs e)
		{
			OpenFileDialog openFileDlg = new OpenFileDialog();
			openFileDlg.ValidateNames = false;
			openFileDlg.CheckFileExists = false;
			openFileDlg.CheckPathExists = true;
			openFileDlg.FileName = "Chọn thư mục";
			openFileDlg.Title = "Chọn thư mục cần xử lý";
			if (openFileDlg.ShowDialog()==DialogResult.OK)
			{
				txtFolderItem.Text = Path.GetDirectoryName(openFileDlg.FileName);				
			}
		}
		
		void CmdRunClick(object sender, EventArgs e)
		{
			FolderPath = txtFolderItem.Text.Trim();
			DictPath = txtLanguage.Text.Trim();
			GetAllDict();
			lstFiles = LayDanhSach(FolderPath).ToArray();
			lstItems.Clear();
		    foreach (string sFile in lstFiles)
		    {
		        GetListItem(sFile);		        
		    }
			var utf8WithoutBom = new System.Text.UTF8Encoding(false);
			File.WriteAllText(Path.Combine(FolderPath,"gzitem.txt"), String.Join("\r\n", lstItems.ToArray()), utf8WithoutBom);
			MessageBox.Show("Đã hoàn thành!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
		}
		void CmdSelectFolderLangClick(object sender, EventArgs e)
		{
			OpenFileDialog openFileDlg = new OpenFileDialog();
			openFileDlg.ValidateNames = false;
			openFileDlg.CheckFileExists = false;
			openFileDlg.CheckPathExists = true;
			openFileDlg.FileName = "Chọn thư mục";
			openFileDlg.Title = "Chọn thư mục chứa file ngôn ngữ";
			if (openFileDlg.ShowDialog()==DialogResult.OK)
			{
				txtLanguage.Text = Path.GetDirectoryName(openFileDlg.FileName);				
			}
		}
		void CmdReplaceTextClick(object sender, EventArgs e)
		{
			FolderPath = txtFolderItem.Text.Trim();
			DictPath = txtLanguage.Text.Trim();
			Console.WriteLine(DictPath);
			GetAllDict();
			lstFiles = LayDanhSach(FolderPath).ToArray();
			lstItems.Clear();
		    foreach (string sFile in lstFiles)
		    {
		        ReplaceTextInFile(sFile);		        
		    }
			//var utf8WithoutBom = new System.Text.UTF8Encoding(false);
			//File.WriteAllText(Path.Combine(FolderPath,"gzitem.txt"), String.Join("\r\n", lstItems.ToArray()), utf8WithoutBom);
			MessageBox.Show("Đã hoàn thành!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
		}

	}
}
