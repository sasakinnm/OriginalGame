using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ScoreCount : MonoBehaviour
{
    //一応、ココでスコアの定義や初期値を持つようにしているが、カウント処理は、NotesControllerで行っている

    private NotesController notesController;
    private ComboCount comboCount;

    //スコア計算用初期値
    public decimal score = 0;

    public decimal basicCount = 100;

    //ボーナス係数用の変数※未使用
    public decimal comboBonus = 1;

    public decimal comboSBonus = 1.5m;
    public decimal comboABonus = 1.2m;
    public decimal comboBBonus = 1.1m;

    public decimal judgmentResult = 1;

    public decimal resultPerfect = 1.5m;
    public decimal resultGood = 1;
    public decimal resultBad = 0;
    public decimal resultMiss = -100;

    //クリア条件のスコア値
    public decimal clearBorderScore = 100000;

    // Start is called before the first frame update
    void Start()
    {
        notesController = GameObject.Find("MainGameManager").GetComponent<NotesController>();
        comboCount = GameObject.Find("MainGameManager").GetComponent<ComboCount>();
    }

    // Update is called once per frame
    void Update()
    {
        if (score < 0) //結果がマイナスになる場合は、0にする
        {
           score = 0;
        }
    }

    //コンボボーナス
    void ComboBonusAddition()
    {
        if (comboCount.comboCount >= 20)
        {
            comboBonus = comboBBonus;
        }
        else if (comboCount.comboCount >= 50)
        {
            comboBonus = comboABonus;
        }
        else if (comboCount.comboCount >= 100)
        {
            comboBonus = comboSBonus;
        }
    }

    //判定ボーナス
    void judgmentResultBonusAddition()
    {

    }
}
