using UnityEngine;

public class RunActor : BaseSkillActor
{
    Vector3 TargetPos;


    public override void Execute()
    {
        ExeSync();
    }

    protected override void ActSync()
    {
        //NextPos�������B
        state.NextPos = unit.transform.position;
        //TargetPos�̔��΂�����
        TargetPos = checker.TargetUnit.transform.position;
        UpdateAngleAwayTarget(TargetPos);

        //�����Ă�����Ɉړ��B
        unit.transform.position += AngleToDir() * unitParams.ms * (1 + skillParams.Get(ParamType.bonusValue)) * Time.deltaTime;
    }
}
