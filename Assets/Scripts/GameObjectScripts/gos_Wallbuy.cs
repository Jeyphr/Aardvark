using System.Collections;
using System.Collections.Generic;
using System.Net;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class gos_Wallbuy : MonoBehaviour, IInteractable
{
    [Header("Statistics")]
    [SerializeField] public string interactText = "changeme";
    [SerializeField] public string interactPrice = "100";


    [Header("Object References")]
    [SerializeField] public Transform gunMesh;
    [SerializeField] public TextMeshPro gunText;

    private int _testnum = 0;

    private void Awake()
    {
        gunText.text = (interactText + " : " + interactPrice);
    }
    public void Interact()
    {
        _testnum++;
        Debug.Log("Bought " + interactText + " x" + _testnum);
    }

    public void ShowGun()
    {
        
    }
}
