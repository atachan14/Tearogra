using UnityEngine;

public class FreeChecker : BaseSkillChecker
{
    
    protected override void SetupCanAlertState()
    {
        CanAlert.Add(AlertType.Free);
    }

    protected override void SetupCol()
    {

    }
}
