using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gs_waveSpawning : MonoBehaviour
{
    [Header("References")]
    [SerializeField] public GameObject[] NMEs;
    [SerializeField] public Transform[] spawnpoints;

    [Header("Statistics")]
    [SerializeField] public int currentWave;
    [SerializeField] public int waveCount;
    [SerializeField] public float cost = 3;
    [SerializeField] public float costInc = 1.1f;

    private void Awake()
    {
        nextWave();
    }
    private void increaseCost()
    {
        cost *= costInc;
    }

    public void nextWave()
    {
        currentWave++;
        increaseCost();
        spawnWave();
    }

    private void spawnWave()
    {
        float nmeWeight;
        float remainingCost = cost;

       
        
        while (remainingCost > 0)
        {
            Debug.Log(remainingCost);
            foreach (var nme in NMEs)
            {
                nmeWeight = 1;//nme.GetComponent<sob_NME>().Weight;
                Debug.Log(nmeWeight);
                if (nmeWeight <= remainingCost)
                {
                    remainingCost -= nmeWeight;
                    summonNME(nme);
                }
                else if (remainingCost < 1)
                {
                    summonNME(NMEs[0]);
                    remainingCost = 0;
                }
            }
        }
    }

    private void summonNME(GameObject nme)
    {
        Debug.Log("NME Summoned");
        Transform point = spawnpoints[Random.Range(0, spawnpoints.Length)];
        Instantiate(nme, point);
    }
   
}
