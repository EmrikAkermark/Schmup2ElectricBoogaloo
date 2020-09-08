using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceArrayTest : MonoBehaviour
{
    public int CurrentWeponInArray;
    public IWeapon[] weponArray;
    public IWeapon CurrentWepon;

    public void FireAll()
    {
        for (int i = 0; i < weponArray.Length; i++)
        {
            weponArray[i].Fire();
        }
    }

    public void Attack()
    {
        CurrentWepon.Fire();
    }

    public void PickedUpWeapon(int weaponId)
    {
        for (int i = 0; i < weponArray.Length; i++)
        {
            if(weponArray[i].PickUp(weaponId))
            {
                return;
            }
        }
    }

    public void UpgradeCurrentWeapon()
    {
        CurrentWepon.PickUp(0);
    }

    public void ResetCurrentWeapon()
    {
        CurrentWepon.ResetStats();
    }

    public void ResetAllWeapons()
    {
        for (int i = 0; i < weponArray.Length; i++)
        {
            weponArray[i].ResetStats();
        }
    }

    private void Start()
    {
        weponArray =gameObject.GetComponents<IWeapon>();
        CurrentWepon = weponArray[0];
    }

    public void CycleForward()
    {
        for (int i = CurrentWeponInArray + 1; i < weponArray.Length; i++)
        {
            if(weponArray[i].IsWeaponActivated())
            {
                CurrentWepon = weponArray[i];
                return;
            }
        }
        for (int i = 0; i < CurrentWeponInArray; i++)
        {
            if(weponArray[i].IsWeaponActivated())
            {
                CurrentWepon = weponArray[i];
                return;
            }
        }
    }

    public void CycleBack()
    {
        for (int i = CurrentWeponInArray - 1; i > -1; i--)
        {
            if (weponArray[i].IsWeaponActivated())
            {
                CurrentWepon = weponArray[i];
                return;
            }
        }
        for (int i = weponArray.Length - 1; i > CurrentWeponInArray; i--)
        {
            if (weponArray[i].IsWeaponActivated())
            {
                CurrentWepon = weponArray[i];
                return;
            }
        }
    }

}
