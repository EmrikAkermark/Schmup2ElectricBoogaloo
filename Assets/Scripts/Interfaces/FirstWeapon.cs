using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstWeapon : WeaponBase, IWeapon
{
    

    public void Fire()
    {
        switch (UpgradeTier)
        {
            case 0:
                AttackTier0();
                break;
            case 1:
                AttackTier1();
                break;
            case 2:
                AttackTier2();
                break;
            default:
                break;
        }
    }

    void AttackTier0()
    {
        Debug.Log("Tier 1");
    }
    void AttackTier1()
    {
        Debug.Log("Tier 2");
    }

    void AttackTier2()
    {
        Debug.Log("Tier 3");
    }

    

    public void ResetStats()
    {
        UpgradeTier = 0;
    }


    public bool IsWeaponActivated()
    {
        return IsPickedUp;
    }

    public bool PickUp(int WeaponId)
    {
        if(CheckIfSameWeapon(WeaponId))
        {
            if(!IsPickedUp)
            {
                IsPickedUp = true;
            }
            else
            {
                UpgradeWeapon();
            }
            return true;
        }
        else
        {
            return false;
        }
    }
}
