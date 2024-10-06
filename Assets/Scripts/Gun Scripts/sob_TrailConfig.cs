using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Trail Config", menuName = "Guns / Gun Trail Configuration", order = 4)]
public class sob_TrailConfig : ScriptableObject
{
    [Header("Object References")]
    [SerializeField] public Material material;
    [SerializeField] public AnimationCurve widthCurve;

    [Header("Statistics")]
    [SerializeField] public float lifespan = 0.5f;
    [SerializeField] public float minVertexDist = 0.1f;
    [SerializeField] public Gradient color;
    [SerializeField] public float missDist = 100f;
    [SerializeField] public float simSpeed = 100f;

}
