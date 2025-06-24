using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.GPUSort;

public class AroManager : MonoBehaviour
{
    public static AroManager Instance { get; private set; }
    private Dictionary<int, Unit> idToUnit = new();
    private Dictionary<Unit, int> unitToId = new();

    void Awake()
    {
        if (Instance != null) Destroy(this);
        else Instance = this;
    }

   
}
