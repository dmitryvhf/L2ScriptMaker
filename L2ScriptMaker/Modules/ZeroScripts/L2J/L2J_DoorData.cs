using L2ScriptMaker.Extensions;
using L2ScriptMaker.Extensions.VbCompatibleHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace L2ScriptMaker.Modules.ZeroScripts.L2J
{
	public partial class L2J_DoorData : Form
	{
		public L2J_DoorData()
		{
			InitializeComponent();
		}

		private struct doordata
		{

			// door_begin	[olympiad_door_154]	type=normal_type	editor_id=15120021	open_method=by_npc	close_time=600	height=150	hp=3258432	hp_showable=0	physical_defence=100000	pos={-145946;-181419;-3341}	range={{-145957;-181547;-3341};{-145932;-181547;-3341};{-145932;-181292;-3341};{-145956;-181292;-3341}}	default_status=close	door_end
			public string id;            // editor_id
			public string name;          // [olympiad_door_154]
			public string open_method;   // open_method
			public uint height;      // height=150
			public string hp;          // hp=3258432
			public string physical_defence;    // physical_defence=100000
			public string magical_defence;     // magical_defence=518
			public string pos;           // pos={-145946;-181419;-3341}
			public int posx;
			public int posy;
			public int posz;
			public string range;         // range={{-145957;-181547;-3341};{-145932;-181547;-3341};{-145932;-181292;-3341};{-145956;-181292;-3341}}
			public int range_minx;
			public int range_miny;
			public int range_minz;
			public int range_maxx;
			public int range_maxy;
			public int range_maxz;
		}

		private void ButtonPTS2L2J_Click(object sender, EventArgs e)
		{
			string sTemp;
			uint iTemp;

			System.IO.StreamReader inFile;
			System.IO.StreamWriter outFile;
			System.IO.StreamWriter outFile2;
			string[] aTemp;
			string[] aTemp2;
			var aDoor = new doordata[2];

			// LOADING itemdata-e.txt
			if (System.IO.File.Exists("doordata.txt") == false)
			{
				MessageBox.Show("doordata.txt not found", "Need doordata.txt", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			inFile = new System.IO.StreamReader("doordata.txt", System.Text.Encoding.Default, true, 1);
			outFile = new System.IO.StreamWriter("_doordata.sql", false, System.Text.Encoding.Default, 1);
			outFile2 = new System.IO.StreamWriter("_doordata_pos_update.sql", false, System.Text.Encoding.Default, 1);

			outFile.WriteLine("------------------------------------------------------");
			outFile.WriteLine("-- Script for INSERT doors for door storaged in DB");
			outFile.WriteLine("-- USE DB: fort_staticobjects");
			outFile.WriteLine("------------------------------------------------------");
			outFile.WriteLine("INSERT INTO `fort_staticobjects` VALUES");

			outFile2.WriteLine("------------------------------------------------------");
			outFile2.WriteLine("-- Script for UPDATE positions for door storaged in DB");
			outFile2.WriteLine("-- USE DB: castle_door, fort_staticobjects");
			outFile2.WriteLine("------------------------------------------------------");

			ToolStripProgressBar.Maximum = Conversions.ToInteger(inFile.BaseStream.Length);
			ToolStripStatusLabel.Text = "Loading doordata.txt ...";

			while (inFile.EndOfStream != true)
			{
				sTemp = inFile.ReadLine().Trim();
				ToolStripProgressBar.Value = Conversions.ToInteger(inFile.BaseStream.Position);
				if (sTemp.StartsWith("door_begin") == false)
					continue;

				aTemp = sTemp.Split((char)9);

				// ' door_begin	[olympiad_door_154]	type=normal_type	editor_id=15120021	open_method=by_npc	close_time=600	height=150	hp=3258432	hp_showable=0	physical_defence=100000	pos={-145946;-181419;-3341}	range={{-145957;-181547;-3341};{-145932;-181547;-3341};{-145932;-181292;-3341};{-145956;-181292;-3341}}	default_status=close	door_end
				// Dim id As String            ' editor_id
				// Dim name As String          ' [olympiad_door_154]
				// Dim open_method As String   ' open_method
				// Dim height As UInteger      ' height=150
				// Dim hp As UInteger          ' hp=3258432
				// Dim physical_defence As UInteger    ' physical_defence=100000
				// Dim magical_defence As UInteger     ' magical_defence=518	
				// Dim pos As String           ' pos={-145946;-181419;-3341}	
				// Dim range As String         ' range={{-145957;-181547;-3341};{-145932;-181547;-3341};{-145932;-181292;-3341};{-145956;-181292;-3341}}

				if ((Libraries.GetNeedParamFromStr(sTemp, "type") ?? "") != "normal_type")
					continue; // normal_type parent_type wall_type

				aDoor[0].id = Libraries.GetNeedParamFromStr(sTemp, "editor_id"); // .Replace("[", "").Replace("]", "")
				aDoor[0].name = aTemp[1].Replace("[", "").Replace("]", "");
				aDoor[0].open_method = Libraries.GetNeedParamFromStr(sTemp, "open_method");
				switch (aDoor[0].open_method)
				{
					case "by_npc":
						{
							aDoor[0].open_method = "false";
							break;
						}

					case "by_click":
						{
							aDoor[0].open_method = "true";
							break;
						}

					default:
						{
							// by_item, by_skill, by_time, by_time_skill
							aDoor[0].open_method = "false";
							break;
						}
				}
				aDoor[0].height = Conversions.ToUInteger(Conversions.Val(Libraries.GetNeedParamFromStr(sTemp, "height")));
				aDoor[0].hp = Libraries.GetNeedParamFromStr(sTemp, "hp");
				aDoor[0].physical_defence = Libraries.GetNeedParamFromStr(sTemp, "physical_defence");
				if (string.IsNullOrEmpty(aDoor[0].physical_defence))
					aDoor[0].physical_defence = "0";
				aDoor[0].magical_defence = Libraries.GetNeedParamFromStr(sTemp, "magical_defence");
				if (string.IsNullOrEmpty(aDoor[0].magical_defence))
					aDoor[0].magical_defence = "0";
				aDoor[0].pos = Libraries.GetNeedParamFromStr(sTemp, "pos");

				aTemp = aDoor[0].pos.Replace("{", "").Replace("}", "").Split(Conversions.ToChar(";"));
				aDoor[0].posx = Conversions.ToInteger(aTemp[0]);
				aDoor[0].posy = Conversions.ToInteger(aTemp[1]);
				aDoor[0].posz = Conversions.ToInteger(aTemp[2]);

				aDoor[0].range = Libraries.GetNeedParamFromStr(sTemp, "range");
				if (string.IsNullOrEmpty(aDoor[0].range))
					continue;
				aDoor[0].range = aDoor[0].range.Replace("};{", "|").Replace("{", "").Replace("}", "");
				aTemp = aDoor[0].range.Split(Conversions.ToChar("|"));
				var loopTo = Conversions.ToUInteger(aTemp.Length - 1);
				for (iTemp = 0; iTemp <= loopTo; iTemp++)
				{
					aTemp2 = aTemp[Conversions.ToInteger(iTemp)].Split(Conversions.ToChar(";"));
					if (iTemp == (long)0)
					{
						aDoor[0].range_minx = Conversions.ToInteger(aTemp2[0]);
						aDoor[0].range_miny = Conversions.ToInteger(aTemp2[0]);
						aDoor[0].range_minz = Conversions.ToInteger(aTemp2[1]);
						aDoor[0].range_maxx = Conversions.ToInteger(aTemp2[0]);
						aDoor[0].range_maxy = Conversions.ToInteger(aTemp2[1]);
						aDoor[0].range_maxz = Conversions.ToInteger(aTemp2[2]) + Conversions.ToInteger(aDoor[0].height);
					}

					if (Conversions.ToInteger(aTemp2[0]) < aDoor[0].range_minx)
						aDoor[0].range_minx = Conversions.ToInteger(aTemp2[0]);
					if (Conversions.ToInteger(aTemp2[1]) < aDoor[0].range_miny)
						aDoor[0].range_miny = Conversions.ToInteger(aTemp2[1]);
					if (Conversions.ToInteger(aTemp2[2]) < aDoor[0].range_minz)
						aDoor[0].range_minz = Conversions.ToInteger(aTemp2[2]);
					if (Conversions.ToInteger(aTemp2[0]) > aDoor[0].range_maxx)
						aDoor[0].range_maxx = Conversions.ToInteger(aTemp2[0]);
					if (Conversions.ToInteger(aTemp2[1]) > aDoor[0].range_maxy)
						aDoor[0].range_maxy = Conversions.ToInteger(aTemp2[1]);
					if (Conversions.ToInteger(aTemp2[2]) > aDoor[0].range_maxz)
						aDoor[0].range_maxz = Conversions.ToInteger(aTemp2[2]);
				}

				// ----------------
				// fort_staticobjects.sql 
				// ----------------
				// (113,18200001,'Fort Gate',-54247,89585,-2870,0,0,0,0,0,0,203652,644,518,'false','false',0),

				// (113,      18200001,'Fort Gate',           -54247,89585,-2870,0,0,0,0,0,0,203652,644,518,'false','false',0),
				// (fort_id,  18200001,'fortress_1820_001',   -54247,89585,-2870,0,0,0,0,0,0,169710,644,518,'false','false',0),


				// `fortId` tinyint(3) unsigned NOT NULL DEFAULT '0',   - 1
				// `id` int(8) unsigned NOT NULL DEFAULT '0',           - 2
				// `name` varchar(30) NOT NULL,                         - 3
				// `x` mediumint(6) NOT NULL DEFAULT '0',               - 4
				// `y` mediumint(6) NOT NULL DEFAULT '0',               - 5
				// `z` mediumint(6) NOT NULL DEFAULT '0',               - 6
				// `range_xmin` mediumint(6) NOT NULL DEFAULT '0',      - 7
				// `range_ymin` mediumint(6) NOT NULL DEFAULT '0',      - 8
				// `range_zmin` mediumint(6) NOT NULL DEFAULT '0',      - 9
				// `range_xmax` mediumint(6) NOT NULL DEFAULT '0',      - 10
				// `range_ymax` mediumint(6) NOT NULL DEFAULT '0',      - 11
				// `range_zmax` mediumint(6) NOT NULL DEFAULT '0',      - 12
				// `hp` mediumint(6) unsigned NOT NULL DEFAULT '0',     - 13
				// `pDef` mediumint(6) unsigned NOT NULL DEFAULT '0',   - 14
				// `mDef` mediumint(6) unsigned NOT NULL DEFAULT '0',   - 15
				// `openType` enum('true','false') NOT NULL DEFAULT 'false',        - 16
				// `commanderDoor` enum('true','false') NOT NULL DEFAULT 'false',   - 17
				// `objectType` tinyint(1) unsigned NOT NULL DEFAULT '0',           -18

				outFile.WriteLine("(fort_id,{0},'{1}',{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},'false',0),", aDoor[0].id, aDoor[0].name, aDoor[0].posx, aDoor[0].posy, aDoor[0].posz, aDoor[0].range_minx, aDoor[0].range_miny, aDoor[0].range_minz, aDoor[0].range_maxx, aDoor[0].range_maxy, aDoor[0].range_maxz, aDoor[0].hp, aDoor[0].physical_defence, aDoor[0].magical_defence, aDoor[0].open_method);

				outFile2.WriteLine("UPDATE `fort_staticobjects` SET x='{0}', y='{1}', z='{2}', range_xmin='{3}', range_ymin='{4}', range_zmin='{5}', range_xmax='{6}', range_ymax='{7}', range_zmax='{8}', hp='{9}', pDef='{10}', mDef='{11}', openType='{12}' WHERE id='{13}';", aDoor[0].posx, aDoor[0].posy, aDoor[0].posz, aDoor[0].range_minx, aDoor[0].range_miny, aDoor[0].range_minz, aDoor[0].range_maxx, aDoor[0].range_maxy, aDoor[0].range_maxz, aDoor[0].hp, aDoor[0].physical_defence, aDoor[0].magical_defence, aDoor[0].open_method, aDoor[0].id);
			}
			outFile.Flush(); outFile.Close();
			outFile2.Flush(); outFile2.Close();
			inFile.Close();
			ToolStripProgressBar.Value = 0;

			MessageBox.Show("Done");
		}

		private void ButtonQuit_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}
	}
}
