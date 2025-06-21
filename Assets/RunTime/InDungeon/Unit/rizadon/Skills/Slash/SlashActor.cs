using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashActor : BaseSkillActor
{
    [SerializeField] BaseSkillAC[] acs = new BaseSkillAC[1];

    int count = 1;
    protected override IEnumerator FrontFrame()
    {
        float duration = skillParams.Get(ParamType.front);
        float elapsed = 0f;

        Vector3 startPos = unit.transform.position;
        Vector3 peakPos = startPos + Vector3.up * 0.5f; // ジャンプの高さは0.5f。お好みで調整しろ。

        while (elapsed < duration)
        {
            float t = elapsed / duration;
            // ピョコンとジャンプっぽく見せるために山なりカーブ
            float heightFactor = Mathf.Sin(t * Mathf.PI); // 0→1→0のバウンドカーブ

            unit.transform.position = Vector3.Lerp(startPos, startPos, 1f); // 横移動なしならstartPos固定でOK
            unit.transform.position += Vector3.up * heightFactor * 0.5f;

            elapsed += Time.deltaTime;
            yield return null;
        }

        // 終了時に位置補正してちゃんと着地させる
        unit.transform.position = startPos;
    }

    protected override IEnumerator MidFrame()
    {
        Quaternion baseRot = Quaternion.identity;
        unit.transform.rotation = baseRot;

        for (int i = 0; i < count; i++)
        {
            // 攻撃判定出す（acsを交互に）
            Vector3 offset = AngleToDir() * (1 + (i * 0.1f));
            Vector3 spawnPos = transform.position + offset;
            spawnPos.z = -1f;

            BaseSkillAC g = Instantiate(acs[i % 2], spawnPos, Quaternion.Euler(0, 0, state.Angle), transform);
          
            // skillParams.main の時間かけてちょい傾けて「お辞儀したまま」にする
            float duration = skillParams.Get(ParamType.main);
            float elapsed = 0f;

            while (elapsed < duration)
            {
                float t = elapsed / duration;
                float angle = Mathf.Lerp(0f, 0, t); // 30度傾ける
                unit.transform.rotation = baseRot * Quaternion.Euler(angle, 0f, 0f);

                elapsed += Time.deltaTime;
                yield return null;
            }

            // 角度維持する（戻さない！）
        }
    }


    protected override IEnumerator BackFrame()
    {
        Quaternion startRot = unit.transform.rotation;
        Quaternion targetRot = Quaternion.identity;

        float duration = skillParams.Get(ParamType.back);
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float t = elapsed / duration;
            unit.transform.rotation = Quaternion.Slerp(startRot, targetRot, t);

            elapsed += Time.deltaTime;
            yield return null;
        }

        unit.transform.rotation = targetRot;

        count++;
        if (count > skillParams.Get(ParamType.actNum))
        {
            count = 1;
        }
    }


}
