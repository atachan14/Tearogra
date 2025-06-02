using System.Collections;
using UnityEngine;

public class BaseSkillActor : MonoBehaviour, ISkillActor
{
    protected Unit unit;
    protected UnitState state;
    protected UnitParameter parameter;
    protected BaseSkillChecker checker;

    protected ISkillActor lastActor;


    protected virtual void Start()
    {
        unit = GetComponentInParent<Unit>();
        parameter = GetComponentInParent<UnitParameter>();
        state = GetComponentInParent<UnitState>();
        checker = GetComponent<BaseSkillChecker>();
    }

    public virtual IEnumerator Exe()
    {
        Enter();
        yield return StartCoroutine(Act());
        Exit();
    }

    protected virtual void Enter()
    {
        lastActor = state.ActionSkill;
        state.ActionSkill = this;
    }
    protected virtual IEnumerator Act()
    {
        Debug.Log("BaseSkillActor:Act");
        yield return new WaitForSeconds(1f);
    }
    protected virtual void Exit()
    {
        state.ActionSkill = lastActor;
    }
}
