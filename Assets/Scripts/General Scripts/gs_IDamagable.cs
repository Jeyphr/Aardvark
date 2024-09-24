using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class gs_IDamagable : MonoBehaviour
{

}

public interface IDamagable
{
    void TakeDamage(float damageAmount);
}
