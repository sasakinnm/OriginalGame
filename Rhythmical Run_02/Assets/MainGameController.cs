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

    //���y�Đ��Ɏg���ϐ�
    public AudioSource audioSource;
    public float startTime = 0; //�m�[�c�̃^�C�~���O���v�Z���邽�߂̊J�n�^�C�~���O���`����ϐ�
    public bool isPlaying = false; //�m�[�c�̃^�C�~���O�f�[�^���������ލۂ̏����p

    public GameObject scoreText;
    public GameObject comboText;

    //�ꎞ��~�p����
    public bool musicStop = false;


    //�Փ˔���p�̔���I�u�W�F�N�g�̕ϐ��ƃm�[�c�폜�����p�̃t���O
    public GameObject lineAActive;
    public GameObject lineBActive;

    public bool collisionA = false;
    public bool collisionB = false;

    //���U���g�\���p�̃t���O�ϐ�
    public bool isGameOver = false;
    public bool isClear = false;

    //���U���g��ʂ̕ϐ�
    public GameObject resultGameOver;
    public GameObject resultClear;

    // Start is called before the first frame update
    void Start()
    {
        scoreCount = GameObject.Find("MainGameManager").GetComponent<ScoreCount>(); //�X�R�A�X�N���v�g�擾
        comboCount = GameObject.Find("MainGameManager").GetComponent<ComboCount>();//�R���{���X�N���v�g�擾

        notesController = GameObject.Find("MainGameManager").GetComponent<NotesController>();//�m�[�c����X�N���v�g�擾

        audioSource = GameObject.Find("GameMusic").GetComponent<AudioSource>();
        Invoke("StartMusic", 3.0f); //3�b��ɉ��y���Đ�

        //�V�[������ScoreText�I�u�W�F�N�g���擾
        this.scoreText = GameObject.Find("ScoreText");

        //�V�[������ComboText�I�u�W�F�N�g���擾
        this.comboText = GameObject.Find("ComboText");

    }

    // Update is called once per frame
    void Update()
    {
        //ScoreText�Ɋl�������_����\��
        this.scoreText.GetComponent<Text>().text = ("score: " + scoreCount.score);

        //�R���{1�ȏ�擾�ŕ\��
        if (comboCount.comboCount >= 1)
        {
            comboText.SetActive(true);
        }

        if (isGameOver)
        {
            resultGameOver.SetActive(true);
            audioSource.Stop();

            //�N���b�N���ꂽ��^�C�g���ɖ߂�
            if (Input.GetMouseButtonDown(0))
            {
                //TitleScene��ǂݍ���
                SceneManager.LoadScene("TitleScene");
            }

        }

        //�Ō�܂ōĐ����I�������N���A�I�i�i�s���Ԃ����y�̍Đ����Ԃ���끕isPlaying��false�j
        if(scoreCount.score == 9000)
        {
            isClear = true;
        }

        if (isClear)
        {
            resultClear.SetActive(true);

            //�N���b�N���ꂽ��^�C�g���ɖ߂�
            if (Input.GetMouseButtonDown(0))
            {
                //TitleScene��ǂݍ���
                SceneManager.LoadScene("TitleScene");
            }
        }

    }

    //BGM�Đ��g���K�[
    public void StartMusic()
    {
        audioSource.Play();
        startTime = Time.time;
        isPlaying = true;
    }


    public void PushStopButton()
    {
        Time.timeScale = 0;

        //�������ꎞ��~
        if (isPlaying)
        {
            musicStop = true;
            audioSource.Pause();
        }
        
        stopDialog.SetActive(true);
    }


    //�Ԃ��m�[�c�{�^���𑀍삵���Ƃ��̏������z��0�̐Ԃ��m�[�c�𔻒肵����
    public void PushNoteButtonADown()
    {
        lineAActive.SetActive(true);
        collisionA = true;
    }

    public void PushNoteButtonAUp()
    {
        lineAActive.SetActive(false);
    }


    //���m�[�c�{�^���𑀍삵���Ƃ��̏������z��1�̐��m�[�c�𔻒肵����
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