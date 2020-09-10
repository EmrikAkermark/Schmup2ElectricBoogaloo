using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBase : MonoBehaviour
{
    public int UpgradeTier, UpgradeTierMax, WeaponID;
    public bool IsPickedUp;

    public void UpgradeWeapon()
    {
        if(UpgradeTier != UpgradeTierMax)
        {
            UpgradeTier++;
        }
    }

    public bool CheckIfSameWeapon(int newWeaponId)
    {
        if(newWeaponId == WeaponID || newWeaponId == -1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
