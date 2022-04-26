using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NonPlayerCharacter : MonoBehaviour
{
    public float SpeakTime = 4.0f;
    public GameObject dialogBox;
    private int Page = 1;
    Timer timer;
    public GameObject dlgTxtProGameObject;
    TextMeshProUGUI _tmTxtBox;
    // Start is called before the first frame update
    void Start()
    {
        dialogBox.SetActive(false);
        timer = gameObject.AddComponent<Timer>();
        _tmTxtBox = dlgTxtProGameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.OnTimer() == true)
        {
            HideDialogBox();
        }
    }

    public void ShowDialogBox()
    {        
        timer.SetTimer(SpeakTime);
        dialogBox.SetActive(true);
        RevertPage();
    }

    public void HideDialogBox()
    {
        dialogBox.SetActive(false);
        timer.CloseTimer();
    }

    public void ChangeDialogBox(HeroAttribute hero)
    {
        Debug.Log($"dialogBox.activeSelf = {dialogBox.activeSelf}");
        if (hero == null)
        {
            return;
        }
        if (!dialogBox.activeSelf)
        {
            hero.SetTalkState(true);
            ShowDialogBox();
        }
        else
        {
            hero.SetTalkState(false);
            HideDialogBox();
        }
    }

    public void ChangePage()
    {
        int Amount = _tmTxtBox.textInfo.pageCount;
        if (Page < Amount)
        {
            Page = Page + 1;            
        }
        else
        {
            RevertPage();
        }
        _tmTxtBox.pageToDisplay = Page;
        timer.ResetTimer();
    }

    private void RevertPage()
    {
        Page = 1;
    }
}
