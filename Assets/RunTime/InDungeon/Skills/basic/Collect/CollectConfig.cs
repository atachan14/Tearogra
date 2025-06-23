using UnityEngine;

public class CollectConfig : BaseSkillConfig
{
    protected override void InitParamMap()
    {
        base.InitParamMap();
        configMap[ParamType.front] = 2f;
        configMap[ParamType.colRange] = 1f;
    }
}
