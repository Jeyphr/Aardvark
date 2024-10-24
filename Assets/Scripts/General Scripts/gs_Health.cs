using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gs_Health : MonoBehaviour, gs_IDamagable
{
    [Header("Object References")]

    //Vars
    private float _health = 100f;
    private float _maxHealth = 100f;

    public void takeDamage(float val)
    {
        _health -= val;
        if (_health - val < 0 || val > _maxHealth)
        {
            _health = 0;
        }
    }

    public void heal(float val)
    {
        _health += val;
        if (_health + val > _maxHealth || val > _maxHealth)
        {
            _health = _maxHealth;
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            takeDamage(8f);
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            heal(8f);
        }
    }

    #region GETTERS AND SETTERS
    public float Health { get => _health; set => _health = value; }
    public float MaxHealth { get => _maxHealth; set => _maxHealth = value; }
    #endregion
}
