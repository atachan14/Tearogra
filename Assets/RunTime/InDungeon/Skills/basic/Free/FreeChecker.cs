using UnityEngine;

public class FreeChecker : BaseSkillChecker
{
    
    protected override void WriteCanAlertState()
    {
        CanAlert.Add(AlertType.Free);
    }

    protected override void SetupColRange()
    {

    }
}
