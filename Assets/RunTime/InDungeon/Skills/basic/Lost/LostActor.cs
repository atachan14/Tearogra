using System.Collections;
using UnityEngine;

public class LostActor : BaseSkillActor
{
    AlertEffect alertEffect;

    protected override void CacheReferences()
    {
        base.CacheReferences();
        alertEffect = unit.GetComponentInChildren<AlertEffect>();
    }
    protected override IEnumerator FrontFrame()
    {
        alertEffect.ExecuteLost();
        yield return new WaitForSeconds(skillParams.front);

        state.NextPos = unit.transform.position;
        state.IsAlert = false;
       
    }
}
