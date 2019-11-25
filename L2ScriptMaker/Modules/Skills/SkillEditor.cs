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

namespace L2ScriptMaker.Modules.Skills
{
	public partial class SkillEditor : Form
	{
		public SkillEditor()
		{
			InitializeComponent();
		}

		public struct Skill
		{
			public string skill_name;
			public int skill_id;
			public string comment;
			public short level;
			public string operate_type;
			public short magic_level;
			public string effect;
			public bool is_magic;

			public int mp_consume1;
			public int mp_consume2;
			public int hp_consume;

			public string itemconsume;

			public int skill_hit_time;
			public int skill_cool_time;
			public int skill_hit_cancel_time;
			public int reuse_delay;

			public string operate_cond;
			public string unavailable_cond;

			public int cast_range;
			public int effective_range;
			public string attribute;
			public int effect_point;
			public string target_type;

			public int abnormal_lv;
			public int abnormal_time;
			public int activate_rate;
			public int lv_bonus_rate;
			public string basic_property;
			public int abnormal_type;
			public string abnormal_visual_effect;

			public int affect_scope;
			public int affect_object;
			public int affect_range;

			public int fan_range;

			public string next_action;
		}


		private char TabSym = (char)9;

		private void QuitButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void StartButton_Click(object sender, EventArgs e)
		{
			if (AutoClear.Checked == true)
				SkillOutBox.Text = "";

			SkillOutBox.Text += "skill_begin" + Conversions.ToString(TabSym);
			if (!string.IsNullOrEmpty(skillname.Text))
				SkillOutBox.Text += "skill_name=[" + skillname.Text + "]" + Conversions.ToString(TabSym);
			else
			{
				showUndefinedParam("skill_name");
				return;
			}
			if (!string.IsNullOrEmpty(comment.Text))
				SkillOutBox.Text += "/* " + comment.Text + " */" + Conversions.ToString(TabSym);
			if (!string.IsNullOrEmpty(skillid.Text))
				SkillOutBox.Text += "skill_id=" + skillid.Text + Conversions.ToString(TabSym);
			else
			{
				showUndefinedParam("skill_id");
				return;
			}

			if (!string.IsNullOrEmpty(skilllevel.Text))
				SkillOutBox.Text += "level=" + skilllevel.Text + Conversions.ToString(TabSym);
			else
			{
				showUndefinedParam("level");
				return;
			}
			if (!string.IsNullOrEmpty(operatetype.Text))
				SkillOutBox.Text += "operate_type=" + operatetype.Text + Conversions.ToString(TabSym);
			if (!string.IsNullOrEmpty(magiclevel.Text))
				SkillOutBox.Text += "magic_level=" + magiclevel.Text + Conversions.ToString(TabSym);
			else
			{
				showUndefinedParam("magic_level");
				return;
			}
			if (!string.IsNullOrEmpty(effect.Text))
				SkillOutBox.Text += "effect={" + effect.Text + "}" + Conversions.ToString(TabSym);
			if (!string.IsNullOrEmpty(ismagic.Text))
				SkillOutBox.Text += "is_magic=" + ismagic.Text + Conversions.ToString(TabSym);

			if (!string.IsNullOrEmpty(mp1.Text))
				SkillOutBox.Text += "mp_consume1=" + mp1.Text + Conversions.ToString(TabSym);
			if (!string.IsNullOrEmpty(mp2.Text))
				SkillOutBox.Text += "mp_consume2=" + mp2.Text + Conversions.ToString(TabSym);
			if (!string.IsNullOrEmpty(hp.Text))
				SkillOutBox.Text += "hp_consume=" + hp.Text + Conversions.ToString(TabSym);
			if (!string.IsNullOrEmpty(itemconsume.Text))
				SkillOutBox.Text += "itemconsume={" + itemconsume.Text + "}" + Conversions.ToString(TabSym);

			if (!string.IsNullOrEmpty(skillhittime.Text))
				SkillOutBox.Text += "skill_hit_time=" + skillhittime.Text + Conversions.ToString(TabSym);
			if (!string.IsNullOrEmpty(skillcooltime.Text))
				SkillOutBox.Text += "skill_cool_time=" + skillcooltime.Text + Conversions.ToString(TabSym);
			if (!string.IsNullOrEmpty(skillhitcanceltime.Text))
				SkillOutBox.Text += "skill_hit_cancel_time=" + skillhitcanceltime.Text + Conversions.ToString(TabSym);
			if (!string.IsNullOrEmpty(reusedelay.Text))
				SkillOutBox.Text += "reuse_delay=" + reusedelay.Text + Conversions.ToString(TabSym);

			if (!string.IsNullOrEmpty(operatecond.Text))
				SkillOutBox.Text += "operate_cond={" + operatecond.Text + "}" + Conversions.ToString(TabSym);
			if (!string.IsNullOrEmpty(unavcond.Text))
				SkillOutBox.Text += "unavailable_cond={" + unavcond.Text + "}" + Conversions.ToString(TabSym);

			if (!string.IsNullOrEmpty(castrange.Text))
				SkillOutBox.Text += "cast_range=" + castrange.Text + Conversions.ToString(TabSym);
			if (!string.IsNullOrEmpty(effectrange.Text))
				SkillOutBox.Text += "effective_range=" + effectrange.Text + Conversions.ToString(TabSym);
			if (!string.IsNullOrEmpty(attribute.Text))
				SkillOutBox.Text += "attribute=" + attribute.Text + Conversions.ToString(TabSym);
			if (!string.IsNullOrEmpty(effectpoint.Text))
				SkillOutBox.Text += "effect_point=" + effectpoint.Text + Conversions.ToString(TabSym);
			if (!string.IsNullOrEmpty(targettype.Text))
				SkillOutBox.Text += "target_type=" + targettype.Text + Conversions.ToString(TabSym);

			if (!string.IsNullOrEmpty(abnormallv.Text))
				SkillOutBox.Text += "abnormal_lv=" + abnormallv.Text + Conversions.ToString(TabSym);
			if (!string.IsNullOrEmpty(abnormaltime.Text))
				SkillOutBox.Text += "abnormal_time=" + abnormaltime.Text + Conversions.ToString(TabSym);
			if (!string.IsNullOrEmpty(activaterate.Text))
				SkillOutBox.Text += "activate_rate=" + activaterate.Text + Conversions.ToString(TabSym);
			if (!string.IsNullOrEmpty(lvbonusrate.Text))
				SkillOutBox.Text += "lv_bonus_rate=" + lvbonusrate.Text + Conversions.ToString(TabSym);
			if (!string.IsNullOrEmpty(basicprop.Text))
				SkillOutBox.Text += "basic_property=" + basicprop.Text + Conversions.ToString(TabSym);
			if (!string.IsNullOrEmpty(abnormaltype.Text))
				SkillOutBox.Text += "abnormal_type=" + abnormaltype.Text + Conversions.ToString(TabSym);
			if (!string.IsNullOrEmpty(abnormalviseffect.Text))
				SkillOutBox.Text += "abnormal_visual_effect=" + abnormalviseffect.Text + Conversions.ToString(TabSym);

			if (!string.IsNullOrEmpty(affectscope.Text))
				SkillOutBox.Text += "affect_scope=" + affectscope.Text + Conversions.ToString(TabSym);
			if (!string.IsNullOrEmpty(affectobject.Text))
				SkillOutBox.Text += "affect_object=" + affectobject.Text + Conversions.ToString(TabSym);
			if (!string.IsNullOrEmpty(affectrange.Text))
				SkillOutBox.Text += "affect_range=" + affectrange.Text + Conversions.ToString(TabSym);

			if (!string.IsNullOrEmpty(fanrange.Text))
				SkillOutBox.Text += "fan_range=" + fanrange.Text + Conversions.ToString(TabSym);

			if (!string.IsNullOrEmpty(nextaction.Text))
				SkillOutBox.Text += "next_action=" + nextaction.Text + Conversions.ToString(TabSym);

			SkillOutBox.Text += "skill_end" + Constants.vbNewLine;
		}

