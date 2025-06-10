using UnityEngine;
using static UnityEngine.ParticleSystem;

public class LostChecker : BaseSkillChecker
{
    protected override void SetupCanAlertState()
    {
        CanAlert.Add(AlertType.Combat);
        CanAlert.Add(AlertType.Run);
    }

    public override bool CheckTarget()
    {
        return TargetList.Count==0;
    }
    protected override void SetupColRange()
    {
        col.radius = unitParams.searchRange;          //‘{õ”ÍˆÍ‚ÍunitParams‚ÅFound,Combat,Run‹¤—LB

    }
}
