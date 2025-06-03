using System.Collections;
using UnityEngine;

public class BaseSkillActor : MonoBehaviour, ISkillActor
{
    protected Unit unit;
    protected UnitState state;
    protected UnitParams parameter;
    protected BaseSkillChecker checker;

    protected ISkillActor lastActor;


    protected virtual void Start()
    {
        unit = GetComponentInParent<Unit>();
        parameter = GetComponentInParent<UnitParams>();
        state = GetComponentInParent<UnitState>();
        checker = GetComponent<BaseSkillChecker>();
    }

    public virtual void Execute()
    {
        StartCoroutine(ExeCoroutine());
    }
    private IEnumerator ExeCoroutine()
    {
        Enter();
        yield return StartCoroutine(ActCoroutine());
        Exit();
    }
    protected virtual void Enter()
    {
        lastActor = state.ActionSkill;
        state.ActionSkill = this;
    }
   
    public virtual IEnumerator ActCoroutine()
    {
        yield return StartCoroutine(FrontFrame());
        yield return StartCoroutine(MidFrame());
        yield return StartCoroutine(BackFrame());
    }
    protected virtual IEnumerator FrontFrame()
    {
        yield break;
    }
    protected virtual IEnumerator MidFrame()
    {
        Debug.Log("BaseSkillActor.MidFrame");
        yield break;
    }
    protected virtual IEnumerator BackFrame()
    {
        yield break;
    }
    protected virtual void Exit()
    {
        state.ActionSkill = lastActor;
    }

}
