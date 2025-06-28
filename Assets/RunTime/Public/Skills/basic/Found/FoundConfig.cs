using UnityEngine;

public class FoundConfig : BaseSkillConfig
{
    protected override void InitParamMap()
    {
        base.InitParamMap(); // 共通デフォルト値

        configMap[ParamType.front] = 1f; //発見時の硬直
    }
}
