using UnityEngine;

public class FloorManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        FloorSetup();
    }

    void FloorSetup()
    {
        PlayerData.Instance.FloorSetup();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
