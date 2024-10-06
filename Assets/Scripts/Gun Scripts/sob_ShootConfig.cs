using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Shoot Config", menuName = "Guns / Shoot Configurations", order = 2)]
public class sob_ShootConfig : ScriptableObject
{
    [Header("Object References")]
    [SerializeField] public LayerMask hitMask;


    [Header("Statistics")]
    [SerializeField] public Vector3 bloom = new Vector3(0,1f);
    [SerializeField] public float fireRate = 0.25f;


}
