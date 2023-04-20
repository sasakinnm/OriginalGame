using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class MainGameController : MonoBehaviour
{
    //���y�Đ��Ɏg���ϐ�
    private AudioSource audioSource;
    public float startTime = 0; //�m�[�c�̃^�C�~���O���v�Z���邽�߂̊J�n�^�C�~���O���`����ϐ�
    public bool isPlaying = false; //�m�[�c�̃^�C�~���O�f�[�^���������ލۂ̏����p

    //�m�[�c�����Ɏg���ϐ�
    private float[] timing;
    private int[] lineNum;

    public string filePass; //�ǂݍ���CSV�̕ۑ���̕ϐ�

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GameObject.Find("GameMusic").GetComponent<AudioSource>();
        Invoke("StartMusic", 3.0f); //3�b��ɉ��y���Đ�

        LoadCSV();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //BGM�Đ��g���K�[
    public void StartMusic()
    {
        audioSource.Play();
        startTime = Time.time;
        isPlaying = true;
    }

    void LoadCSV()
    {
        TextAsset csv = Resources.Load(filePass) as TextAsset; //TextAsset��CSV�̃e�L�X�g���擾����N���X
        Debug.Log(csv.text);

        StringReader reader = new StringReader(csv.text);
    }
}
