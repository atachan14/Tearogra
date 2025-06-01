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
        }
        else
        {
            Debug.LogError("2‚Â–Ú‚ª¶¬‚³‚ê‚Ä‚Ü‚·I");
            Destroy(gameObject); // 2ŒÂ–Ú‚ÍÁ‚·
        }
    }
}
