using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class gs_Notification : MonoBehaviour
{
    [Header("Statistics")]
    [SerializeField] private string notifText   = "Howdy!";
    [SerializeField] private float  decayTime   = 5.0f;

    [Header("Object References")]
    [SerializeField] private Image      bar;
    [SerializeField] private GameObject notif;
    [SerializeField] private GameObject terminal;
    [SerializeField] private GameObject NotificationGO;
    [SerializeField] private TextMeshPro textMeshPro;

    //vars
    private bool showing = false;

    #region GETTERS AND SETTERS
    public string NotifText { get => notifText; set => notifText = value; }
    #endregion

    private void Awake()
    {
        //Text text = notif.GetComponent<Text>();
        //text.text = notifText;
        showing = true;
    }

    private void Update()
    {
        textMeshPro.text = NotifText;
        float elapsedTime = decayTime;

        while (elapsedTime >= 0)
        {
            bar.fillAmount = elapsedTime -= Time.deltaTime;
            elapsedTime = elapsedTime -= Time.deltaTime;
        }
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
