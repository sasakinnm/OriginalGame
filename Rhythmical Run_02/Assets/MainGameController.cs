using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class MainGameController : MonoBehaviour
{
    public GameObject stopButton;
    public GameObject stopDialog;

    public ScoreCount scoreCount;
    public ComboCount comboCount;

    public NotesController notesController;

    //音楽再生に使う変数
    public AudioSource audioSource;
    public float startTime = 0; //ノーツのタイミングを計算するための開始タイミングを定義する変数
    public bool isPlaying = false; //ノーツのタイミングデータを書きこむ際の条件用

    public GameObject scoreText;
    public GameObject comboText;

    //一時停止用処理
    public bool musicStop = false;


    //衝突判定用の判定オブジェクトの変数とノーツ削除処理用のフラグ
    public GameObject lineAActive;
    public GameObject lineBActive;

    public bool collisionA = false;
    public bool collisionB = false;

    //リザルト表示用のフラグ変数
    public bool isGameOver = false;
    public bool isClear = false;

    //リザルト画面の変数
    public GameObject resultGameOver;
    public GameObject resultClear;

    // Start is called before the first frame update
    void Start()
    {
        scoreCount = GameObject.Find("MainGameManager").GetComponent<ScoreCount>(); //スコアスクリプト取得
        comboCount = GameObject.Find("MainGameManager").GetComponent<ComboCount>();//コンボ数スクリプト取得

        notesController = GameObject.Find("MainGameManager").GetComponent<NotesController>();//ノーツ制御スクリプト取得

        audioSource = GameObject.Find("GameMusic").GetComponent<AudioSource>();
        Invoke("StartMusic", 3.0f); //3秒後に音楽を再生

        //シーン中のScoreTextオブジェクトを取得
        this.scoreText = GameObject.Find("ScoreText");

        //シーン中のComboTextオブジェクトを取得
        this.comboText = GameObject.Find("ComboText");

    }

    // Update is called once per frame
    void Update()
    {
        //ScoreTextに獲得した点数を表示
        this.scoreText.GetComponent<Text>().text = ("score: " + scoreCount.score);

        //コンボ1以上取得で表示
        if (comboCount.comboCount >= 1)
        {
            comboText.SetActive(true);
        }

        if (isGameOver)
        {
            resultGameOver.SetActive(true);
            audioSource.Stop();

            //クリックされたらタイトルに戻る
            if (Input.GetMouseButtonDown(0))
            {
                //TitleSceneを読み込む
                SceneManager.LoadScene("TitleScene");
            }

        }

        //最後まで再生が終わったらクリア！（進行時間が音楽の再生時間より後ろ＆isPlayingがfalse）
        if(scoreCount.score == 9000)
        {
            isClear = true;
        }

        if (isClear)
        {
            resultClear.SetActive(true);

            //クリックされたらタイトルに戻る
            if (Input.GetMouseButtonDown(0))
            {
                //TitleSceneを読み込む
                SceneManager.LoadScene("TitleScene");
            }
        }

    }

    //BGM再生トリガー
    public void StartMusic()
    {
        audioSource.Play();
        startTime = Time.time;
        isPlaying = true;
    }


    public void PushStopButton()
    {
        Time.timeScale = 0;

        //処理を一時停止
        if (isPlaying)
        {
            musicStop = true;
            audioSource.Pause();
        }
        
        stopDialog.SetActive(true);
    }


    //赤いノーツボタンを操作したときの処理※配列が0の赤いノーツを判定したい
    public void PushNoteButtonADown()
    {
        lineAActive.SetActive(true);
        collisionA = true;
    }

    public void PushNoteButtonAUp()
    {
        lineAActive.SetActive(false);
    }


    //青いノーツボタンを操作したときの処理※配列が1の青いノーツを判定したい
    public void PushNoteButtonBDown()
    {
        lineBActive.SetActive(true);
        collisionB = true;
    }

    public void PushNoteButtonBUp()
    {
        lineBActive.SetActive(false);
    }
}