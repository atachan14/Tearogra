using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class WalkActor : BaseSkillActor
{
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
        if (state.NextPos == unit.transform.position) { state.SkillState.Remove(this); }
    }

    protected override void ActSync()
    {
        UpdateAngleToTarget(state.NextPos);
        unit.transform.position += AngleToDir() * unitParams.ms * Time.deltaTime;

        if (Vector3.Distance(state.NextPos, unit.transform.position) <= 0.01)
        {
            unit.transform.position = state.NextPos;
        }
    }
}
