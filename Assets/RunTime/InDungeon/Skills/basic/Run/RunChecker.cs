using UnityEngine;
using static UnityEngine.ParticleSystem;

public class RunChecker : BaseSkillChecker
{

    protected override void SetupCanAlertState()
    {
        CanAlert.Add(AlertType.Run);
    }
    public override bool CheckTarget()
    {
        return PickClosest();
    }
    protected override void SetupCol()
    {
        col.radius = uParams.lightRange + 1f;          //‘{õ”ÍˆÍ‚ÍunitParams‚ÅFound,Combat,Run‹¤—LB

    }
}
