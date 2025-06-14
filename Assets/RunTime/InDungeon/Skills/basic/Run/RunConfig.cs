using UnityEngine;

public class RunConfig : BaseSkillConfig
{
    public override void ExportParams(SkillParams skillParams)
    {
        skillParams.spValue = 0f;
    }
}
