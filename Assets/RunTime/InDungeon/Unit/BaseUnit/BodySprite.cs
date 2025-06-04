using UnityEngine;
using UnityEngine.Audio;

public class BodySprite : MonoBehaviour
{
    [SerializeField] SpriteRenderer body;
    [SerializeField] Sprite downLeft;
    [SerializeField] Sprite downRight;
    [SerializeField] Sprite upLeft;
    [SerializeField] Sprite upRight;

    UnitState state;

    public SpriteRenderer Body { get => body; }


    private void Start()
    {
        state = GetComponentInParent<UnitState>();
    }

    void Update()
    {
        float angle = state.Angle;
        if (angle < -90)
        {
            body.sprite = downLeft;
        }

        else if (angle < 0)
        {
            body.sprite = downRight;
        }

        else if (angle < 90)
        {
            body.sprite = upRight;
        }
        else
        {
            body.sprite = upLeft;
        }

    }
}
