using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class AroManager : MonoBehaviour
{
    public static AroManager Instance;
    public Dictionary<int, Unit> AroDict { get; } = new();

    public int aroCount => AroDict.Values.Count(v => v != null);

    private void Awake()
    {
        Instance = this;
    }
  

    public void FloorSetup()
    {
        //AroDictê∂ê¨Ç∆AroIdê›íË
        var aroList = GetComponentsInChildren<Unit>();
        for (int i = 0; i < 5; i++)
        {
            var unit = (i < aroList.Length) ? aroList[i] : null;
            AroDict[i] = unit;
            unit?.FloorSetup(i);
        }
    }
}
