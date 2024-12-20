using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.CompilerServices;
using UnityEngine.Playables;
using UnityEditor.UI;
using UnityEngine.UIElements;
using System;

public class gs_loading : MonoBehaviour
{
    [Header("Page Managers")]
    [SerializeField] private Canvas[] arr_Screens;
    [SerializeField] private int currentPage = 0;
    [SerializeField] private int selectedLevel = 2;

    [Header("Web")]
    [SerializeField] private gs_web web;


    [Header("Fields")]
    [SerializeField] private UnityEngine.UI.Image bar;
    [SerializeField] private GameObject gsnote;
    [SerializeField] private Transform terminal;
    [SerializeField] public InputField loginUser, loginPass;

    //vars
    private int errcount = 0;
    private string localUsername, localPassword;


    //private shit
    private string[] maps = { "mainMenu", "Easy Street"};

    private void Awake()
    {
        pageManager();
    }


    // ------------------------------------------------------------------------
    #region PAGE MANAGERS
    public void pageManager()
    {
        foreach (var screen in arr_Screens)
        {
            hidePage(screen);
        }

        for (int i = 0; i < arr_Screens.Length; i++)
        {
            if (currentPage == i)
            {
                showPage(arr_Screens[i]);
            }
        }
    }

    public void setPage(int pageIndex)
    {
        currentPage = pageIndex;
        pageManager();
    }
    private void showPage(Canvas page)
    {
        //page.enabled = true;
        page.gameObject.SetActive(true);
    }
    private void hidePage(Canvas page)
    {
        //page.enabled = false;
        page.gameObject.SetActive(false);
    }

    #endregion
    #region LEVEL LOADERS
    IEnumerator LoadLevelASync(int levelToLoad)
    {
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(levelToLoad);
        while (loadOperation.isDone)
        {
            float progressValue = Mathf.Clamp01(loadOperation.progress / 0.9f);
            bar.fillAmount = progressValue;
            yield return null;
        }
    }
    #endregion
    #region BUTTONS
    public void btn_LoadLevel()
    {
        currentPage = 3;
        pageManager();
        StartCoroutine(LoadLevelASync(selectedLevel));
    }
    public void btn_login()
    {
        login();
    }
    public void btn_toLog()
    {
        currentPage = 1;
        pageManager();
    }
    public void btn_toReg()
    {
        currentPage = 0;
        pageManager();
    }
    public void btn_chooseLevel()
    {
        currentPage = 2;
        pageManager();
    }
    #endregion
    #region AUTHENTICATORS
    private bool checkTextField(InputField field)
    {
        string trimmedText = field.text.Trim();
        if (field.text != "")
        {
            return true;
        }
        return false;
    }

    private void login()
    {

        if(checkTextField(loginUser) && checkTextField(loginPass))
        {
            pingTerminal("Attempting to Login...");
            web.loggy(loginUser.text, loginPass.text);
        }
        else
        {
            pingTerminal("Missing Credentials");
        }
    }

    #endregion
    #region NOTIFICATION BULLSHIT
    private void pingTerminal(string noteText)
    {
        Debug.Log("Terminal:\t" + noteText);
        GameObject notes = Instantiate(gsnote,terminal,false);
        notes.GetComponentInChildren<gs_Notification>().updateText(noteText);
    }

    #endregion


}
