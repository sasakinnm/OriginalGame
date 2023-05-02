using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class NotesController : MonoBehaviour
{
    private MainGameController mainGameController; //他スクリプト参照①
    public ScoreCount scoreCount;

    //ノーツ生成に使う変数
    public GameObject[] notesPrefab;

    private float[] timing;
    private int[] lineNum;

    public string filePass; //読み込むCSVの保存先の変数
    public int notesCount = 0;

    public float timeOffset = -1;


    //判定に使うオブジェクトの取得
    public GameObject buttonA;
    public GameObject buttonB;

    //生成したノーツの変数
    public GameObject[] notes;

    // Start is called before the first frame update
    void Start()
    {
        mainGameController = GameObject.Find("MainGameManager").GetComponent<MainGameController>();//他スクリプト参照②
        scoreCount = GameObject.Find("MainGameManager").GetComponent<ScoreCount>(); //スコアスクリプト取得

        timing = new float[1024];//セルの行数
        lineNum = new int[1024];//セルの行数

        LoadCSV();

        //判定に使うオブジェクトの取得
        buttonA = GameObject.Find("ButtonA");
        buttonB = GameObject.Find("ButtonB");

        //ノーツ配列の大きさ
        notes = new GameObject[1024];

    }

    //CSVを読み込む
    void LoadCSV()
    {
        TextAsset csv = Resources.Load(filePass) as TextAsset; //TextAsset→CSVのテキストを取得するクラス
        Debug.Log(csv.text);

        StringReader reader = new StringReader(csv.text);

        int i = 0;
        while (reader.Peek() > -1)
        {

            string line = reader.ReadLine();
            string[] values = line.Split(',');
            for (int j = 0; j < values.Length; j++)
            {
                timing[i] = float.Parse(values[0]);
                lineNum[i] = int.Parse(values[1]);
            }
            i++;

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (mainGameController.isPlaying)
        {
            CheckNextNotes();
            moveNotes();
            
        }

    }

    void CheckNextNotes()//タイミングに合わせてノーツの生成を実行する関数
    {
        while (timing[notesCount] -1.5 + timeOffset < GetMusicTime() && timing[notesCount] != 0)
        {
            SpawnNotes(lineNum[notesCount]);
            notesCount++;

        }
    }

    float GetMusicTime()
    {
        return Time.time - mainGameController.startTime;
    }

    void SpawnNotes(int num) //ノーツの生成関数。ここで生成したものを別の関数で移動処理を行う場合は、ここで生成したprefabをメンバ変数に代入しなければならない
    {
        notes[notesCount] = Instantiate(notesPrefab[num], new Vector3(10, 2.15f + (2.5f * -num), 0), Quaternion.identity); //ノーツの生成位置。縦列に並べるので、可変はY軸
    }

    void moveNotes() //ノーツの移動処理
    {
        for (int i = 0; i < 1024; i++)
        {
            if (notes[i] != null)
            {
                notes[i].transform.position += Vector3.left * 5 * Time.deltaTime;
                Debug.Log(notes[i].transform.position.x);

                //判定範囲をすり抜けた結果
                if (notes[i].transform.position.x < -5.0f)
                {
                    if (scoreCount.score >= 1)
                    {
                        Destroy(notes[i]);
                        scoreCount.score += scoreCount.resultMiss;
                    }
                    else
                    {
                        Destroy(notes[i]);
                        mainGameController.isGameOver = true;
                    }
                }

                else if (mainGameController.collisionA)
                {
                    //判定範囲に入ったら削除したい
                    if (notes[i].transform.position.x <= mainGameController.lineAActive.transform.position.x + 0.5 && notes[i].transform.position.y >= mainGameController.lineAActive.transform.position.y)
                    {
                        Destroy(notes[i]);
                        scoreCount.score += scoreCount.basicCount;
                    }

                    mainGameController.collisionA = false;

                }

                else if (mainGameController.collisionB)
                {
                    //判定範囲に入ったら削除したい
                    if (notes[i].transform.position.x <= mainGameController.lineBActive.transform.position.x + 0.5 && notes[i].transform.position.y <= mainGameController.lineBActive.transform.position.y)
                    {
                        Destroy(notes[i]);
                        scoreCount.score += scoreCount.basicCount;
                    }

                    mainGameController.collisionB = false;

                }

            }

        }

    }

}