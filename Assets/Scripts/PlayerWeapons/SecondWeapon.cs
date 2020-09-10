using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondWeapon : WeaponBase, IWeapon
{
    private IEnumerator PowerUpTimer;

    public float PowerUpTime = 10f;
    private float powerUpTimeLeft;
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
        StartCoroutine(PowerUpTimer);
    }

    public bool IsWeaponActivated()
    {
        throw new System.NotImplementedException();
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
        powerUpTimeLeft = PowerUpTime;
        while (powerUpTimeLeft > 0f)
        {
            powerUpTimeLeft -= Time.deltaTime;
            yield return null;
        }
        isPoweredUp = false;
    }

    private void Start()
    {
        PowerUpTimer = PowerUpOverdrive();
    }
}
