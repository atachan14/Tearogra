using System.Collections;
using UnityEngine;

public class FoundActor : BaseSkillActor
{
    AlertEffect alertEffect;

    protected override void CacheReferences()
    {
        base.CacheReferences();
        alertEffect = unit.GetComponentInChildren<AlertEffect>();
    }

    protected override IEnumerator FrontFrame()
    {
        UpdateAngleToTarget(checker.TargetObj.transform.position);
        alertEffect.ExecuteFound(skillParams.Get(ParamType.front));
        yield return new WaitForSeconds(skillParams.Get(ParamType.front));

        state.IsAlert = true;
    }
    protected override void Enter()
    {
        state.SkillState.Clear();
        state.SkillState.Add(this);
    }

}
