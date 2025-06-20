using System.Collections.Generic;
using UnityEngine;

public static class ElementColor
{
    private static readonly Dictionary<Element, Color> colorMap = new()
    {
        { Element.Physic, new Color(0.5f, 0.5f, 0.5f) }, // ÉOÉåÅ[
        { Element.Fire, new Color(1f, 0.3f, 0.1f) },     // ê‘ån
        { Element.Ice, new Color(0.5f, 0.8f, 1f) },      // êÖêFån
        { Element.Volt, new Color(1f, 1f, 0.2f) },       // â©êFån
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
    public float targetCount;

    [Header("AttackCollision")]
    public float acFrame;
    public float acLength = 1;
    public float acWidth = 1;
    public float acSpeed = 1;
    public float acWeight = 1;

    [Header("Damage")]
    public float pd;
    public float fd;
    public float id;
    public float ed;

    [Header("Penetration")]
    public float pPen;
    public float fPen;
    public float iPen;
    public float ePen;

    [Header("PenetrationPercent")]
    public float pPenPer;
    public float fPenPer;
    public float iPenPer;
    public float ePenPer;

    [Header("Other")]
    public float actNum;
    public float buff;
    public float debuff;
    public float spValue;

    
    public float Round1(float value)
    {
        return Mathf.Round(value * 10f) / 10f;
    }
}
