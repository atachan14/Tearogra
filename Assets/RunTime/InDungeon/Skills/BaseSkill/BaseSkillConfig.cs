using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

// 実装予定
//  CanModsCreate: みたいな。
//  使用する値のModParamsをCanModsに入れる。
//  CanModsをSkillParamsに入れる処理はSkillParams.ApplyParamsに実装済み。            


public class BaseSkillConfig : MonoBehaviour
{
    public List<ModType> CanMods { get; } = new List<ModType>();

    protected SkillParams skillParams;

    private void Start()
    {
        skillParams = GetComponent<SkillParams>();
    }


    public virtual void ExportParams()
    {
        /* 
         * SkillParams側がApplyParamsで呼び出す。
         * skillParams.pp = 0 って感じで値を入れる処理を書いておく。
        */
    }


}
