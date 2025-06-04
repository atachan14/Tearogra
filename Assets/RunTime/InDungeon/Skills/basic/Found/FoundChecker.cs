using UnityEngine;

public class FoundChecker : BaseSkillChecker
{

    public override bool Check()
    {
        TargetUnit = GetClosest();

        return TargetUnit
            && state.Search_Ignore
            && (state.ActionSkill is FreeActor || state.ActionSkill is WalkActor);
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
