using System.Collections;
using UnityEngine;

/* 
 * Start
 * ��
 * CashRefernces�@�Q�Ǝ擾�B
 * 
 * Execute�@Coroutine���g��Ȃ��Ƃ���override
 * ��
 * ExeCoroutine
 * ��
 * Enter�@���s�O����
 * ��
 * ActCoroutine�@����ɂ��Ă̗���B
 * ��
 * FrontFrame�@��������i�U�����蔭���O���j
 * ��
 * MainFrame�@���C������
 * ��
 * BackFrame�@�����̍d����
 * ��
 * Exit�@���s��㏈���@
 */



public class BaseSkillActor : MonoBehaviour, ISkillActor
{
    protected Unit unit;
    protected UnitState state;
    protected UnitParams unitParams;

    protected SkillParams skillParams;
    protected BaseSkillChecker checker;

    protected ISkillActor lastActor;


    protected virtual void Start()
    {
        CacheReferences();
    }

    protected virtual void CacheReferences()
    {
        unit = GetComponentInParent<Unit>();
        unitParams = GetComponentInParent<UnitParams>();
        state = GetComponentInParent<UnitState>();

        skillParams = GetComponent<SkillParams>();
        checker = GetComponent<BaseSkillChecker>();
    }

    //BasicSkills��override����B���͊�{�I��override���Ȃ��B
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

    //��{�I��override�͂��̉��O��CacheReferences
    protected virtual IEnumerator FrontFrame()
    {
        yield break;
    }
    protected virtual IEnumerator MidFrame()
    {
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



    // ���w���p�[���\�b�h��
    // TargetPos�ɐg�̂�������B
    protected void UpdateAngleFromTargetPos(Vector3 TargetPos)
    {
        Vector3 dir = (TargetPos - unit.transform.position).normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        state.Angle = angle;
    }

    //�g�̂������Ă����(float�ŕێ�)��Vector3�ɕϊ�
    protected Vector3 AngleToDir()
    {
        float angleRad = state.Angle * Mathf.Deg2Rad;
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad), 0f);
    }

   
}
