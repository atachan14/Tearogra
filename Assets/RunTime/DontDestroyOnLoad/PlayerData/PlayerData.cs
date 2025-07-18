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
            Debug.Log("2つ目が生成されてます！");
            Destroy(gameObject); // 2個目は消す
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
