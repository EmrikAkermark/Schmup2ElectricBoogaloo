﻿using UnityEngine;

public class ThirdWeapon : MonoBehaviour, IWeapon
{
    public void Fire()
    {
        throw new System.NotImplementedException();
    }

    public void ResetStats()
    {
        throw new System.NotImplementedException();
    }

    public bool IsWeaponActivated()
    {
       return false;
    }

    public bool PickUp(int WeaponId)
    {
        throw new System.NotImplementedException();
    }
}
