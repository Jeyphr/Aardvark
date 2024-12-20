using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class gs_Notification : MonoBehaviour
{
    [Header("Statistics")]
    [SerializeField] private string notifText   = "Unset";
    [SerializeField] private float  decayPercent   = 0.1f;

    [Header("Object References")]
    [SerializeField] private Image      bar;
    [SerializeField] private GameObject notif;
    [SerializeField] private TMP_Text   textMeshPro;

    //vars
    private bool showing = false;

    #region GETTERS AND SETTERS
    public string NotifText { get => notifText; set => notifText = value; }
    #endregion

    private void Awake()
    {
        textMeshPro.text = NotifText;
        bar.fillAmount = 1;
        showing = true;
    }

     void Update()
    {
        if (showing)
        {
            if(bar.fillAmount > 0)
            {
                bar.fillAmount -= decayPercent*Time.deltaTime;
            }
            else
            {
                showing = false;
                deleteNotif();
            }
        }
    }

    public void updateText(string noteText)
    {
        textMeshPro.text = noteText;
    }

    public void deleteNotif()
    {
        Destroy(notif);
    }
}
