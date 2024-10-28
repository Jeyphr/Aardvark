using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zs_NMEHealth : MonoBehaviour, gs_IDamagable
{
    [SerializeField] private float _maxHealth = 100;
    [SerializeField] private float _health = 100;


    public float health     { get => _health; set => _health = value; }
    public float maxHealth  { get => _maxHealth; set => _maxHealth = value; }

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
    }

    //newmeth
    public void OnEnable()
    {
        health = maxHealth;
    }
}