		private void ClearButton_Click(object sender, EventArgs e)
		{
			skillname.Text = "";
			comment.Text = "";
			skillid.Text = "";
			skilllevel.Text = "";
			operatetype.Text = "";
			magiclevel.Text = "";
			effect.Text = "";
			ismagic.Text = "";
			mp1.Text = "";
			mp2.Text = "";
			hp.Text = "";
			itemconsume.Text = "";
			skillhittime.Text = "";
			skillcooltime.Text = "";
			skillhitcanceltime.Text = "";
			reusedelay.Text = "";
			operatecond.Text = "";
			unavcond.Text = "";
			castrange.Text = "";
			effectrange.Text = "";
			attribute.Text = "";
			effectpoint.Text = "";
			targettype.Text = "";
			abnormallv.Text = "";
			abnormaltime.Text = "";
			activaterate.Text = "";
			lvbonusrate.Text = "";
			basicprop.Text = "";
			abnormaltype.Text = "";
			abnormalviseffect.Text = "";
			affectscope.Text = "";
			affectobject.Text = "";
			affectrange.Text = "";
			fanrange.Text = "";
			nextaction.Text = "";

			SkillOutBox.Text = "";
		}

		private void ImportButton_Click(object sender, EventArgs e)
		{
			skillname.Text = GetNeedParamFromStr(SkillOutBox.Text, "skill_name");
			skillname.Text = Strings.Mid(skillname.Text, 2, Strings.Len(skillname.Text) - 2);
			if (Strings.InStr(SkillOutBox.Text, "/*") != 0)
				comment.Text = Strings.Trim(Strings.Mid(SkillOutBox.Text, Strings.InStr(SkillOutBox.Text, "/*") + 2, Strings.InStr(SkillOutBox.Text, "*/") - Strings.InStr(SkillOutBox.Text, "/*") - 2));
			skillid.Text = GetNeedParamFromStr(SkillOutBox.Text, "skill_id");
			skilllevel.Text = GetNeedParamFromStr(SkillOutBox.Text, "level");
			operatetype.Text = GetNeedParamFromStr(SkillOutBox.Text, "operate_type");
			magiclevel.Text = GetNeedParamFromStr(SkillOutBox.Text, "magic_level");
			effect.Text = GetNeedParamFromStr(SkillOutBox.Text, "effect");
			if (!string.IsNullOrEmpty(effect.Text))
				effect.Text = Strings.Mid(effect.Text, 2, Strings.Len(effect.Text) - 2);
			ismagic.Text = GetNeedParamFromStr(SkillOutBox.Text, "is_magic");
			mp1.Text = GetNeedParamFromStr(SkillOutBox.Text, "mp_consume1");
			mp2.Text = GetNeedParamFromStr(SkillOutBox.Text, "mp_consume2");
			hp.Text = GetNeedParamFromStr(SkillOutBox.Text, "hp_consume");
			itemconsume.Text = GetNeedParamFromStr(SkillOutBox.Text, "itemconsume");
			if (!string.IsNullOrEmpty(itemconsume.Text))
				itemconsume.Text = Strings.Mid(itemconsume.Text, 2, Strings.Len(itemconsume.Text) - 2);
			skillhittime.Text = GetNeedParamFromStr(SkillOutBox.Text, "skill_hit_time");
			skillcooltime.Text = GetNeedParamFromStr(SkillOutBox.Text, "skill_cool_time");
			skillhitcanceltime.Text = GetNeedParamFromStr(SkillOutBox.Text, "skill_hit_cancel_time");
			reusedelay.Text = GetNeedParamFromStr(SkillOutBox.Text, "reuse_delay");
			operatecond.Text = GetNeedParamFromStr(SkillOutBox.Text, "operate_cond");
			if (!string.IsNullOrEmpty(operatecond.Text))
				operatecond.Text = Strings.Mid(operatecond.Text, 2, Strings.Len(operatecond.Text) - 2);
			unavcond.Text = GetNeedParamFromStr(SkillOutBox.Text, "unavailable_cond");
			if (!string.IsNullOrEmpty(unavcond.Text))
				unavcond.Text = Strings.Mid(unavcond.Text, 2, Strings.Len(unavcond.Text) - 2);
			castrange.Text = GetNeedParamFromStr(SkillOutBox.Text, "cast_range");
			effectrange.Text = GetNeedParamFromStr(SkillOutBox.Text, "effective_range");
			attribute.Text = GetNeedParamFromStr(SkillOutBox.Text, "attribute");
			effectpoint.Text = GetNeedParamFromStr(SkillOutBox.Text, "effect_point");
			targettype.Text = GetNeedParamFromStr(SkillOutBox.Text, "target_type");
			abnormallv.Text = GetNeedParamFromStr(SkillOutBox.Text, "abnormal_lv");
			abnormaltime.Text = GetNeedParamFromStr(SkillOutBox.Text, "abnormal_time");
			activaterate.Text = GetNeedParamFromStr(SkillOutBox.Text, "activate_rate");
			lvbonusrate.Text = GetNeedParamFromStr(SkillOutBox.Text, "lv_bonus_rate");
			basicprop.Text = GetNeedParamFromStr(SkillOutBox.Text, "basic_property");
			abnormaltype.Text = GetNeedParamFromStr(SkillOutBox.Text, "abnormal_type");
			abnormalviseffect.Text = GetNeedParamFromStr(SkillOutBox.Text, "abnormal_visual_effect");
			affectscope.Text = GetNeedParamFromStr(SkillOutBox.Text, "affect_scope");
			affectobject.Text = GetNeedParamFromStr(SkillOutBox.Text, "affect_object");
			affectrange.Text = GetNeedParamFromStr(SkillOutBox.Text, "affect_range");
			fanrange.Text = GetNeedParamFromStr(SkillOutBox.Text, "fan_range");
			nextaction.Text = GetNeedParamFromStr(SkillOutBox.Text, "next_action");
		}

