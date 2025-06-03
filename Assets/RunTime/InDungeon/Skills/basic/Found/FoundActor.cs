using UnityEngine;

public class FoundActor : BaseSkillActor
{
    ISkillActor combat;
    ISkillActor run;
    protected override void Start()
    {
        base.Start();
        combat = unit.GetComponentInChildren<CombatActor>();
        run = unit.GetComponentInChildren<RunActor>();
    }

    protected override void Exit()
    {
        state.ActionSkill = state.Combat_Run ? combat : run;
    }
}
