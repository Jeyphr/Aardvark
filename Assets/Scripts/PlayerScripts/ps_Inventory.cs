using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class ps_Inventory : MonoBehaviour
{
    [SerializeField] private enm_GunType _gun;
    [SerializeField] private Transform _gunHolder;
    [SerializeField] private List<sob_Gun> lst_guns;

    [Header("Runtime Filled")]
    public sob_Gun heldGun;


    private void Start()
    {
        sob_Gun gun = lst_guns.Find(gun => gun.gunType == _gun);
        if (gun == null)
        {
            Debug.LogError($"No GSO found for GunType: {gun}");
            return;
        }

        heldGun = gun;
        gun.Spawn(_gunHolder, this);
    }
}
