using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BaseSkillChecker : MonoBehaviour, IRequireChecker
{
    protected Unit unit;
    protected UnitState state;
    protected BaseUnitParams unitParams;

    protected SkillParams skillParams;
    protected CircleCollider2D col;

    [SerializeField] protected float cd;
    protected float maxCd;

    public List<AlertType> CanAlert { get; set; } = new();
    public List<ISkillActor> NeedSkill { get; set; } = new();
    public List<ISkillActor> CanSkill { get; set; } = new();

    public HashSet<GameObject> TargetSet { get; set; } = new();
    public GameObject TargetUnit { get; set; }
    public Vector3 TargetPos { get; set; }

    public void CdStart()
    {
        cd = maxCd;
    }

    void Update()
    {
        CdTick();
    }

    void CdTick()
    {
        if (cd <= 0) return;

        cd -= Time.deltaTime;
        if (cd <= 0f)
        {
            cd = 0f;
        }
    }


    public void SetupChecker()
    {
        CacheReferences();
        WriteCanAlertState();
        WriteNeedState();
        WriteCanState();
        SetupCol();
        maxCd = skillParams.Get(ParamType.cd);
    }

    protected virtual void CacheReferences()
    {
        unit = GetComponentInParent<Unit>();
        state = GetComponentInParent<UnitState>();
        unitParams = GetComponentInParent<BaseUnitParams>();

        skillParams = GetComponent<SkillParams>();
        col = GetComponent<CircleCollider2D>();
        
    }

    protected virtual void WriteCanAlertState()
    {
        CanAlert.Add(AlertType.Combat);
    }
    protected virtual void WriteNeedState()
    {

    }
    protected virtual void WriteCanState()
    {

    }
    protected virtual void SetupCol()
    {
        col.radius = skillParams.Get(ParamType.colRange);
    }

    public virtual bool Check()
    {
        if (cd != 0) return false;
        if (!CheckAlertState()) return false;
        if (!CheckNeedState()) return false;
        if (!CheckCanState()) return false;
        if (!CheckTarget()) return false;
        return true;
    }
    public virtual bool CheckAlertState()
    {
        return CanAlert.Contains(state.AlertState);
    }
    public virtual bool CheckNeedState()
    {
        return NeedSkill.All(need => state.SkillState.Contains(need));
    }
    public virtual bool CheckCanState()
    {
        return state.SkillState.All(skill => NeedSkill.Contains(skill) || CanSkill.Contains(skill));
    }
    public virtual bool CheckTarget()
    {
        return true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        TargetSet.Add(other.gameObject); // HashSetだから重複気にしなくてOK
    }

    void OnTriggerExit2D(Collider2D other)
    {
        TargetSet.Remove(other.gameObject);
    }


    //↓ヘルパーメソッドたち↓
    protected void AddNeedState<T>() where T : ISkillActor
    {
        ISkillActor skill = state.GetComponentInChildren<T>();
        if (skill != null)
            NeedSkill.Add(skill);
        else
            Debug.LogWarning($"[BaseSkillChecker] {typeof(T).Name} not found on unit");
    }

    protected void AddCanState<T>() where T : ISkillActor
    {
        var skill = state.GetComponentInChildren<T>();
        if (skill != null)
            CanSkill.Add(skill);
        else
            Debug.LogWarning($"[BaseSkillChecker] {typeof(T).Name} not found on unit");
    }


    public GameObject PickClosest()
    {
        TargetUnit = TargetSet
            .OrderBy(u => Vector3.Distance(unit.transform.position, u.transform.position))
            .FirstOrDefault();

        return TargetUnit;
    }

}
