using UnityEngine;
using static UnityEngine.ParticleSystem;

public class CombatChecker : BaseSkillChecker
{
  
    protected override void SetupColliderRange()
    {
        col.radius = unitParams.searchRange;      //‘{õ”ÍˆÍ‚ÍunitParams‚ÅFound,Combat,Run‹¤—LB
    }

  
}
