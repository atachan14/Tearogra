using UnityEngine;
using static UnityEngine.ParticleSystem;

public class SeekChecker : BaseSkillChecker
{
    protected override void WriteCanAlertState()
    {
        CanAlert.Add(AlertType.Combat);
    }

    protected override void WriteCanState()
    {
        AddCanState<FreeActor>();
        AddCanState<WalkActor>();
        AddCanState<SeekActor>();
    }
    public override bool CheckTarget()
    {
        return PickClosest();
    }
    protected override void SetupCol()
    {
        col.radius = unitParams.searchRange;          //‘{õ”ÍˆÍ‚ÍunitParams‚ÅFound,Combat,Run‹¤—LB

    }
}
