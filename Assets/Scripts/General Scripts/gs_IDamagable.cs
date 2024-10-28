using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface gs_IDamagable
{
    public float health { get; set; }
    public float maxHealth { get; set; }

    public delegate void TakeDamageEvent(int Damage);
    public event TakeDamageEvent OnTakeDamage;

    public delegate void Die();
    public event Die OnDie;

    public void takeDamage(float damage);
}
