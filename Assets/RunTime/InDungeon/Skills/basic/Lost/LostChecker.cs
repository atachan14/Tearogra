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
        return TargetSet.Count == 0;
    }
    protected override void SetupCol()
    {
        col.radius = uParams.lightRange + 1;          //�{���͈͂�unitParams��Found,Combat,Run���L�B

    }
}
