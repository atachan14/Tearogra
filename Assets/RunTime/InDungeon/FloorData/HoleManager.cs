using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class HoleManager : MonoBehaviour
{
    private List<Hole> holes = new(); // Inspector�Ŏ����擾�ł�����
    private Hole selectedHole;
    private HashSet<Unit> enteredAros = new();

    public void RegisterHole(Hole h) { if (!holes.Contains(h)) holes.Add(h); }

    public bool IsLocked => selectedHole != null;

    public void NotifyHoleEntered(Hole hole, Unit aro)
    {
        if (selectedHole == null)
        {
            selectedHole = hole;
            foreach (var h in holes)
            {
                if (h != hole) h.Close(); // Close()�͎���֐�
            }
        }

        if (hole == selectedHole)
        {
            if (!enteredAros.Contains(aro))
                enteredAros.Add(aro);

            if (enteredAros.Count >= UI_ArosSelector.Instance.aroList.Length)
            {
                FloorClear(); // �S��������
            }
        }
    }

    void FloorClear()
    {
        Debug.Log("Floor Cleared!");
        // UI���o�ȂǂɌq��
    }
}
