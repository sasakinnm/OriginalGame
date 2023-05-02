using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class StopDialogController : MonoBehaviour
{
    public GameObject continueButton;
    public GameObject retireButton;
    public GameObject stopDialog;

    public ScoreCount scoreCount;

    public MainGameController mainGameController;

    // Start is called before the first frame update
    void Start()
    {
        scoreCount = GameObject.Find("MainGameManager").GetComponent<ScoreCount>(); //�X�R�A�X�N���v�g�擾
        mainGameController = GameObject.Find("MainGameManager").GetComponent<MainGameController>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PushContinueButton()
    {
        stopDialog.SetActive(false);

        //�������ĊJ
        if (mainGameController.musicStop)
        {
            mainGameController.audioSource.Play();
        }
        Time.timeScale = 1;
    }

    public void PushRetireButton()
    {
        SceneManager.LoadScene("TitleScene");
    }

}
