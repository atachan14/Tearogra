using UnityEngine;
using static UnityEngine.ParticleSystem;

public class CombatChecker : BaseSkillChecker
{

   
    public override bool CheckTarget()
    {
        return PickClosest();
    }
    protected override void SetupColRange()
    {
        col.radius = unitParams.searchRange + 1f;          //�{���͈͂�unitParams��Found,Combat,Run���L�B

    }

}
