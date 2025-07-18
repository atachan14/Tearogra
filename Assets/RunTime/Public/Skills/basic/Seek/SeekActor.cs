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
  
    protected override void ActSync()
    {
        if(!checker.TargetObj)
        {
            state.SkillState.Remove(this);
            return;
        };
        //TargetPosを向く
        TargetPos = checker.TargetObj.transform.position;
        UpdateAngleToTarget(TargetPos);

        //距離が近すぎたら待機
        if (Vector3.Distance(TargetPos, unit.transform.position) < 0.5f)
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
