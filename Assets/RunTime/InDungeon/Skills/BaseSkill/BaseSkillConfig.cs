using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

// �����\��
//  CanModsCreate: �݂����ȁB
//  �g�p����l��ModParams��CanMods�ɓ����B
//  CanMods��SkillParams�ɓ���鏈����SkillParams.ApplyParams�Ɏ����ς݁B            


public class BaseSkillConfig : MonoBehaviour
{
    public List<ModType> CanMods { get; } = new List<ModType>();

    protected SkillParams skillParams;

    private void Start()
    {
        skillParams = GetComponent<SkillParams>();
    }


    public virtual void ExportParams()
    {
        /* 
         * SkillParams����ApplyParams�ŌĂяo���B
         * skillParams.pp = 0 ���Ċ����Œl�����鏈���������Ă����B
        */
    }


}
