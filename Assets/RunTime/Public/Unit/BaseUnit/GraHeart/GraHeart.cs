using UnityEngine;

public class GraHeart : MonoBehaviour
{
   void Start()
    {
        FloorSetup();
    }

   public void FloorSetup()
    {
        GetComponentInParent<Unit>().FloorSetup(null);
    }
}
