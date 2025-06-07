using System.Collections;
using UnityEngine;

/* 
 * Start
 * ↓
 * CashRefernces　参照取得。
 * 
 * Execute　Coroutineを使わないときにoverride
 * ↓
 * ExeCoroutine
 * ↓
 * Enter　実行前準備
 * ↓
 * ActCoroutine　動作についての流れ。
 * ↓
 * FrontFrame　準備動作（攻撃判定発生前等）
 * ↓
 * MainFrame　メイン動作
 * ↓
 * BackFrame　動作後の硬直等
 * ↓
 * Exit　実行後後処理　
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

    //BasicSkillsがoverrideする。他は基本的にoverrideしない。
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

    //基本的なoverrideはこの下三つとCacheReferences
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



    // ↓ヘルパーメソッド↓
    // TargetPosに身体を向ける。
    protected void UpdateAngleFromTargetPos(Vector3 TargetPos)
    {
        Vector3 dir = (TargetPos - unit.transform.position).normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        state.Angle = angle;
    }

    //身体が向いてる方向(floatで保持)をVector3に変換
    protected Vector3 AngleToDir()
    {
        float angleRad = state.Angle * Mathf.Deg2Rad;
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad), 0f);
    }

   
}
