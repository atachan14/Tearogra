using UnityEngine;

public class FloorDataHolder : MonoBehaviour
{
    [SerializeField] FloorCode floorCode;
    [SerializeField] Sprite floorIcon;

    public FloorCode GetCode()
    {
        return floorCode;
    }
}
