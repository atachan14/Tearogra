using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class WalkActor : BaseSkillActor
{


    protected override IEnumerator MidFrame()
    {

        Vector3 dir = (checker.TargetPos - unit.transform.position).normalized;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        state.Angle = angle;

        unit.transform.position += dir * parameter.ms * Time.deltaTime;
        yield break;
    }

}
