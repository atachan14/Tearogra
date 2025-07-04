using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static PlayerData Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Debug.Log("2‚Â–Ú‚ª¶¬‚³‚ê‚Ä‚Ü‚·I");
            Destroy(gameObject); // 2ŒÂ–Ú‚ÍÁ‚·
        }
    }

    public void FloorSetup()
    {
        AroManager.Instance.FloorSetup();
        FloorCanvas.Instance.FloorSetup();
    }

    public void BreakSetup()
    {
        AroManager.Instance.BreakSetup();
    }
}
