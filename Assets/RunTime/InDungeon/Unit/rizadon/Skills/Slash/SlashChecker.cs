using UnityEngine;

public class SlashChecker : BaseSkillChecker
{
    public override bool CheckTarget()
    {
        return PickClosest();
    }

    protected override void SetupColRange()
    {
        col.radius = skillParams.colRange;
        Debug.Log($"SlashChecker skillParams.colRange:{skillParams.colRange}");
        Debug.Log($"SlashChecker col.radius:{col.radius}");
    }
}
