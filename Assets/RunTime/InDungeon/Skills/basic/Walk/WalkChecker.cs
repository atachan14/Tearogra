using UnityEngine;

public class WalkChecker : BaseSkillChecker
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

        return state.NextPos != unit.transform.position;
    }

    protected override void SetupColRange()
    {
        //colÇ»ÇµÇÕâΩÇ‡èëÇ©Ç»Ç¢ÅB
    }
}
