using System.Collections.Generic;

using L2ScriptMaker.Core.WinForms;
using L2ScriptMaker.DomainObjects.Models.Scripts;
using L2ScriptMaker.Services.Interfaces;

namespace L2ScriptMaker.Services.Scripts.Npc
{
	/// <summary>
	///		Service for npc_pch script
	/// </summary>
	public interface INpcPchService : IDataService<NpcPch>, IProgressService, IGenerateService
	{
		/// <summary>
		///		Transform npcpch file to form listitems collection
		/// </summary>
		/// <param name="fileName">NpcPch file path</param>
		/// <returns></returns>
		List<ListItem> GetListItems(string fileName);
	}
}