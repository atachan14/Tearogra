using UnityEngine;
using static UnityEngine.ParticleSystem;

public class RunChecker : BaseSkillChecker
{
    protected override void SetupColliderRange()
    {
        col.radius = unitParams.searchRange + 1;      //�{���͈͂�unitParams��Found,Combat,Run���L�B
    }
}
