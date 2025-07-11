using UnityEngine;
using UnityEngine.XR;

public class CombatActor : BaseSkillActor
{
    Vector3 TargetPos { get; set; }
    public override void Execute()
    {
        ExeSync();
    }

    protected override void ActSync()
    {
        //TargetPosを向く
        TargetPos = checker.TargetObj.transform.position;
        UpdateAngleToTarget(TargetPos);

        //距離が近すぎたら待機
        //近すぎなかったら向いてる方向に移動。
        if (Vector3.Distance(TargetPos, unit.transform.position) < 1.5f)
        {
            return;
        }
        else
        {
            unit.transform.position += AngleToDir() * unitParams.ms * (1 + skillParams.Get(ParamType.msBonus)) * Time.deltaTime;
        }

    }
}
