using UnityEngine;

public class FoundConfig : BaseSkillConfig
{
    protected override void InitParamMap()
    {
        base.InitParamMap(); // ���ʃf�t�H���g�l

        configMap[ParamType.front] = 1f; //�������̍d��
    }
}
