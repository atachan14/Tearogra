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
    ePen,

    // PenetrationPercent
    pPenPer,
    fPenPer,
    iPenPer,
    ePenPer
}
public static class ElementColor
{
    private static readonly Dictionary<Element, Color> colorMap = new()
    {
        { Element.Physic, new Color(0.5f, 0.5f, 0.5f) }, // �O���[
        { Element.Fire, new Color(1f, 0.3f, 0.1f) },     // �Ԍn
        { Element.Ice, new Color(0.5f, 0.8f, 1f) },      // ���F�n
        { Element.Volt, new Color(1f, 1f, 0.2f) },       // ���F�n
    };

    public static Color GetColor(Element e)
    {
        return colorMap.TryGetValue(e, out var c) ? c : Color.white;
    }
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

    [Header("PenetrationPercent")]
    public int pPenPer;
    public int fPenPer;
    public int iPenPer;
    public int ePenPer;

    [Header("Other")]
    public int actNum;
    public float buff;
    public float debuff;
    public float spValue;

}
