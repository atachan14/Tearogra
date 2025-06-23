using UnityEngine;
using static UnityEngine.ParticleSystem;

public class SeekChecker : BaseSkillChecker
{
    protected override void SetupCanAlertState()
    {
        CanAlert.Add(AlertType.Free);
    }

    protected override void SetupCanState()
    {
        AddCanState<FreeActor>();
        AddCanState<WalkActor>();
        AddCanState<SeekActor>();
    }
    protected override void SetupLayer()
    {
        gameObject.layer = LayerMask.NameToLayer("SearchToItem");
    }
    public override bool CheckTarget()
    {
        return PickClosest();
    }
    protected override void SetupCol()
    {
        col.radius = uParams.lightRange;          //‘{õ”ÍˆÍ‚ÍunitParams‚ÅFound,Combat,Run‹¤—LB
    }
}
