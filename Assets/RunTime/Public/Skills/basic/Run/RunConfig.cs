using UnityEngine;

public class RunConfig : BaseSkillConfig
{
    protected override void InitParamMap()
    {
        base.InitParamMap(); // ���ʃf�t�H���g�l

        configMap[ParamType.msBonus] = 0f;
    }

}
