using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class zs_Mine : MonoBehaviour
{
    [Header("Object References")]
    [SerializeField] private GameObject         model;
    [SerializeField] private ParticleSystem     particleSystem;

    [Header("Statistics")]
    [SerializeField] float damage = 20f;

    private void OnCollisionEnter(Collision hit)
    {
        Debug.Log(hit.gameObject.name);
        if (hit.gameObject.tag == "Player")
        {
            StartCoroutine(playExplosion());
        }
    }

    IEnumerator playExplosion()
    {
        model.SetActive(false);
        float duration = particleSystem.duration;
        particleSystem.Play();
        yield return new WaitForSeconds(duration);
        explode();
    }

    private void explode()
    {
        particleSystem.Play();
    }
}
