using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using L2ScriptMaker.Modules.AI;
using L2ScriptMaker.Modules.Geodata;
using L2ScriptMaker.Modules.Items;
using L2ScriptMaker.Modules.Npc;
using L2ScriptMaker.Modules.Others;
using L2ScriptMaker.Modules.Scripts;
using L2ScriptMaker.Modules.Skills;
using L2ScriptMaker.Modules.ZeroScripts;
using L2ScriptMaker.Modules.ZeroScripts.L2J;
using SkillPch2Maker = L2ScriptMaker.Forms.Modules.Skills.SkillPch2Maker;

namespace L2ScriptMaker
{
	public partial class WelcomeForm : Form
	{
		public WelcomeForm()
		{
			InitializeComponent();
		}

		private void ButtonAbout_Click(object sender, EventArgs e)
		{
			new AboutBox().ShowDialog();
		}

		private void QuitButton_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void CheckUpdateButton_Click(object sender, EventArgs e)
		{
			new CheckUpdate().ShowDialog();
		}

		#region AI
		private void AIDecompilerPackButton_Click(object sender, EventArgs e)
		{
			new AIDecompilerPack().ShowDialog();
		}

		private void AIDecompilerButton_Click(object sender, EventArgs e)
		{
			new AIDecompiler().ShowDialog();
		}

		private void AIbuyselllistEditorButton_Click(object sender, EventArgs e)
		{
			new AIbuyselllistEditor().ShowDialog();
		}

		private void ButtonAiFixer_Click(object sender, EventArgs e)
		{
			new AiFixer().ShowDialog();
		}

		private void CheckAIHandlerButton_Click(object sender, EventArgs e)
		{
			new AIHandlersChecker().ShowDialog();
		}

		private void ButtonAiInjector_Click(object sender, EventArgs e)
		{
			new AiInjector().ShowDialog();
		}

		private void ButtonAIMessageImporter_Click(object sender, EventArgs e)
		{
			new AIMessageImporter().ShowDialog();
		}

		private void ButtonAIMessageTeleportImporter_Click(object sender, EventArgs e)
		{
			new AIMessageTeleportImporter().ShowDialog();
		}

		private void ButtonAiParamsNpcdataChecker_Click(object sender, EventArgs e)
		{
			new AiParamsNpcdataChecker().ShowDialog();
		}

		private void AIRaidPosGeneratorButton_Click(object sender, EventArgs e)
		{
			new AIRaidPosGenerator().ShowDialog();
		}

		private void ButtonAiRateChanger_Click(object sender, EventArgs e)
		{
			new AiRateChanger().ShowDialog();
		}
		#endregion

		#region GeoData
		private void GeoGetTestPointButton_Click(object sender, EventArgs e)
		{
			new GeoGetTestPoint().ShowDialog();
		}

		private void Button6_Click(object sender, EventArgs e)
		{
			new GeoIndexGen().ShowDialog();
		}

		private void GeonameLocationButton_Click(object sender, EventArgs e)
		{
			new GeoLocConverter().ShowDialog();
		}

		private void NullPosFixerButton_Click(object sender, EventArgs e)
		{
			new LogDNullPosFixer().ShowDialog();
		}
		#endregion

		#region Items
		private void ItemDataFixerButton_Click(object sender, EventArgs e)
		{
			new ItemDataFixer().ShowDialog();
		}

		private void DefaultPriceButton_Click(object sender, EventArgs e)
		{
			new ItemDefaultPrice().ShowDialog();
		}

		private void ItemInjectorButton_Click(object sender, EventArgs e)
		{
			new ItemInjector().ShowDialog();
		}

		private void ButtonItemPchMaker_Click(object sender, EventArgs e)
		{
			new ItemPchMaker().ShowDialog();
		}
		#endregion

		#region NPC
		private void NpcPchMakerButton_Click(object sender, EventArgs e)
		{
			// new NpcPchMaker().ShowDialog();
			new L2ScriptMaker.Forms.Modules.Npc.NpcPchMaker().ShowDialog();
		}

