using UnityEngine;

public class CreatureSprite : MonoBehaviour
{
    [SerializeField] SpriteRenderer body;
    [SerializeField] SpriteRenderer aroSelecterIcon;
    [SerializeField] SpriteRenderer aroStatusIcon;
   
    public SpriteRenderer Body { get => body;}
    public SpriteRenderer AroSelecterIcon { get => aroSelecterIcon; }
    public SpriteRenderer AroStatusIcon { get => aroStatusIcon;  }
}
