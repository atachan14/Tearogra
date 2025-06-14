using UnityEngine;
using static UnityEngine.ParticleSystem;

public class RunChecker : BaseSkillChecker
{

    protected override void WriteCanAlertState()
    {
        CanAlert.Add(AlertType.Run);
    }
    public override bool CheckTarget()
    {
        return PickClosest();
    }
    protected override void SetupColRange()
    {
        col.radius = unitParams.searchRange + 1f;          //‘{õ”ÍˆÍ‚ÍunitParams‚ÅFound,Combat,Run‹¤—LB

    }
}
