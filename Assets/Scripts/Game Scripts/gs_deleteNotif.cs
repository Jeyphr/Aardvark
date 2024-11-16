using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class gs_deleteNotif : MonoBehaviour
{
    

    [Header("Notification Objects")]
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject notif;

    public void createNotification(string phrase)
    {
        GameObject thing = Instantiate(notif,panel.transform);
    }
}
