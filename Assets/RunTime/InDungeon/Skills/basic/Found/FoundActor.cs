using System.Collections;
using UnityEngine;

public class FoundActor : BaseSkillActor
{
    [SerializeField] GameObject foundEffect;

  

    protected override IEnumerator FrontFrame()
    {
        UpdateAngleToTarget(checker.TargetUnit.transform.position);
        Instantiate(foundEffect, transform);
        yield return new WaitForSeconds(skillParams.front);

        state.IsAlert = true;
    }
    protected override void Enter()
    {
        state.SkillState.Clear();
        state.SkillState.Add(this);
    }

}
