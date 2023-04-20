using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleController : MonoBehaviour
{
    public GameObject easySelectButton;
    public GameObject normalSelectButton;
    public GameObject hardSelectButton;
    public GameObject startDialog;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void PushEasySelectButton()
    {
        startDialog.SetActive(true);
    }

    public void PushNormalSelectButton()
    {
        startDialog.SetActive(true);
    }

    public void PushHardSelectButton()
    {
        startDialog.SetActive(true);
    }

}