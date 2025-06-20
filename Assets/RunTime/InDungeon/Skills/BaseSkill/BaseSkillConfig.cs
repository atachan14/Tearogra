using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

// �����\��
//  CanModsCreate: �݂����ȁB
//  �g�p����l��ModParams��CanMods�ɓ����B
//  CanMods��SkillParams�ɓ���鏈����SkillParams.ApplyParams�Ɏ����ς݁B            


public class BaseSkillConfig : SkillParamsFormat
{
    public List<ModParamType> canMods  = new();



    private void Awake()
    {
        SetupInitial();
    }
    protected virtual void SetupInitial()
    {
        //�����l�̐ݒ�
    }

    private void Start()
    {
        CashRefarence();
    }

    protected virtual void CashRefarence()
    {
    }

    public virtual void ExportParams(SkillParams skillParams)    //SkillParams����Ăяo�����
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
