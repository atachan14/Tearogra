using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

// 実装予定
//  CanModsCreate: みたいな。
//  使用する値のModParamsをCanModsに入れる。
//  CanModsをSkillParamsに入れる処理はSkillParams.ApplyParamsに実装済み。            


public class BaseSkillConfig : SkillParamsFormat
{
    public List<ModParamType> canMods  = new();



    private void Awake()
    {
        SetupInitial();
    }
    protected virtual void SetupInitial()
    {
        //初期値の設定
    }

    private void Start()
    {
        CashRefarence();
    }

    protected virtual void CashRefarence()
    {
    }

    public virtual void ExportParams(SkillParams skillParams)    //SkillParamsから呼び出される
    {
        skillParams.canMods = canMods;
        // Frame
        skillParams.front = front;
        skillParams.main = main;
        skillParams.back = back;                                                                                                                                            

        // Require
        skillParams.colRange = colRange;
        skillParams.cd = cd;
        skillParams.targetCount = targetCount;

        // AttackCollision
        skillParams.acFrame = acFrame;
        skillParams.acLength = acLength;
        skillParams.acWidth = acWidth;
        skillParams.acSpeed = acSpeed;
        skillParams.acWeight = acWeight;

        // Other
        skillParams.actNum = actNum;
        skillParams.buff = buff;
        skillParams.debuff = debuff;
        skillParams.spValue = spValue;

        // Damage
        skillParams.pd = pd;
        skillParams.fd = fd;
        skillParams.id = id;
        skillParams.ed = ed;

        // Penetration
        skillParams.pPen = pPen;
        skillParams.fPen = fPen;
        skillParams.iPen = iPen;
        skillParams.ePen = ePen;
    }



}
