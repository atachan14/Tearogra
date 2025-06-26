using UnityEngine;

public class Dui_Manager : MonoBehaviour
{
    public static Dui_Manager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void FloorSetup()
    {
        UI_ArosSelector.Instance.FloorSetup();
        UI_DmgGraph.Instance.FloorSetup();

    }
}
