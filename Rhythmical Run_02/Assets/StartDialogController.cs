using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartDialogController : MonoBehaviour
{
    public GameObject canselButton;
    public GameObject startButton;
    public GameObject startDialog;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PushCancelButton()
    {
        startDialog.SetActive(false);
    }

    public void PushStartButton()
    {
        SceneManager.LoadScene("MainGameScene");
    }
}
