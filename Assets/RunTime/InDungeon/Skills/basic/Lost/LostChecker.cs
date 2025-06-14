using UnityEngine;
using static UnityEngine.ParticleSystem;

public class LostChecker : BaseSkillChecker
{
    protected override void WriteCanAlertState()
    {
        CanAlert.Add(AlertType.Combat);
        CanAlert.Add(AlertType.Run);
    }

    public override bool CheckTarget()
    {
        return TargetList.Count == 0;
    }
    protected override void SetupColRange()
    {
        col.radius = unitParams.searchRange + 1;          //‘{õ”ÍˆÍ‚ÍunitParams‚ÅFound,Combat,Run‹¤—LB

    }
}
