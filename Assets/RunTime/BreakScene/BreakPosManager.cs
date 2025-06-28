using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class BreakPosManager : MonoBehaviour
{
    public static BreakPosManager Instance;
    public BreakPos[] posList;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        posList = GetComponentsInChildren<BreakPos>();
        
    }
}
