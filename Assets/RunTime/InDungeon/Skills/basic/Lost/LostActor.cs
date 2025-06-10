using System.Collections;
using UnityEngine;

public class LostActor : BaseSkillActor
{
    protected override IEnumerator FrontFrame()
    {
        yield return new WaitForSeconds(skillParams.front);

        state.IsAlert = false;
        state.NextPos = unit.transform.position;
    }
}
