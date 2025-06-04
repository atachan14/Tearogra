using System.Collections;
using UnityEngine;

public class FoundActor : BaseSkillActor
{
    ISkillActor combat;
    ISkillActor run;
    [SerializeField] GameObject foundEffect;

    protected override void Start()
    {
        base.Start();
        combat = unit.GetComponentInChildren<CombatActor>();
        run = unit.GetComponentInChildren<RunActor>();
    }

    protected override IEnumerator FrontFrame()
    {
        UpdateAngleFromTargetPos(checker.TargetUnit.transform.position);
        Instantiate(foundEffect, transform);
        yield break;
    }

    protected override void Exit()
    {
        state.ActionSkill = state.Combat_Run ? combat : run;
        Debug.Log($"FoundExit state.ActionSkill:{state.ActionSkill}");
    }
}
