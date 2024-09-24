using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ps_UIHandler : MonoBehaviour
{
    [Header("Statistics")]
    [SerializeField] float maxHealth = 100f;
    [SerializeField] float minHealth = 0f;

    //Vars
    private float _fMount = 0f;
    private float _health = 100f;

    [Space]
    [Header("Object References")]
    [SerializeField] Canvas bar_Health, bar_Ammo;
    

    private void AddValue(Image bar, float val)
    {
        if (val > maxHealth) 
        {
            val = maxHealth;
        }
        _health += val;
        _fMount = maxHealth / _health;
        bar.fillAmount = _fMount;
    }

    private void subValue(Image bar, float val)
    {
        if (val < minHealth)
        {
            val = 0;
        }
        _health -= val;
        _fMount = maxHealth / _health;
        bar.fillAmount = _fMount;
    }
}
