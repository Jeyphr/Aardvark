using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gs_billboard : MonoBehaviour
{
    [Header("Object References")]
    [SerializeField] public Transform Camrea;

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Camrea);
    }
}
