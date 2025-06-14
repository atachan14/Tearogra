using UnityEngine;

public class CombatConfig : BaseSkillConfig
{

    public override void ExportParams(SkillParams skillParams)
    {
        skillParams.spValue = 0.2f;
    }
}
