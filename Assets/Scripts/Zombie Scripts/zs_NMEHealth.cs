using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zs_NMEHealth : MonoBehaviour, gs_IDamagable
{
    [Header("Object References")]
    [SerializeField] private zs_uiHandler uiHandler;

    [Header("Statistics")]
    [SerializeField] private float _maxHealth = 100;
    [SerializeField] private float _health = 100;


    public float Health     { get => _health; set => _health = value; }
    public float MaxHealth  { get => _maxHealth; set => _maxHealth = value; }

    public event gs_IDamagable.TakeDamageEvent OnTakeDamage;
    public event gs_IDamagable.Die OnDie;

    public void takeDamage(float damage)
    {
        _health -= damage;
        if (_health - damage < 0 || damage > _maxHealth)
        {
            _health = 0;
            Destroy(this.gameObject);
        }
        uiHandler.updateUI();
    }

    //newmeth
    public void OnEnable()
    {
        Health = MaxHealth;
    }
}
