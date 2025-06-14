using UnityEngine;

public class FoundChecker : BaseSkillChecker
{
    protected override void WriteCanAlertState()
    {
        CanAlert.Add(AlertType.Free);
    }
    protected override void WriteCanState()
    {
        AddCanState<FreeActor>();
        AddCanState<WalkActor>();
    }

    public override bool CheckTarget()
    {
        return state.Search_Ignore && PickClosest();
    }
    protected override void SetupColRange()
    {
        col.radius = unitParams.searchRange;          //�{���͈͂�unitParams��Found,Combat,Run���L�B

    }


}
