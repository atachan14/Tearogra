using UnityEngine;
using static UnityEngine.ParticleSystem;

public class RunChecker : BaseSkillChecker
{
    protected override void SetupColliderRange()
    {
        col.radius = unitParams.searchRange + 1;      //‘{õ”ÍˆÍ‚ÍunitParams‚ÅFound,Combat,Run‹¤—LB
    }
}
