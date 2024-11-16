using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class gs_Notification : MonoBehaviour
{
    [Header("Statistics")]
    [SerializeField] private string notifText   = "XXXX";
    [SerializeField] private float  fillAmount  = 1.0f;
    [SerializeField] private float  decayTime   = 5.0f;

    [Header("Object References")]
    [SerializeField] private Image      bar;
    [SerializeField] private GameObject notif;
    [SerializeField] private GameObject terminal;
    [SerializeField] private GameObject NotificationGO;

    //vars
    private bool showing = false;

    #region GETTERS AND SETTERS
    public string NotifText { get => notifText; set => notifText = value; }
    #endregion

    private void Awake()
    {
        //Text text = notif.GetComponent<Text>();
        //text.text = notifText;
        

        StartCoroutine(decay());
    }

    IEnumerator decay()
    {
        bar.fillAmount = fillAmount;
        while (fillAmount >= 0.1)
        {
            fillAmount = Mathf.Clamp01(decayTime * Time.deltaTime);
            Debug.Log(fillAmount);
            yield return null;
        }
        deleteNotif();
    }


    public void createNotif()
    {
        Instantiate(notif, terminal.transform);
    }
    public void deleteNotif()
    {
        Destroy(NotificationGO);
    }
}
