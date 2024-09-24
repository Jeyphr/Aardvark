using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ps_Inventory : MonoBehaviour
{
    [Header("Statistics")]
    [SerializeField] public Transform       swapSpeed;
    [SerializeField] public GameObject[]    arr_WeaponSlots;

    [Space]
    [Header("Object References")]
    [SerializeField] public Transform holdPosition;

    //VARS
    private bool        _isEmptyHanded;
    private GameObject  _selectedWeapon;


    //---------------------------------------------------------------
    private void SetWeapon()
    {

    }
}
