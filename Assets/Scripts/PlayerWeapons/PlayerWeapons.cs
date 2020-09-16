using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapons : MonoBehaviour
{
    public int CurrentWeaponInArray;
    public IWeapon[] weaponArray;
    public IWeapon CurrentWeapon;


    public void FireAll()
    {
        for (int i = 0; i < weaponArray.Length; i++)
        {
            weaponArray[i].Fire();
        }
    }

    public void Fire()
    {
        CurrentWeapon.Fire();
    }

    public void PickedUpWeapon(int weaponId)
    {
        for (int i = 0; i < weaponArray.Length; i++)
        {
            if(weaponArray[i].PickUp(weaponId))
            {
                return;
            }
        }
    }

    public void UpgradeCurrentWeapon()
    {
        CurrentWeapon.PickUp(0);
    }

    public void ResetCurrentWeapon()
    {
        CurrentWeapon.ResetStats();
    }

    public void ResetAllWeapons()
    {
        for (int i = 0; i < weaponArray.Length; i++)
        {
            weaponArray[i].ResetStats();
        }
    }

    private void Start()
    {
        weaponArray =gameObject.GetComponents<IWeapon>();
        CurrentWeapon = weaponArray[0];
    }

    public void CycleForward()
    {
        for (int i = CurrentWeaponInArray + 1; i < weaponArray.Length; i++)
        {
            if(weaponArray[i].IsWeaponActivated())
            {
                CurrentWeapon = weaponArray[i];
                CurrentWeaponInArray = i;
                return;
            }
        }
        for (int i = 0; i < CurrentWeaponInArray; i++)
        {
            if(weaponArray[i].IsWeaponActivated())
            {
                CurrentWeapon = weaponArray[i];
                CurrentWeaponInArray = i;
                return;
            }
        }
    }

    public void CycleBack()
    {
        for (int i = CurrentWeaponInArray - 1; i > -1; i--)
        {
            if (weaponArray[i].IsWeaponActivated())
            {
                CurrentWeapon = weaponArray[i];
                CurrentWeaponInArray = i;
                return;
            }
        }
        for (int i = weaponArray.Length - 1; i > CurrentWeaponInArray; i--)
        {
            if (weaponArray[i].IsWeaponActivated())
            {
                CurrentWeapon = weaponArray[i];
                CurrentWeaponInArray = i;
                return;
            }
        }
    }

}
