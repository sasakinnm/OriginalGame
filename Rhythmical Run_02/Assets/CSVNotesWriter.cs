using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO; //�t�@�C���ƃf�[�^ �X�g���[���ɑ΂���ǂݏ������\�ɂ���^

public class CSVNotesWriter : MonoBehaviour
{
    public string fileName; //�ۑ�����t�@�C����

    private MainGameController mainGameController; //���X�N���v�g�Q�Ƈ@

    // Start is called before the first frame update
    void Start()
    {
        mainGameController = GameObject.Find("MainGameManager").GetComponent<MainGameController>();//���X�N���v�g�Q�ƇA

    }

    // Update is called once per frame
    void Update()
    {
        if (mainGameController.isPlaying)
        {
            DetectKeys();
        }
    }

    public void WriteCSV(string txt)
    {
        StreamWriter streamWriter;
        FileInfo fileInfo;
        fileInfo = new FileInfo(Application.dataPath + "/" + fileName + ".csv");
        streamWriter = fileInfo.AppendText();
        streamWriter.WriteLine(txt);
        streamWriter.Flush();
        streamWriter.Close();
    }

    void DetectKeys()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            WriteNotesTiming(0);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            WriteNotesTiming(1);
        }
    }

    void WriteNotesTiming(int num)
    {
        Debug.Log(GetTiming());
        WriteCSV(GetTiming().ToString() + "," + num.ToString());
    }

    float GetTiming()
    {
        return Time.time - mainGameController.startTime;
    }
}
