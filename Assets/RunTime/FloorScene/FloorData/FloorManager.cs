using UnityEngine;

public class FloorManager : MonoBehaviour
{
    void Start()
    {
        FloorSetup();
    }

    void FloorSetup()
    {
        BuildFloor();
        PlayerData.Instance.FloorSetup();
        StartPosManager.Instance.AroSetPosition();
    }

    void BuildFloor()
    {
        FloorCode code = GameManager.Instance.NextFloor;
        GameObject prefab = GameDatabase.Instance.GetFloorPrefab(code);
        Instantiate(prefab);

    }

}
