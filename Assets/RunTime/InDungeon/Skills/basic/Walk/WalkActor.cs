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

    protected override void Exit() 
    {
        //BasicSkillÇÕñﬂÇ≥Ç»Ç¢ÅB
    }

    protected override void ActSync()
    {
        UpdateAngleFromTargetPos(state.NextPos);
        unit.transform.position += AngleToDir() * unitParams.ms * Time.deltaTime;

        if (Vector3.Distance(state.NextPos, unit.transform.position) <= 0.01)
        {
            unit.transform.position = state.NextPos;
        }
    }
}
