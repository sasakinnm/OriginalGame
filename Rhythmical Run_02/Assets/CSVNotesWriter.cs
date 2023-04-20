using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO; //ファイルとデータ ストリームに対する読み書きを可能にする型

public class CSVNotesWriter : MonoBehaviour
{
    public string fileName; //保存するファイル名

    private MainGameController mainGameController; //他スクリプト参照①

    // Start is called before the first frame update
    void Start()
    {
        mainGameController = GameObject.Find("MainGameManager").GetComponent<MainGameController>();//他スクリプト参照②

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
