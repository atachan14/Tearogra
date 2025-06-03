using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class WalkActor : BaseSkillActor
{
    public Vector3 TargetPos { get; set; }

    protected override void Start()
    {
        unit = GetComponentInParent<Unit>();
        parameter = GetComponentInParent<UnitParams>();
        state = GetComponentInParent<UnitState>();

        TargetPos = unit.transform.position;
    }

    public override void Execute()
    {
        if (Vector3.Distance(TargetPos, unit.transform.position) < 0.01)
        {
            unit.transform.position = TargetPos;
            return;
        }

        Vector3 dir = (TargetPos - unit.transform.position).normalized;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        state.Angle = angle;

        unit.transform.position += dir * parameter.ms * Time.deltaTime;
    }

}
