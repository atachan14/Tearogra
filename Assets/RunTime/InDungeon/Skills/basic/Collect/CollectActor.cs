using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class CollectActor : BaseSkillActor
{
    public GameObject TargetItem { get; set; }
    protected override IEnumerator FrontFrame()
    {
        float duration = skillParams.Get(ParamType.front);
        float elapsed = 0f;

        Vector3 originalScale = unit.transform.localScale;
        Vector3 shrinkScale = originalScale * 0.5f;

        float cycleDuration = duration;
        float halfCycle = cycleDuration / 2f;

        while (elapsed < duration)
        {
            float cycleTime = elapsed % cycleDuration;

            if (cycleTime < halfCycle)
            {
                // k‚ÞF0¨1
                float t = cycleTime / halfCycle;
                unit.transform.localScale = Vector3.Lerp(originalScale, shrinkScale, t);
            }
            else
            {
                // –ß‚éF0¨1i‹t•ûŒüj
                float t = (cycleTime - halfCycle) / halfCycle;
                unit.transform.localScale = Vector3.Lerp(shrinkScale, originalScale, t);
            }

            elapsed += Time.deltaTime;
            yield return null;
        }

        unit.transform.localScale = originalScale;
    }


    protected override IEnumerator MidFrame()
    {
        if (!TargetItem) yield break;
        TargetItem.GetComponent<BaseItem>().Collect(unit);
        yield return null ;
    }
    protected override void Enter()
    {
        state.SkillState.Clear();
        state.SkillState.Add(this);
    }
}
