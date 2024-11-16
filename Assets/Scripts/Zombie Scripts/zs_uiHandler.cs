using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class zs_uiHandler : MonoBehaviour
{
    private float _visMaxHealth = 100f;
    private float _visHealth = 100f;

    [Header("Object References")]
    [SerializeField] private sob_NME NMEHealth;
    [SerializeField] private Image image;
    [SerializeField] private TMPro.TMP_Text uiText;
    
    private string nmeName;








    private void Awake()
    {
        updateUI();
    }
    public void updateUI()
    {
        nmeName = NMEHealth.name;
        uiText.text = nmeName + ": " + VisHealth;
        VisHealth = NMEHealth.Health;
        VisMaxHealth = NMEHealth.MaxHealth;
        image.fillAmount = VisHealth / VisMaxHealth;
    }

    

    // setters and getters
    public float VisMaxHealth { get => _visMaxHealth; set => _visMaxHealth = value; }
    public float VisHealth { get => _visHealth; set => _visHealth = value; }
}
