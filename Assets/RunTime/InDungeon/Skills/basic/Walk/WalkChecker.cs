using UnityEngine;

public class WalkChecker : BaseSkillChecker
{
    
    protected override void Start()
    {
        base.Start();

        TargetPos = unit.transform.position;　//開幕時に勝手に移動するの防止。
    }
    public override bool Check()
    {
        return !state.IsAlert
            && state.Walk_Free
            && Vector3.Distance(TargetPos, unit.transform.position) >= 0.01;
    }
    protected override void SetupColliderRange()
    {
        //colなしは何も書かない。
    }
}
