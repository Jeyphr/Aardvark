using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ps_NMECollide : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Mine")
        {
            Destroy(collision.gameObject);
        }
    }
}