		private void NpcC4toC5IdsConversionButton_Click(object sender, EventArgs e)
		{
			new NpcC4toC5IdsConversion().ShowDialog();
		}

		private void NpcDataCheckerButton_Click(object sender, EventArgs e)
		{
			new NpcDataChecker().ShowDialog();
		}

		private void NpcDataCollisionFixButton_Click(object sender, EventArgs e)
		{
			new NpcDataCollisionFix().ShowDialog();
		}

		private void HerbMobGeneratorButton_Click(object sender, EventArgs e)
		{
			new NpcDataHerbMobs().ShowDialog();
		}

		private void NpcSkillFixButton_Click(object sender, EventArgs e)
		{
			new NpcDataPassiveSkillFix().ShowDialog();
		}

		private void NpcSkillFixC6Button_Click(object sender, EventArgs e)
		{
			new NpcDataPassiveSkillFixC6().ShowDialog();
		}

		private void NpcdataRateReBuilderButton_Click(object sender, EventArgs e)
		{
			new NpcdataRateReBuilder().ShowDialog();
		}

		private void NpcDropItemCheckerButton_Click(object sender, EventArgs e)
		{
			new NpcDropItemChecker().ShowDialog();
		}

		private void NpcInjectorButton_Click(object sender, EventArgs e)
		{
			new NpcInjector().ShowDialog();
		}

		private void NpcPosButton_Click(object sender, EventArgs e)
		{
			new NpcPosAreaMaker().ShowDialog();
		}

		private void NpcPrivatesButton_Click(object sender, EventArgs e)
		{
			new NpcPosChecker().ShowDialog();
		}

		private void NpcposManorZoneGeneratorButton_Click(object sender, EventArgs e)
		{
			new NpcposManorZoneGenerator().ShowDialog();
		}

		private void NpcPosShifterButton_Click(object sender, EventArgs e)
		{
			new NpcPosShifter().ShowDialog();
		}

		private void ButtonNpcposMap_Click(object sender, EventArgs e)
		{
			new NpcposMap().ShowDialog();
		}

		private void NpcDataMakerButton_Click(object sender, EventArgs e)
		{
			new NpcDataMaker().ShowDialog();
		}
		#endregion

		#region Others
		private void AreaDataButton_Click(object sender, EventArgs e)
		{
			new AreaDataGenerator().ShowDialog();
		}

		private void ButtonDoorAreaMaker_Click(object sender, EventArgs e)
		{
			new DoorMakerForm().ShowDialog();
		}

		private void EventDataEditorButton_Click(object sender, EventArgs e)
		{
			new EventDataEditor().ShowDialog();
		}

		private void ExecInjectorButton_Click(object sender, EventArgs e)
		{
			new ExecInjector().ShowDialog();
		}

		private void ExecL2AuthButton_Click(object sender, EventArgs e)
		{
			new ExecL2AuthKey().ShowDialog();
		}

		private void ButtonHtmlButtonDesigner_Click(object sender, EventArgs e)
		{
			new HtmlButtonDesigner().ShowDialog();
		}

		private void ButtonHtmlDesigner_Click(object sender, EventArgs e)
		{
			new HtmlDesigner().ShowDialog();
		}

		private void HtmlMissedFinderButton_Click(object sender, EventArgs e)
		{
			new HtmlMissedFinder().ShowDialog();
		}

		private void ButtonLogParser_Click(object sender, EventArgs e)
		{
			new LogParser().ShowDialog();
		}

		private void MultisellEditorButton_Click(object sender, EventArgs e)
		{
			new MultisellEditor().ShowDialog();
		}

		private void ButtonQuestcomp_Click(object sender, EventArgs e)
		{
			new QuestPchMaker().ShowDialog();
		}

		private void SQLFormsButton_Click(object sender, EventArgs e)
		{
			new SQLForms().ShowDialog();
		}

		private void SuperpointBuilderButton_Click(object sender, EventArgs e)
		{
			new SuperpointBuilder().ShowDialog();
		}

