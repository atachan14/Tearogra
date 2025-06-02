using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class WalkActor : BaseSkillActor
{
   

    protected override IEnumerator Act()
    {

        Vector3 dir = (checker.TargetPos - unit.transform.position).normalized;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        unit.transform.rotation = Quaternion.Euler(0, 0, angle);

        unit.transform.position += dir * parameter.ms * Time.deltaTime;
        yield return null;
    }

}
