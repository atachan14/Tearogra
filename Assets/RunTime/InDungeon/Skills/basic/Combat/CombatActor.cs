using UnityEngine;
using UnityEngine.XR;

public class CombatActor : BaseSkillActor
{
    GameObject TargetUnit;
    Vector3 TargetPos;

    BasicSkillManager bsm;

    protected override void CacheReferences()
    {
        base.CacheReferences();
        bsm = GetComponentInParent<BasicSkillManager>();
    }
    public override void Execute()
    {
        //Targetはcheckerで保持。
        //いなくなってたらFreeに戻す。
        TargetUnit = checker.GetClosest();
        if (TargetUnit == null)
        {
            bsm.ChangeActionSkillToFree();
            return;
        }

        //TargetPosを向く
        TargetPos = TargetUnit.transform.position;
        UpdateAngleFromTargetPos(TargetPos);

        //距離が近すぎたら待機
        //近すぎなかったら向いてる方向に移動。
        if (Vector3.Distance(TargetPos, unit.transform.position) < 1f)
        {
            return;
        }
        else
        {
            unit.transform.position += AngleToDir() * unitParams.ms * (1 + skillParams.spValue) * Time.deltaTime;
        }
    }
}
