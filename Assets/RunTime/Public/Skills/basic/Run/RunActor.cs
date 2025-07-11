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
        //NextPos無効化。
        state.NextPos = unit.transform.position;
        //TargetPosの反対を向く
        TargetPos = checker.TargetObj.transform.position;
        UpdateAngleAwayTarget(TargetPos);

        //向いてる方向に移動。
        unit.transform.position += AngleToDir() * unitParams.ms * (1 + skillParams.Get(ParamType.msBonus)) * Time.deltaTime;
    }
}
