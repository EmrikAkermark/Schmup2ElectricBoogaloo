using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondWeapon : WeaponBase, IWeapon
{
    private Coroutine PowerUpTimer;

    public float BulletSpeed, BulletDamage, BulletLifespan, FireRate;
    public float PowerUpTime = 10f;
    public GameObject Projectile;
    public Transform FirePosition;
    private bool isPoweredUp, canFire = true;
    public void Fire()
    {
        if (!canFire)
        {
            return;
        }
        if (isPoweredUp)
        {
            PoweredAttack();
        }
        else
        {
            RegularAttack();
        }
        StartCoroutine(HoldFire());
    }

    private void RegularAttack()
    {
        GameObject projectile = Instantiate(Projectile, FirePosition.position, FirePosition.rotation);
        Projectile firedProjectile = projectile.GetComponent<Projectile>();
        
        firedProjectile.SetupBullet(FirePosition.rotation.eulerAngles.z, BulletDamage, BulletSpeed, BulletLifespan);
    }

    private void PoweredAttack()
    {
        GameObject projectile = Instantiate(Projectile, FirePosition.position, FirePosition.rotation);
        Projectile firedProjectile = projectile.GetComponent<Projectile>();
        firedProjectile.SetupBullet(FirePosition.rotation.eulerAngles.z, BulletDamage, BulletSpeed * 2f, BulletLifespan); ;
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
    private IEnumerator HoldFire()
    {
        canFire = false;
        yield return new WaitForSeconds(FireRate);
        canFire = true;
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
        float oldFireRate = FireRate;
        FireRate *= 0.5f;
        yield return new WaitForSeconds(PowerUpTime);
        FireRate = oldFireRate;
        isPoweredUp = false;
    }
}
