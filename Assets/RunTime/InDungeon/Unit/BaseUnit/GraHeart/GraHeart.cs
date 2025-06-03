using UnityEngine;

public class GraHeart : MonoBehaviour
{
    UnitSkills skills;
    int defaultSearcherLayer;
    void Start()
    {
        skills = GetComponentInParent<Unit>().GetComponentInChildren<UnitSkills>();
        defaultSearcherLayer = LayerMask.NameToLayer("GraSearcher");

        SetLayerToAllRequireCheckers(defaultSearcherLayer);

    }

    void SetLayerToAllRequireCheckers(int layer)
    {
        var checkers = skills.GetComponentsInChildren<IRequireChecker>(true);
        foreach (var checker in checkers)
        {
            var go = ((MonoBehaviour)checker).gameObject;
            go.layer = layer;
        }
    }
}
