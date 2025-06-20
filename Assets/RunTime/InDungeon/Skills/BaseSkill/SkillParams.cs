
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class SkillParams : SkillParamsFormat
{

    public List<ModParamType> canMods ;
    BaseSkillConfig config;
    BaseSkillChecker checker;


    protected void Start()
    {
        CacheReferences();
        ApplyParams();
        SetupChecker();
       
    }

    void CacheReferences()
    {
        config = GetComponent<BaseSkillConfig>();
        checker = GetComponent<BaseSkillChecker>();
    }

  
    void ApplyParams()
    {
        config.ExportParams(this);
        //+modsÇÃìKâûÅB

    }

    void SetupChecker()
    {
        checker.SetupChecker();
    }
}
