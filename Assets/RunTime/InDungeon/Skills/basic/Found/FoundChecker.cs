using UnityEngine;

public class FoundChecker : BaseSkillChecker
{

    public override bool Check()
    {
        return TargetList.Count > 0;
    }

    protected override void SetupColliderRange()
    {
        col.radius = unitParams.searchRange;
    }

    protected override void SetupCanState()
    {
        AddCanState<FreeActor>();
        AddCanState<WalkActor>();

    }
}
