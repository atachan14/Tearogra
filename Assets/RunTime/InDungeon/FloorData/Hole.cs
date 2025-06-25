using Unity.Burst.Intrinsics;
using UnityEngine;

public class Hole : MonoBehaviour
{
    private bool isClosed = false;
    private HoleManager manager;

    private void Awake()
    {
        manager = GetComponentInParent<HoleManager>();
        manager.RegisterHole(this); // �����o�^
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isClosed) return;

        Unit unit = collision.GetComponent<Unit>();
        unit.GoHole(transform);  // Aro���̏����Ăяo���i�A�j���Ƃ����[�v�Ƃ��j

        AroHeart aroHeart = unit.GetComponentInChildren<AroHeart>();
        if (aroHeart != null)
        {
            manager.NotifyHoleEntered(this, unit);
           
        }
    }

    public void Close()
    {
        isClosed = true;
        gameObject.SetActive(false); // ��\�����i�����I�ɏ����Ȃ�Destroy�ł�OK�j
    }
}
