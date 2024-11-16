using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface gs_IDamagable
{
    public float Health { get; set; }
    public float MaxHealth { get; set; }

    public delegate void TakeDamageEvent(int Damage);
    public event TakeDamageEvent OnTakeDamage;

    public delegate void Die();
    public event Die OnDie;

    public void takeDamage(float damage);
}
