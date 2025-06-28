using TMPro;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    [SerializeField] float lifetime = 1.0f;
    [SerializeField] float floatSpeed = 1.5f;
    [SerializeField] float gravity = 2.5f;

    private TextMeshPro tmp;
    private float timeElapsed;
    private Vector3 velocity;

    private void Awake()
    {
        tmp = GetComponent<TextMeshPro>();
        // �����_���ɍ��E�ɂ�����ƎU�炷
        velocity = new Vector3(Random.Range(-0.5f, 0.5f), floatSpeed, 0);
    }

    public void InitDamage(Element type, int value)
    {
        tmp.text = value.ToString();
        tmp.color = ElementColor.GetColor(type);
    }

    private void Update()
    {
        timeElapsed += Time.deltaTime;

        // ���������鋓��
        velocity.y -= gravity * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;

        if (timeElapsed >= lifetime)
            Destroy(gameObject);
    }
}





