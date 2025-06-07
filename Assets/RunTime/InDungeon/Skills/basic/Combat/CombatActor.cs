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
        //Target��checker�ŕێ��B
        //���Ȃ��Ȃ��Ă���Free�ɖ߂��B
        TargetUnit = checker.GetClosest();
        if (TargetUnit == null)
        {
            bsm.ChangeActionSkillToFree();
            return;
        }

        //TargetPos������
        TargetPos = TargetUnit.transform.position;
        UpdateAngleFromTargetPos(TargetPos);

        //�������߂�������ҋ@
        //�߂����Ȃ�����������Ă�����Ɉړ��B
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
