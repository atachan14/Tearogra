using System.Collections.Generic;
using UnityEngine;

public enum FloorCode
{
    Sample
}

public class GameDatabase : MonoBehaviour
{

    public static GameDatabase Instance { get; private set; }

    [SerializeField] private GameObject[] floorPrefabs;

    private Dictionary<FloorCode, GameObject> floorDict;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        // èâä˙âª
        floorDict = new();
        foreach (var prefab in floorPrefabs)
        {
            var code = prefab.GetComponent<FloorDataHolder>().GetCode();
            floorDict[code] = prefab;
        }
    }

    public GameObject GetFloorPrefab(FloorCode code)
    {
        if (!floorDict.TryGetValue(code, out var prefab))
        {
            Debug.LogError($"Floor prefab for {code} not found");
            return null;
        }
        return prefab;
    }


}
