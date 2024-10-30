using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gs_waveSpawning : MonoBehaviour
{
    [Header("References")]
    [SerializeField] public GameObject[] NMEs;
    [SerializeField] public Transform[] spawnpoints;

    [Header("Statistics")]
    [SerializeField] public int waveCount;
    [SerializeField] public float cost = 3;
    [SerializeField] public float costInc = 1.1f;

    private void Start()
    {
        nextWave();
    }
    private void increaseCost()
    {
        if (waveCount % 10 == 0)
        {
            decreaseCost();
        }
        cost *= costInc;
    }

    private void decreaseCost() { cost /= (costInc * 1.2f); }

    public void nextWave()
    {
        waveCount++;
        increaseCost();
        spawnWave();
    }

    private void spawnWave()
    {
        float nmeWeight = 1;
        float remainingCost = cost;

        while (remainingCost > 0)
        {
            foreach (var nme in NMEs)
            {
                nmeWeight = nme.GetComponent<zs_NME>().NmeWeight;
                Debug.Log(nmeWeight);
                if (nmeWeight >= remainingCost)
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
