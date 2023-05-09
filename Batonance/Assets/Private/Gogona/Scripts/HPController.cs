using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPController : MonoBehaviour, IDamagable
{
    [SerializeField, Tooltip("最大HP")]
    private float maxHP;
    [SerializeField, Tooltip("現在HP")]
    private float currentHP;
    [SerializeField, Tooltip("HPバー")]
    private Slider hPBar;

    // Start is called before the first frame update
    void Start()
    {
        // 現在HPを最大HPにする
        currentHP = maxHP;
        hPBar.value = currentHP / maxHP;
    }

    /// <summary>
    /// ダメージを受けた時に呼び出す
    /// </summary>
    /// <param name="damage"></param>
    public void Damage(float damage)
    {
        // ダメージ分減少
        currentHP -= damage;
        hPBar.value = currentHP / maxHP;

        // 現在HPが0以下なら
        if (currentHP <= 0) {
            // ゲームオブジェクトを破壊
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// キャラクタのHPの取得
    /// </summary>
    /// <param name="hP"></param>
    public void GetCharHP(float hP)
    {
        maxHP = hP;
    }
}
