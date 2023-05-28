using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HPController))]
public class EnemyBase : MonoBehaviour
{
    [SerializeField, Tooltip("キャラクタのID")]
    private int charId;
    private EnemyDataBase.EnemyData data;

    // 各クラスの取得
    private HPController hPCtrl;
    private EnemyAttack enemyAtk;
    private EnemyMovement enemyMov;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        // データベースからキャラデータを取得
        data = DataBaseManager.instance.GetEnemyData(charId);
        GetClassData();
    }

    // Start is called before the first frame update
    void Start()
    {
        hPCtrl.GetCharHP(data.baseHP);
        enemyAtk.GetEnemyAtk(data.baseAtk);
        enemyMov.GetEnemySpeed(data.baseSpd);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// 各クラスのデータを取得
    /// </summary>
    private void GetClassData()
    {
        hPCtrl = GetComponent<HPController>();
        enemyAtk = GetComponent<EnemyAttack>();
        enemyMov = GetComponent<EnemyMovement>();
    }
}