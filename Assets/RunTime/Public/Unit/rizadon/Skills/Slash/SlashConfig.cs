public class SlashConfig : BaseSkillConfig
{
    protected override void InitParamMap()
    {
        base.InitParamMap(); // 共通デフォルト値

        configMap[ParamType.colRange] = 1.5f;
        configMap[ParamType.cd] = 2f;
        configMap[ParamType.front] = 0.4f;
        configMap[ParamType.main] = 0.4f;
        configMap[ParamType.back] = 0.4f;
        configMap[ParamType.acFrame] = 0.2f;
        configMap[ParamType.acWeight] = 20f;
        configMap[ParamType.actNum] = 2;
        configMap[ParamType.pd] = 50;
        configMap[ParamType.fd] = 0;
    }
}
