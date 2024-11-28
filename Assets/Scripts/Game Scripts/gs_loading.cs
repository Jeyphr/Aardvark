using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.CompilerServices;

public class gs_loading : MonoBehaviour
{
    [SerializeField] private Canvas[]   arr_Screens;
    [SerializeField] Image              bar;

    //vars
    [SerializeField] private int currentPage = 0;
    [SerializeField] private int selectedLevel = 1;

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


}
