using UnityEngine;

public class SlashChecker : BaseSkillChecker
{
    public override bool CheckTarget()
    {
        return PickClosest();
    }

    protected override void SetupCol()
    {
        col.radius = sParams.Get(ParamType.colRange);
    }
}
