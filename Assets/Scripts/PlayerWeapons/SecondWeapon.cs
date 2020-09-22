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
            PoweredAttack();
        }
        else
        {
            RegularAttack();
        }
    }

    private void RegularAttack()
    {
        Debug.Log("Regular Attack");
    }

    private void PoweredAttack()
    {
        Debug.Log("Powered Attack");
    }

    public bool IsWeaponActivated()
    {
        return IsPickedUp;
    }


    public bool PickUp(int WeaponId)
    {
        if(CheckIfSameWeapon(WeaponId))
        {
            if (!IsPickedUp)
            {
                IsPickedUp = true;
            }
            else
			{
                Upgradeattack();
            }
                
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

    private void Upgradeattack()
	{
        PowerUpTimer = StartCoroutine(PowerUpOverdrive());
	}

    private IEnumerator PowerUpOverdrive()
    {
        isPoweredUp = true;
        yield return new WaitForSeconds(PowerUpTime);
        isPoweredUp = false;
    }
}
