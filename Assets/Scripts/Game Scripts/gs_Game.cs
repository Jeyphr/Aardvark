using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gs_Game : MonoBehaviour
{
    [Header("Object References")]
    [Header("Statistics")]
    [SerializeField] private int    numWave         = 1;
    [SerializeField] private int    maxWaves        = 3;
    [SerializeField] private int    numRound        = 1;
    [SerializeField] private int    maxRounds       = 10;
    [SerializeField] private float  intermission    = 10f;
    


    [Header("NME's")]
    [SerializeField] private GameObject[]   light_NMEs;
    [SerializeField] private GameObject[]   heavy_NMEs;
    [SerializeField] private Transform[]    spawnpoints;

    /*
     
     for #rounds
        <spawn enemies at random spawnpoints for every #wave>
    for #wave

     
     
     
     */

}
