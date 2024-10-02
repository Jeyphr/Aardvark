using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ps_UIHandler : MonoBehaviour
{
    //Vars
    private float _maxHealth     = 100f;
    private float _fMount        = 100f;
    private float _health        = 100f;

    [Space]
    [Header("Object References")]
    [SerializeField] Canvas bar_Health, bar_Ammo;


    #region METHODS
    private void addHealth(Image bar, float val)
    {
        if (val > _maxHealth) 
        {
            val = _maxHealth;
        }
        _health += val;
        _fMount = _maxHealth / _health;
        bar.fillAmount = _fMount;
    }
    private void setHealth(Image bar, float val)
    {
        if (val > _maxHealth)
        {
            _health = _maxHealth;
        }
        if (val < 0)
        {
            _health = 0;
        }
        _fMount = _maxHealth / _health;
        bar.fillAmount = _fMount;
    }
    private void subHealth(Image bar, float val)
    {
        if (val < 0)
        {
            val = 0;
        }
        _health -= val;
        _fMount = _maxHealth / _health;
        bar.fillAmount = _fMount;
    }
    #endregion
    #region SETTERS AND GETTERS
    public float MaxHealth {  get { return _maxHealth; } set { _maxHealth = value; } }
    public float Health { get { return _health; } set { _health = value; } }
    #endregion
}
