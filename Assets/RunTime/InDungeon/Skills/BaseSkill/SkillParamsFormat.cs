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
    spValue,

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
public class SkillParamsFormat : MonoBehaviour
{

    [Header("Frame")]
    public float front;
    public float main;
    public float back;


    [Header("Require")]
    public float colRange = 999;
    public float cd;
    public int targetCount;

    [Header("AttackCollision")]
    public float acFrame;
    public float acLength = 1;
    public float acWidth = 1;
    public float acSpeed = 1;
    public float acWeight = 1;

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

    [Header("Other")]
    public int actNum;
    public float buff;
    public float debuff;
    public float spValue;

}
