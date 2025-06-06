using UnityEngine;

public class BasicSkillManager : MonoBehaviour
{
    UnitState state;

    ISkillActor freeSkill;
    ISkillActor walkSkill;
    ISkillActor combatSkill;
    ISkillActor runSkill;

    void Start()
    {
        state = GetComponentInParent<UnitState>();
        freeSkill = GetComponentInChildren<FreeActor>();
        walkSkill = GetComponentInChildren<WalkActor>();
        combatSkill = GetComponentInChildren<CombatActor>();
        runSkill = GetComponentInChildren<RunActor>();
    }

    void Update()
    {
        if (state.ActionSkill is FreeActor && state.Walk_Free)
        {
            state.ActionSkill = walkSkill;
        }

        if (state.ActionSkill is WalkActor && !state.Walk_Free)
        {
            state.ActionSkill = freeSkill;
        }

        switch (state.ActionSkill)
        {
            case FreeActor:
                freeSkill.Execute();
                break;
            case WalkActor:
                walkSkill.Execute();
                break;
            case CombatActor:
                combatSkill.Execute();
                break;
            case RunActor:
                runSkill.Execute();
                break;
            default:
                break;
        }
    }

    public void ChangeActionSkillToFree()
    {
        state.ActionSkill = freeSkill;
    }
}

