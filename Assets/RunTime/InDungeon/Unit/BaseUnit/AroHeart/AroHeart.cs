using UnityEngine;

public class AroHeart : MonoBehaviour
{
    SkillManager skills;
    int defaultSearcherLayer;
    void Start()
    {
        skills =GetComponentInParent<Unit>().GetComponentInChildren<SkillManager>();
        defaultSearcherLayer = LayerMask.NameToLayer("AroSearcher");

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
