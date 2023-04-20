using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class MainGameController : MonoBehaviour
{
    //音楽再生に使う変数
    private AudioSource audioSource;
    public float startTime = 0; //ノーツのタイミングを計算するための開始タイミングを定義する変数
    public bool isPlaying = false; //ノーツのタイミングデータを書きこむ際の条件用

    //ノーツ生成に使う変数
    private float[] timing;
    private int[] lineNum;

    public string filePass; //読み込むCSVの保存先の変数

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GameObject.Find("GameMusic").GetComponent<AudioSource>();
        Invoke("StartMusic", 3.0f); //3秒後に音楽を再生

        LoadCSV();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //BGM再生トリガー
    public void StartMusic()
    {
        audioSource.Play();
        startTime = Time.time;
        isPlaying = true;
    }

    void LoadCSV()
    {
        TextAsset csv = Resources.Load(filePass) as TextAsset; //TextAsset→CSVのテキストを取得するクラス
        Debug.Log(csv.text);

        StringReader reader = new StringReader(csv.text);
    }
}
