using UnityEngine;
using static UnityEngine.ParticleSystem;

public class SeekActor : BaseSkillActor
{
    Vector3 TargetPos { get; set; }
    CollectActor collect;
    protected override void CacheReferences()
    {
        base.CacheReferences();
        collect = GetComponentInParent<Unit>().GetComponentInChildren<CollectActor>();
    }

    public override void Execute()
    {
        ExeSync();
    }
    protected override void Enter()
    {
        state.SkillState.Clear();
        state.SkillState.Add(this);
    }
    protected override void Exit()
    {

    }

    protected override void ActSync()
    {
        //TargetPos‚ðŒü‚­
        TargetPos = checker.TargetObj.transform.position;
        UpdateAngleToTarget(TargetPos);

        //‹——£‚ª‹ß‚·‚¬‚½‚ç‘Ò‹@
        if (Vector3.Distance(TargetPos, unit.transform.position) < 0.1f)
        {
            collect.TargetItem = checker.TargetObj;
            collect.Execute();
            state.SkillState.Remove(this);
        }
        else
        {
            unit.transform.position += AngleToDir() * unitParams.ms * (1 + skillParams.Get(ParamType.msBonus)) * Time.deltaTime;
        }
    }
}
