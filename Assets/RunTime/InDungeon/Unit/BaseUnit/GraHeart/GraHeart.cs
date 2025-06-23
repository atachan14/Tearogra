using UnityEngine;

public class GraHeart : MonoBehaviour
{
   void Start()
    {
        GetComponentInParent<Unit>().SetupUnit();
    }
}
