Public Class StartForm

	Dim sCopyName As String = "Lineage II Script Maker v."

	Private Sub StartForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

#If Not DEBUG Then
		Eula.ShowDialog()
#End If

		Me.Text = sCopyName & Application.ProductVersion

	End Sub

	Private Sub ButtonAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAbout.Click
		AboutBox1.ShowDialog()
	End Sub

	Private Sub CheckUpdateButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckUpdateButton.Click
		CheckUpdate.ShowDialog()
	End Sub

	Private Sub QuitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuitButton.Click
		Application.Exit()
	End Sub

	Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
		DoorMakerForm.ShowDialog()
	End Sub

	Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
		SkillPch2Maker.ShowDialog()
	End Sub

	Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
		ItemPchMaker.ShowDialog()
	End Sub

	Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
		AiInjector.ShowDialog()
	End Sub

	Private Sub NpcPchMakerButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NpcPchMakerButton.Click
		NpcPchMaker.ShowDialog()
	End Sub

	Private Sub NpcPosButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NpcPosButton.Click
		NpcPosAreaMaker.ShowDialog()
	End Sub

	Private Sub NpcInjectorButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NpcInjectorButton.Click
		NpcInjector.ShowDialog()
	End Sub

	Private Sub ItemInjectorButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemInjectorButton.Click
		ItemInjector.ShowDialog()
	End Sub

	Private Sub SkillInjectButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SkillInjectButton.Click
		SkillInjector.ShowDialog()
	End Sub

	Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
		SkillEditor.ShowDialog()
	End Sub

	Private Sub ExecInjectorButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExecInjectorButton.Click
		ExecInjector.ShowDialog()
	End Sub

	Private Sub ScriptExchanger_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ScriptExchangerButton.Click
		ScriptExchanger.ShowDialog()
	End Sub

	Private Sub NpcPosShifterButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NpcPosShifterButton.Click
		NpcPosShifter.ShowDialog()
	End Sub

	Private Sub DefaultPriceButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DefaultPriceButton.Click
		ItemDefaultPrice.ShowDialog()
	End Sub

	Private Sub ButtonScriptLeecher_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonScriptLeecherOld.Click
		ScriptLeecherOld.Show()
	End Sub

	Private Sub ButtonHtmlButtonDesigner_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonHtmlButtonDesigner.Click
		HtmlButtonDesigner.ShowDialog()
	End Sub

	Private Sub ButtonQuestcomp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonQuestcomp.Click
		QuestPchMaker.ShowDialog()
	End Sub

	Private Sub ButtonScriptEditor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonScriptEditor.Click
		ScriptEditor.ShowDialog()
	End Sub

	Private Sub ButtonAIMessageImporter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAIMessageImporter.Click
		AIMessageImporter.ShowDialog()
	End Sub

	Private Sub ButtonAiRateChanger_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAiRateChanger.Click
		AiRateChanger.ShowDialog()
	End Sub

	Private Sub ButtonAiFixer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAiFixer.Click
		AiFixer.ShowDialog()
	End Sub

	Private Sub CheckAIHandlerButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckAIHandlerButton.Click
		AIHandlersChecker.ShowDialog()
	End Sub

	Private Sub ButtonAIMessageTeleportImporter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAIMessageTeleportImporter.Click
		AIMessageTeleportImporter.ShowDialog()
	End Sub

	Private Sub EventDataEditorButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EventDataEditorButton.Click
		EventDataEditor.ShowDialog()
	End Sub

	Private Sub SuperpointBuilderButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SuperpointBuilderButton.Click
		SuperpointBuilder.ShowDialog()
	End Sub

	Private Sub AIbuyselllistEditorButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AIbuyselllistEditorButton.Click
		AIbuyselllistEditor.ShowDialog()
	End Sub

	Private Sub MultisellEditorButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MultisellEditorButton.Click
		MultisellEditor.ShowDialog()
	End Sub

	Private Sub NpcPrivatesButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NpcPrivatesButton.Click
		NpcPosChecker.ShowDialog()
	End Sub

	Private Sub NpcSkillFixButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NpcSkillFixButton.Click
		NpcDataPassiveSkillFix.ShowDialog()
	End Sub

	Private Sub AreaDataButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AreaDataButton.Click
		AreaDataGenerator.ShowDialog()
	End Sub

	Private Sub ButtonAiParamsNpcdataChecker_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAiParamsNpcdataChecker.Click
		AiParamsNpcdataChecker.ShowDialog()
	End Sub

	Private Sub ItemTypeFixerButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemDataFixerButton.Click
		ItemDataFixer.ShowDialog()
	End Sub

	Private Sub ExecL2AuthButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExecL2AuthButton.Click
		ExecL2AuthKey.ShowDialog()
	End Sub

	Private Sub NpcdataRateReBuilderButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NpcdataRateReBuilderButton.Click
		NpcdataRateReBuilder.Show()
	End Sub

	Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
		GeoIndexGen.ShowDialog()
	End Sub

	Private Sub SkillAquireEditorButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SkillAquireEditorButton.Click
		SkillAcquireEditor.ShowDialog()
	End Sub

	Private Sub HtmlMissedFinderButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HtmlMissedFinderButton.Click
		HtmlMissedFinder.ShowDialog()
	End Sub

	Private Sub NullPosFixerButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NullPosFixerButton.Click
		LogDNullPosFixer.ShowDialog()
	End Sub

	Private Sub DatDecoderButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DatDecoderButton.Click
		DatDecoder.ShowDialog()
	End Sub

	Private Sub ScriptParamSearcherButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ScriptParamSearcherButton.Click
		ScriptParamSearcher.ShowDialog()
	End Sub

	Private Sub GeonameLocationButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GeonameLocationButton.Click
		GeoLocConverter.ShowDialog()
	End Sub

	Private Sub GeoGetTestPointButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GeoGetTestPointButton.Click
		GeoGetTestPoint.ShowDialog()
	End Sub

	Private Sub ScriptFromDatButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ScriptFromDatButton.Click
		ScriptFromDat.ShowDialog()
	End Sub

	Private Sub ScriptRecipeGeneratorButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ScriptRecipeGeneratorButton.Click
		RecipeGenerator.ShowDialog()
	End Sub

	Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
		ScriptIDShower.Show()
	End Sub

	Private Sub SkillDataParserButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SkillDataParserButton.Click
		SkillDataParser.ShowDialog()
	End Sub

	Private Sub AIDecompilerButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AIDecompilerButton.Click
		AIDecompiler.ShowDialog()
	End Sub

	Private Sub NpcSkillFixC6Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NpcSkillFixC6Button.Click
		NpcDataPassiveSkillFixC6.ShowDialog()
	End Sub

	Private Sub SkillDataGeneratorButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SkillDataGeneratorButton.Click
		SkillDataGenerator.ShowDialog()
	End Sub

	Private Sub ClientAggroPatchMakerButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClientAggroPatchMakerButton.Click
		ClientAggroPatchMaker.ShowDialog()
	End Sub

	Private Sub IncrementerButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IncrementerButton.Click
		ToolIncrementer.ShowDialog()
	End Sub

	Private Sub NpcC4toC5IdsConversionButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NpcC4toC5IdsConversionButton.Click
		NpcC4toC5IdsConversion.ShowDialog()
	End Sub

	Private Sub NpcDropItemCheckerButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NpcDropItemCheckerButton.Click
		NpcDropItemChecker.ShowDialog()
	End Sub

	Private Sub AIRaidPosGeneratorButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AIRaidPosGeneratorButton.Click
		AIRaidPosGenerator.ShowDialog()
	End Sub

	Private Sub NpcposManorZoneGeneratorButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NpcposManorZoneGeneratorButton.Click
		NpcposManorZoneGenerator.ShowDialog()
	End Sub

	Private Sub ItemDataGeneratorButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemDataGeneratorButton.Click
		ItemDataGenerator.ShowDialog()
	End Sub

	Private Sub NpcDataCollisionFixButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NpcDataCollisionFixButton.Click
		NpcDataCollisionFix.ShowDialog()
	End Sub

	Private Sub NpcDataCheckerButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NpcDataCheckerButton.Click
		NpcDataChecker.ShowDialog()
	End Sub

	Private Sub ScriptSyntacsisCheckerButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ScriptSyntacsisCheckerButton.Click
		ScriptSyntacsisChecker.ShowDialog()
	End Sub

	Private Sub ButtonScriptLeecher_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonScriptLeecher.Click
		ScriptLeecher.ShowDialog()
	End Sub

	Private Sub HerbMobGeneratorButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HerbMobGeneratorButton.Click
		NpcDataHerbMobs.ShowDialog()
	End Sub

	Private Sub SQLFormsButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SQLFormsButton.Click
		SQLForms.ShowDialog()
	End Sub

	Private Sub ButtonLogParser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonLogParser.Click
		LogParser.ShowDialog()
	End Sub

	Private Sub ButtonNpcposMap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNpcposMap.Click
		NpcposMap.ShowDialog()
	End Sub

	Private Sub ButtonHtmlDesigner_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonHtmlDesigner.Click
		HtmlDesigner.ShowDialog()
	End Sub

	Private Sub SkillDataGeneratorCT1Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SkillDataGeneratorCT1Button.Click
		SkillDataGeneratorCT1.ShowDialog()
	End Sub

	Private Sub ButtonAugmentationGenerator_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAugmentationGenerator.Click
		AugmentationGenerator.ShowDialog()
	End Sub

	' NO USE Feature
	Private Sub RecipeFixer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
		MessageBox.Show("No work feature. Develop mode", "No work now...", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
		RecipeFixer.ShowDialog()
	End Sub

	Private Sub StartForm_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
		If Me.Text.StartsWith(sCopyName) <> True Then 'Welcome... = 10s
			'If Me.Text.Length < 11 Then 'Welcome... = 10s
			'MessageBox.Show("StartForm_VisibleChanged")
			'ExpiredToKill()
			End
		End If
	End Sub

	Private Sub TabControl1_Selected(ByVal sender As Object, ByVal e As System.Windows.Forms.TabControlEventArgs) Handles TabControl1.Selected
		If Me.Text.StartsWith(sCopyName) <> True Then 'Welcome... = 10s
			'MessageBox.Show("StartForm_VisibleChanged")
			'ExpiredToKill()
			End
		End If
	End Sub

	Private Sub NpcDataEditorButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NpcDataMakerButton.Click
		NpcDataMaker.ShowDialog()
	End Sub

	Private Sub AIDecompilerPackButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AIDecompilerPackButton.Click
		AIDecompilerPack.ShowDialog()
	End Sub

	Private Sub ButtonAddDelParam_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAddDelParam.Click
		ScriptAddDelParam.ShowDialog()
	End Sub

	Private Sub ButtonL2JMultiSell_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonL2JMultiSell.Click
		L2J_MultiSell.ShowDialog()
	End Sub

	Private Sub ButtonL2JNpcPos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonL2JNpcPos.Click
		L2J_NpcPos.ShowDialog()
	End Sub

	Private Sub ButtonL2JNpcDrop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonL2JNpcDrop.Click
		L2J_NpcData_Drop.ShowDialog()
	End Sub

	Private Sub ButtonL2JNpcData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonL2JNpcData.Click
		L2J_NpcData.ShowDialog()
	End Sub

	Private Sub ButtonL2JBuySellList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonL2JBuySellList.Click
		L2J_BuySellList.ShowDialog()
	End Sub

	Private Sub ButtonL2JDoorData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonL2JDoorData.Click
		L2J_DoorData.ShowDialog()
	End Sub
End Class