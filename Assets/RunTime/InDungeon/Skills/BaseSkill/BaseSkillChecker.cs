using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BaseSkillChecker : MonoBehaviour, IRequireChecker
{
    protected Unit unit;
    protected UnitState state;
    protected UnitParams uParams;

    protected SkillParams sParams;
    protected CircleCollider2D col;

    [SerializeField] protected float cd;
    protected float maxCd;

    public List<AlertType> CanAlert { get; set; } = new();
    public List<ISkillActor> NeedSkill { get; set; } = new();
    public List<ISkillActor> CanSkill { get; set; } = new();

    public HashSet<GameObject> TargetSet { get; set; } = new();
    public GameObject TargetObj { get; set; }
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


    public void FloorSetup()
    {
        CacheReferences();
        SetupCanAlertState();
        SetupNeedState();
        SetupCanState();
        SetupCol();
        SetupLayer();
        maxCd = sParams.Get(ParamType.cd);
    }

    protected virtual void CacheReferences()
    {
        unit = GetComponentInParent<Unit>();
        state = GetComponentInParent<UnitState>();
        uParams = GetComponentInParent<UnitParams>();

        sParams = GetComponent<SkillParams>();
        col = GetComponent<CircleCollider2D>();
        
    }

    protected virtual void SetupCanAlertState()
    {
        CanAlert.Add(AlertType.Combat);
    }
    protected virtual void SetupNeedState()
    {

    }
    protected virtual void SetupCanState()
    {

    }
    protected virtual void SetupCol()
    {
        col.radius = sParams.Get(ParamType.colRange);
    }

    protected virtual void SetupLayer()
    {
        gameObject.layer = GetSearchToEnemy();
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
        TargetSet.Add(other.gameObject); // HashSet������d���C�ɂ��Ȃ���OK
    }

    void OnTriggerExit2D(Collider2D other)
    {
        TargetSet.Remove(other.gameObject);
    }


    //���w���p�[���\�b�h������
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

    protected int GetSearchToEnemy()
    {
        if(unit.AroId!= null)
        {
            return LayerMask.NameToLayer("SearchToGra");
        }
        else
        {
            return LayerMask.NameToLayer("SearchToAro");
        }
    }


    public GameObject PickClosest()
    {
        TargetObj = TargetSet
            .OrderBy(u => Vector3.Distance(unit.transform.position, u.transform.position))
            .FirstOrDefault();

        return TargetObj;
    }

}
