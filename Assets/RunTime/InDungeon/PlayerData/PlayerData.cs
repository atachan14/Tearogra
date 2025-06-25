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
            Debug.LogError("2�ڂ���������Ă܂��I");
            Destroy(gameObject); // 2�ڂ͏���
        }
    }

    public void FloorSetup()
    {
        AroManager.Instance.FloorSetup();
        UI_ArosSelector.Instance.FloorSetup();
    }
}
