using System.Collections;
using System.Collections.Generic;
using UnityEngine.Pool;
using UnityEngine;

public class placeBeeper : MonoBehaviour
{
    [Header("Statistics")]
    [SerializeField] float attackCooldown = 1f;
    [SerializeField] int defaultPoolSize = 3;
    [SerializeField] int maxPoolSize = 6;

    [Header("Object References")]
    [SerializeField] sob_NME NME;
    [SerializeField] GameObject beeper;
    [SerializeField] Transform attackPosition;

    //vars
    private List<GameObject> beeperList = new List<GameObject>();
    private ObjectPool <GameObject> beeperPool;
    private bool spawnBeepers = false;

    

    private IEnumerator placeMine()
    {
        WaitForSeconds Wait = new WaitForSeconds(attackCooldown);
        while (enabled)
        {
            beeperPool.Get();
            beeper.transform.position = attackPosition.position;
            yield return Wait;
        }
    }

    private void createBeepers()
    {
        beeperPool = new ObjectPool<GameObject>(() =>
        {
            return Instantiate(beeper);
        },
        GameObject =>
        {
            enableObject(GameObject);
        },
        GameObject =>
        {
            disableObject(GameObject);
        },
        GameObject =>
        {
            destroyObject(GameObject);
        },
        false, defaultPoolSize, maxPoolSize);
    }

    private void enableObject(GameObject thing)
    {
        thing.SetActive(true);
    }

    private void disableObject(GameObject thing)
    {
        thing.SetActive(false);
    }

    private void destroyObject(GameObject thing)
    {
        Destroy(thing);
    }
}
