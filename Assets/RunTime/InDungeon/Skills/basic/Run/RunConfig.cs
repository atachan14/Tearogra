using UnityEngine;

public class RunConfig : BaseSkillConfig
{
    protected override void InitParamMap()
    {
        base.InitParamMap(); // 共通デフォルト値

        configMap[ParamType.bonusValue] = 0f;
    }

}
