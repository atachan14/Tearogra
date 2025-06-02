using UnityEngine;

public class WalkChecker : BaseSkillChecker
{
   

    public override bool Check()
    {
        if (state.Walk_Free
            && Vector3.Distance(TargetPos, transform.position) > 0.1f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
