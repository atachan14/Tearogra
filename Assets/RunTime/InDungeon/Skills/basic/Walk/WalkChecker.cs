using UnityEngine;

public class WalkChecker : BaseSkillChecker
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

        return state.NextPos != unit.transform.position;
    }

    protected override void SetupCol()
    {
        //colÇ»ÇµÇÕâΩÇ‡èëÇ©Ç»Ç¢ÅB
    }
}