		private void IncrementerButton_Click(object sender, EventArgs e)
		{
			new ToolIncrementer().ShowDialog();
		}
		#endregion

		#region Skills
		private void SkillAquireEditorButton_Click(object sender, EventArgs e)
		{
			new SkillAcquireEditor().ShowDialog();
		}

		private void SkillDataParserButton_Click(object sender, EventArgs e)
		{
			new SkillDataParser().ShowDialog();
		}

		private void SkillEditorButton_Click(object sender, EventArgs e)
		{
			new SkillEditor().ShowDialog();
		}

		private void SkillInjectButton_Click(object sender, EventArgs e)
		{
			new SkillInjector().ShowDialog();
		}

		private void ButtonSkillPch2Maker_Click(object sender, EventArgs e)
		{
			// new SkillPch2Maker().ShowDialog();
			new SkillPch2Maker().ShowDialog();
		}
		#endregion

		#region Scripts
		private void ClientAggroPatchMakerButton_Click(object sender, EventArgs e)
		{
			new ClientAggroPatchMaker().ShowDialog();
		}

		private void DatDecoderButton_Click(object sender, EventArgs e)
		{
			new DatDecoder().ShowDialog();
		}

		private void ButtonAddDelParam_Click(object sender, EventArgs e)
		{
			new ScriptAddDelParam().ShowDialog();
		}

		private void ButtonScriptEditor_Click(object sender, EventArgs e)
		{
			new ScriptEditor().ShowDialog();
		}

		private void ScriptExchangerButton_Click(object sender, EventArgs e)
		{
			new ScriptExchanger().ShowDialog();
		}

		private void ButtonScriptLeecher_Click(object sender, EventArgs e)
		{
			new ScriptLeecher().ShowDialog();
		}

		private void ButtonScriptLeecherOld_Click(object sender, EventArgs e)
		{
			new ScriptLeecherOld().ShowDialog();
		}

		private void ScriptParamSearcherButton_Click(object sender, EventArgs e)
		{
			new ScriptParamSearcher().ShowDialog();
		}

		private void ScriptSyntacsisCheckerButton_Click(object sender, EventArgs e)
		{
			new ScriptSyntacsisChecker().ShowDialog();
		}
		#endregion

		#region Zero Scripts
		private void ButtonAugmentationGenerator_Click(object sender, EventArgs e)
		{
			new AugmentationGenerator().ShowDialog();
		}

		private void ItemDataGeneratorButton_Click(object sender, EventArgs e)
		{
			new ItemDataGenerator().ShowDialog();
		}

		private void ButtonL2JBuySellList_Click(object sender, EventArgs e)
		{
			new L2J_BuySellList().ShowDialog();
		}

		private void ButtonL2JDoorData_Click(object sender, EventArgs e)
		{
			new L2J_DoorData().ShowDialog();
		}

		private void ButtonL2JMultiSell_Click(object sender, EventArgs e)
		{
			new L2J_MultiSell().ShowDialog();
		}

		private void ButtonL2JNpcData_Click(object sender, EventArgs e)
		{
			new L2J_NpcData().ShowDialog();
		}

		private void ButtonL2JNpcDrop_Click(object sender, EventArgs e)
		{
			new L2J_NpcData_Drop().ShowDialog();
		}

		private void ButtonL2JNpcPos_Click(object sender, EventArgs e)
		{
			new L2J_NpcPos().ShowDialog();
		}

		private void ScriptRecipeGeneratorButton_Click(object sender, EventArgs e)
		{
			new RecipeGenerator().ShowDialog();
		}

		private void ScriptFromDatButton_Click(object sender, EventArgs e)
		{
			new ScriptFromDat().ShowDialog();
		}

		private void SkillDataGeneratorButton_Click(object sender, EventArgs e)
		{
			new SkillDataGenerator().ShowDialog();
		}

		private void SkillDataGeneratorCT1Button_Click(object sender, EventArgs e)
		{
			new SkillDataGeneratorCT1().ShowDialog();
		}
		#endregion
	}
}