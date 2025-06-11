using UnityEngine;

public class MainCamController : MonoBehaviour
{
    [SerializeField] float speed = 1f;

    public void Scroll(Vector3 delta)
    {
        Vector3 move = new Vector3(-delta.x, -delta.y, 0f) * speed * Time.deltaTime;
        transform.position += move;
    }

}
