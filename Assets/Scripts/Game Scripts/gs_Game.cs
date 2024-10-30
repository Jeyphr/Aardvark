using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gs_Game : MonoBehaviour
{
    [Header("Object References")]
    [SerializeField] private gs_waveSpawning waveSpawner;

    [Header("Statistics")]
    [SerializeField] private int    numRound        = 1;
    [SerializeField] private int    maxRounds       = 10;
    [SerializeField] private float  intermission    = 10f;


    private void Awake()
    {
        waveSpawner.nextWave();
    }

    /*
     
     for #rounds
        <spawn enemies at random spawnpoints for every #wave>
    for #wave

     
     
     
     */

}
