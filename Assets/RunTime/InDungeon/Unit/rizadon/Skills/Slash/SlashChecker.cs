using UnityEngine;

public class SlashChecker : BaseSkillChecker
{
    public override bool CheckTarget()
    {
        return PickClosest();
    }

    protected override void SetupCol()
    {
        col.radius = skillParams.Get(ParamType.colRange);
        Debug.Log($"SlashChecker skillParams.colRange:{skillParams.Get(ParamType.colRange)}");
        Debug.Log($"SlashChecker col.radius:{col.radius}");
    }
}
