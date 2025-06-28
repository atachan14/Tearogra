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

        //aro�������瑼��Hole����鏈����Manager�Ɉ˗�
        if (unit.AroId != null) { manager.ShutterHole(this); }

        // Aro���̏����Ăяo���i�A�j���Ƃ����[�v�Ƃ��j
        unit.GoHole(transform);  



    }

    public void Close()
    {
        isClosed = true;
        gameObject.SetActive(false); // ��\�����i�����I�ɏ����Ȃ�Destroy�ł�OK�j
    }
}
