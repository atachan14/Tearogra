using UnityEngine;

public class SlashConfig : BaseSkillConfig
{
    float priColRange = 1.5f;
    float priCd = 2f;

    float priFront = 0.4f;
    float priMain = 0.4f;
    float priBack = 0.4f;

    float priAcFrame = 0.2f;
    float priAcWeight = 20;

    int priActNum = 2;

    int priPd = 50;
    int priFd = 0;

    protected override void SetupInitial()
    {
        colRange = priColRange;
        cd = priCd;

        front = priFront;
        main = priMain;
        back = priBack;

        acFrame = priAcFrame;
        acWeight = priAcWeight;

        actNum = priActNum;

        pd = priPd;
        fd = priFd;
    }
}
