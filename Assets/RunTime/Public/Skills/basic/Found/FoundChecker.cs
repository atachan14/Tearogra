using UnityEngine;

public class FoundChecker : BaseSkillChecker
{
    protected override void SetupCanAlertState()
    {
        CanAlert.Add(AlertType.Free);
    }
    protected override void SetupCanState()
    {
        AddCanState<FreeActor>();
        AddCanState<WalkActor>();
    }

    public override bool CheckTarget()
    {
        return state.Search_Ignore && PickClosest();
    }
    protected override void SetupCol()
    {
        col.radius = uParams.SearchRange;          //‘{õ”ÍˆÍ‚ÍunitParams‚ÅFound,Combat,Run‹¤—LB

    }


}
