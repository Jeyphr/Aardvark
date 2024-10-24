using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Shoot Config", menuName = "Guns / Shoot Configurations", order = 2)]
public class sob_ShootConfig : ScriptableObject
{
    [Header("Object References")]
    [SerializeField] public LayerMask hitMask;


    [Header("Statistics")]
    [SerializeField] public float fireRate = 0.25f;
    [SerializeField] public float recoilRecoveryTime = 0.25f;
    [SerializeField] public float maxSpreadTime = 1f;

    [Header("Simple Spread")]
    [SerializeField] public Vector3 bloom = new Vector3(0, 1f);
    [SerializeField] public enm_recoilType enm_recoilType = enm_recoilType.Random;

    public Vector3 getSpread(float shootTime = 0)
    {
        Vector3 spread = Vector3.zero;

        if (enm_recoilType == enm_recoilType.Random)
        {
            spread = Vector3.Lerp(
                Vector3.zero,
                new Vector3(
                    Random.Range(-bloom.x, bloom.x),
                    Random.Range(-bloom.y, bloom.y),
                    Random.Range(-bloom.z, bloom.z)
                ),
                Mathf.Clamp01(shootTime / maxSpreadTime));
            spread.Normalize();
        }
        else if (enm_recoilType == enm_recoilType.Texture)
        {
            Debug.Log("NOT IMPLEMENTED!");
        }
        else if (enm_recoilType == enm_recoilType.Drag)
        {
            Debug.Log("NOT IMPLEMENTED!");
        }
        return spread;
    }
}
