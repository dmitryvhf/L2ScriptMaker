using L2ScriptMaker.DomainObjects.Models.Scripts;
using L2ScriptMaker.Services.Interfaces;

namespace L2ScriptMaker.Services.Scripts.Skill
{
	public interface ISkillDataService : IDataService<SkillData>, IProgressService
	{
	}
}