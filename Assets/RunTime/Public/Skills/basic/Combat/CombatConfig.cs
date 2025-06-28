using UnityEngine;

public class CombatConfig : BaseSkillConfig
{

    protected override void InitParamMap()
    {
        base.InitParamMap(); // 共通デフォルト値

        configMap[ParamType.msBonus] = 0.2f;
    }
}
