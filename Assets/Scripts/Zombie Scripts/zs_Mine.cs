using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class zs_Mine : MonoBehaviour
{
    [Header("Object References")]
    [SerializeField] private ParticleSystem _particleSystem;

    [Header("Statistics")]
    [SerializeField] float damage = 20f;


    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
    }

    private void explode()
    {
        _particleSystem.Play();
        Destroy(this.gameObject);
    }
}
