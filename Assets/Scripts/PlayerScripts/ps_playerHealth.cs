using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ps_playerHealth : MonoBehaviour, gs_IDamagable
{
    // Start is called before the first frame update
    [SerializeField] private float _health      = 100f;
    [SerializeField] private float _maxHealth   = 100f;
    [SerializeField] private float _invuln      = 1f;

    [SerializeField] private ps_UIHandler _UIhandler;

    public event gs_IDamagable.TakeDamageEvent OnTakeDamage;
    public event gs_IDamagable.Die OnDie;

    public float Health { get => _health; set => _health = value; }
    public float MaxHealth { get => _maxHealth; set => _maxHealth = value; }

    private void Awake() { updateHealth(); }
    private void updateHealth()
    {
        if (_health > _maxHealth) { _health = _maxHealth;}
        if (_health < 0) { _health = 0; }
        _UIhandler.VisHealth = _health;
        _UIhandler.updateUI();
    }
    public void takeDamage(float val)
    {
        _health -= val;
        updateHealth();
    }
    public void healDamage(float val)
    {
        _health += val;
        updateHealth();
    }
}
