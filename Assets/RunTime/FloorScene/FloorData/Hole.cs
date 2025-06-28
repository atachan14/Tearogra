using Unity.Burst.Intrinsics;
using UnityEngine;

public class Hole : MonoBehaviour
{
    private bool isClosed = false;
    private HoleManager manager;

    private void Awake()
    {
        manager = GetComponentInParent<HoleManager>();
        manager.RegisterHole(this); // 自動登録
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isClosed) return;

        Unit unit = collision.GetComponent<Unit>();

        //aroだったら他のHoleを閉じる処理をManagerに依頼
        if (unit.AroId != null) { manager.ShutterHole(this); }

        // Aro側の処理呼び出し（アニメとかワープとか）
        unit.GoHole(transform);  



    }

    public void Close()
    {
        isClosed = true;
        gameObject.SetActive(false); // 非表示化（物理的に消すならDestroyでもOK）
    }
}
