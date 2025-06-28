using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertEffect : MonoBehaviour
{
    [SerializeField] float bigToSmallTime = 0.5f;
    [SerializeField] float smallToZeroTime = 1f;
    [SerializeField] Vector3 bigPos = new Vector3(0f, 0.55f, 0f);
    [SerializeField] Vector3 bigScale = new Vector3(0.8f, 0.8f, 1f);
    [SerializeField] Vector3 smallPos = new Vector3(0f, 0.4f, 0f);
    [SerializeField] Vector3 smallScale = new Vector3(0.5f, 0.5f, 1f);

    public void ExecuteFound(float bigFrame)
    {
        StartCoroutine(ExecuteFoundCoroutine(bigFrame));
    }

    private IEnumerator ExecuteFoundCoroutine(float bigFrame)
    {
        transform.localPosition = bigPos;
        transform.localScale = bigScale;
        yield return new WaitForSeconds(bigFrame);

        //bitToSmall
        float duration = bigToSmallTime;
        float timer = 0f;

        Vector3 startPos = transform.localPosition;
        Vector3 startScale = transform.localScale;

        while (timer < duration)
        {
            timer += Time.deltaTime;
            float t = timer / duration;

            transform.localPosition = Vector3.Lerp(startPos, smallPos, t);
            transform.localScale = Vector3.Lerp(startScale, smallScale, t);

            yield return null;
        }

        transform.localPosition = smallPos;
        transform.localScale = smallScale;
    }

    public void ExecuteLost()
    {
        StartCoroutine(ExecuteLostCoroutine());
    }

    private IEnumerator ExecuteLostCoroutine()
    {
        // SmallToZero
        float duration = smallToZeroTime;
        float timer = 0f;

        Vector3 startPos = transform.localPosition;
        Vector3 startScale = transform.localScale;

        while (timer < duration)
        {
            timer += Time.deltaTime;
            float t = timer / duration;

            transform.localPosition = Vector3.Lerp(startPos, Vector3.zero, t);
            transform.localScale = Vector3.Lerp(startScale, Vector3.zero, t);

            yield return null;
        }

        // 最終値をしっかり代入（誤差修正）
        transform.localPosition = Vector3.zero;
        transform.localScale = Vector3.zero;
    }
}
