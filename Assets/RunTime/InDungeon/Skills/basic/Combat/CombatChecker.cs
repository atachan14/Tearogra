using UnityEngine;
using static UnityEngine.ParticleSystem;

public class CombatChecker : BaseSkillChecker
{
  
    protected override void SetupColliderRange()
    {
        col.radius = unitParams.searchRange;      //�{���͈͂�unitParams��Found,Combat,Run���L�B
    }

  
}
