using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Pool;
using static UnityEngine.GraphicsBuffer;

public class sob_NME : MonoBehaviour, gs_IDamagable
{
    [Header("Statistics")]
    [SerializeField] private string _name;
    [SerializeField] private float  _maxHealth;
    [SerializeField] private float  _health;
    [SerializeField] private float  _walkSpeed;
    [SerializeField] private float  _attackCooldown;
    [SerializeField] private float  _weight;
    [SerializeField] private bool   isAttacking;

    [Header("Object References")]
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private zs_uiHandler uiHandler;
    [SerializeField] private GameObject mine;
    [SerializeField] private Transform attackSpot;

    //vars
    const float updateSpeed = 0.1f;
    private Transform target;
    private ObjectPool <GameObject> minepool;
    
    

    #region INSTANTIATING METHODS
    private void Awake()
    {
        agent   = GetComponent<NavMeshAgent>();
        target  = GameObject.FindGameObjectWithTag("BASE").transform;
    }
    private void Start()
    {
        StartCoroutine(FollowTarget());
    }
    #endregion
    #region NAVIGATION METHODS
    private IEnumerator FollowTarget()
    {
        WaitForSeconds Wait = new WaitForSeconds(updateSpeed);
        while (enabled)
        {
            agent.SetDestination(target.position);
            yield return Wait;
        }
    }
    #endregion
    #region GETTERS AND SETTERS
    public float Health { get => _health; set => _health = value; }
    public float MaxHealth { get => _maxHealth; set => _maxHealth = value; }
    public float WalkSpeed { get => _walkSpeed; set => _walkSpeed = value; }
    public float Weight { get => _weight; set => _weight = value; }
    public float AttackCooldown { get => _attackCooldown; set => _attackCooldown = value; }

    #endregion
    #region EVENTS
    public event gs_IDamagable.TakeDamageEvent OnTakeDamage;
    public event gs_IDamagable.Die OnDie;
    #endregion

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "BASE")
        {
            takeDamage(Health);
        }
    }

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
}
