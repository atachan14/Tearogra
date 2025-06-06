
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
public enum ModType
{
    // Frame
    front,
    main,
    back,


    // Require
    colRange,
    ct,
    targetCount,

    // AttackCollision
    acFrame,
    acLength,
    acWidth,
    acSpeed,

    // Other
    actNum,
    buff,
    debuff,

    // Damage
    pd,
    fd,
    id,
    ed,

    // Penetration
    pPen,
    fPen,
    iPen,
    ePen
}

[System.Serializable]
public class SkillParams : MonoBehaviour
{

    [Header("Frame")]
    public float front;
    public float main;
    public float back;


    [Header("Require")]
    public float colRange;
    public float ct;
    public int targetCount;

    [Header("AttackCollision")]
    public float acFrame;
    public float acLength;
    public float acWidth;
    public float acSpeed;

    [Header("Other")]
    public int actNum;

    [Header("Damage")]
    public int pd;
    public int fd;
    public int id;
    public int ed;

    [Header("Penetration")]
    public int pPen;
    public int fPen;
    public int iPen;
    public int ePen;

    public List<ModType> canMods = new();
    BaseSkillConfig config;


    protected void Start()
    {
        CacheReferences();
        ApplyParams();
    }

    void CacheReferences()
    {
        config = GetComponent<BaseSkillConfig>();
    }

  
    void ApplyParams()
    {
        canMods = config.CanMods;
        config.ExportParams();
        //+modsÇÃìKâûÇ‡å„Ç≈é¿ëïÅB

    }
}
