using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class WalkActor : BaseSkillActor
{
    public Vector3 TargetPos { get; set; }

    protected override void Start()
    {
        base.Start();

        TargetPos = unit.transform.position;
    }

    public override void Execute()
    {
        if (Vector3.Distance(TargetPos, unit.transform.position) < 0.01)
        {
            unit.transform.position = TargetPos;
            return;
        }

        UpdateAngleFromTargetPos(TargetPos);
        unit.transform.position += AngleToDir() * parameter.ms * Time.deltaTime;
    }
    
}