		public string GetNeedParamFromStr(string SourceStr, string MaskStr)
		{
			string GetNeedParamFromStrRet = default(string);

			// Update 15.01.2007 00:05

			int FirstPos, SecondPos;
			GetNeedParamFromStrRet = "";

			// PreWorking string
			SourceStr = SourceStr.Replace(Conversions.ToString((char)9), " ");
			SourceStr = SourceStr.Replace(" = ", "=");
			while (Strings.InStr(SourceStr, "  ") > 0)
				SourceStr = SourceStr.Replace("  ", " ");

			FirstPos = Strings.InStr(1, SourceStr, MaskStr + "=");
			if (FirstPos == default(int))
			{
				GetNeedParamFromStrRet = "";
				return GetNeedParamFromStrRet;
			}
			FirstPos += MaskStr.Length;
			SecondPos = FirstPos + 1;
			SecondPos = Strings.InStr(SecondPos, SourceStr, " ");
			if (SecondPos == 0)
				SecondPos = SourceStr.Length;

			GetNeedParamFromStrRet = Strings.Trim(Strings.Mid(SourceStr, FirstPos + 1, SecondPos - FirstPos));
			return GetNeedParamFromStrRet;
		}

		public void showUndefinedParam(string ParamName)
		{
			MessageBox.Show("Must defined '" + ParamName + "' parameter for complete.", "Not defined", MessageBoxButtons.OK, MessageBoxIcon.Error);
			SkillOutBox.Text = "";
		}

		private void mp1_TextChanged(object sender, EventArgs e)
		{
			mp_summ.Text = Conversions.ToString(Conversions.Val(mp1.Text) + Conversions.Val(mp2.Text));
		}
		private void mp2_TextChanged(object sender, EventArgs e)
		{
			mp_summ.Text = Conversions.ToString(Conversions.Val(mp1.Text) + Conversions.Val(mp2.Text));
		}
	}
}
