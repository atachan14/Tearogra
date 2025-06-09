using UnityEngine;

public class FreeChecker : BaseSkillChecker
{
    public override bool Check()
    {
        return !state.IsAlert
            && !state.Walk_Free;
    }
    protected override void SetupColliderRange()
    {

    }
}
