using UnityEngine;

public class DropItem : MonoBehaviour
{
    public static DropItem Instance;

    private void Awake()
    {
        Instance = this;
    }
}
