using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ScoreCount : MonoBehaviour
{
    //�ꉞ�A�R�R�ŃX�R�A�̒�`�⏉���l�����悤�ɂ��Ă��邪�A�J�E���g�����́ANotesController�ōs���Ă���

    private NotesController notesController;
    private ComboCount comboCount;

    //�X�R�A�v�Z�p�����l
    public decimal score = 0;

    public decimal basicCount = 100;

    //�{�[�i�X�W���p�̕ϐ������g�p
    public decimal comboBonus = 1;

    public decimal comboSBonus = 1.5m;
    public decimal comboABonus = 1.2m;
    public decimal comboBBonus = 1.1m;

    public decimal judgmentResult = 1;

    public decimal resultPerfect = 1.5m;
    public decimal resultGood = 1;
    public decimal resultBad = 0;
    public decimal resultMiss = -100;

    //�N���A�����̃X�R�A�l
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
        if (score < 0) //���ʂ��}�C�i�X�ɂȂ�ꍇ�́A0�ɂ���
        {
           score = 0;
        }
    }

    //�R���{�{�[�i�X
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

    //����{�[�i�X
    void judgmentResultBonusAddition()
    {

    }
}
