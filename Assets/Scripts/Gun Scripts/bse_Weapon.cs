using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class bse_Weapon : MonoBehaviour
{
    /*
        bse_weapon is the weapon base for all the guns in the game. These are things that every gun should have.    
     
     */
    private int _maxAmmo;
    private int _clip;

    //shots
    private int     _pellets;   //How many projectiles are fired?
    private float   _coolShots; //How long between individual shots?
    private float   _bloom;     //How inaccurate the weapon is?

    public void Kaboom()
    {
        Debug.Log("Fired Your Weapon");
    }
    
}
