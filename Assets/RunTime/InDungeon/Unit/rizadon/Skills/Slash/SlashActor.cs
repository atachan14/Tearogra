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
        Vector3 peakPos = startPos + Vector3.up * 0.5f; // �W�����v�̍�����0.5f�B���D�݂Œ�������B

        while (elapsed < duration)
        {
            float t = elapsed / duration;
            // �s���R���ƃW�����v���ۂ������邽�߂ɎR�Ȃ�J�[�u
            float heightFactor = Mathf.Sin(t * Mathf.PI); // 0��1��0�̃o�E���h�J�[�u

            unit.transform.position = Vector3.Lerp(startPos, startPos, 1f); // ���ړ��Ȃ��Ȃ�startPos�Œ��OK
            unit.transform.position += Vector3.up * heightFactor * 0.5f;

            elapsed += Time.deltaTime;
            yield return null;
        }

        // �I�����Ɉʒu�␳���Ă����ƒ��n������
        unit.transform.position = startPos;
    }

    protected override IEnumerator MidFrame()
    {
        Quaternion baseRot = Quaternion.identity;
        unit.transform.rotation = baseRot;

        for (int i = 0; i < count; i++)
        {
            // �U������o���iacs�����݂Ɂj
            Vector3 offset = AngleToDir() * (1 + (i * 0.1f));
            Vector3 spawnPos = transform.position + offset;
            spawnPos.z = -1f;

            BaseSkillAC g = Instantiate(acs[i % 2], spawnPos, Quaternion.Euler(0, 0, state.Angle), transform);
          
            // skillParams.main �̎��Ԃ����Ă��傢�X���āu�����V�����܂܁v�ɂ���
            float duration = skillParams.Get(ParamType.main);
            float elapsed = 0f;

            while (elapsed < duration)
            {
                float t = elapsed / duration;
                float angle = Mathf.Lerp(0f, 0, t); // 30�x�X����
                unit.transform.rotation = baseRot * Quaternion.Euler(angle, 0f, 0f);

                elapsed += Time.deltaTime;
                yield return null;
            }

            // �p�x�ێ�����i�߂��Ȃ��I�j
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
