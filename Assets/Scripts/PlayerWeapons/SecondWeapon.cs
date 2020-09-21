using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondWeapon : WeaponBase, IWeapon
{
    private Coroutine PowerUpTimer;

    public float PowerUpTime = 10f;
    private bool isPoweredUp;
    public void Fire()
    {
        if(isPoweredUp)
        {
            AttackPoweredUp();
        }
        else
        {
            AttackRegular();
        }
    }

    private void AttackRegular()
    {
        Debug.Log("Regular Attack");
    }

    private void AttackPoweredUp()
    {
        PowerUpTimer = StartCoroutine(PowerUpOverdrive());
    }

    public bool IsWeaponActivated()
    {
        return IsPickedUp;
    }


    public bool PickUp(int WeaponId)
    {
        if(CheckIfSameWeapon(WeaponId))
        {
            AttackPoweredUp();
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ResetStats()
    {
        ResetStats();
    }

    private IEnumerator PowerUpOverdrive()
    {
        isPoweredUp = true;
        yield return new WaitForSeconds(PowerUpTime);
        isPoweredUp = false;
    }
}
