using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/*
// 別スクリプトからエフェクトを再生する例
int effectIndex = 0; // 再生したいエフェクトのインデックス
GetComponent<EffectManager>().PlayEffect(effectIndex);
*/

public class EffectManager : MonoBehaviour
{
    public static EffectManager instance;
    public List<ParticleSystem> effectList = new List<ParticleSystem>();

    private void Awake()
    {
        if (!instance) instance = this;
        else Destroy(this);
    }

    private void Start()
    {
        for (int i = 0; i < effectList.Count(); i++)
        {
            effectList[i].Stop();
        }
    }

    // エフェクトを再生するための関数
    public void PlayEffect(int index)
    {
        if (index >= 0 && index < effectList.Count)
        {
            effectList[index].Play();
            // ここでエフェクトの位置や他のパラメータを設定できます
            // 例: effect.transform.position = transform.position;
        }
        else
        {
            Debug.LogError("Invalid index for effect.");
        }
    }

    public void ResetEffectTime(int index)
    {
        if (index >= 0 && index < effectList.Count)
        {
            effectList[index].Stop();
            effectList[index].time = 0;
        }
        else Debug.LogError("Invalid index for effect.");
    }
}
