using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstWeapon : WeaponBase, IWeapon
{
    public GameObject Projectile;
    public Transform[] FirePosition;
    public float BulletSpeed, BulletDamage, BulletLifespan, FireRate;
    private float[] FireRotation;
    private bool canFire = true;

    public void Fire()
    {
        if(!canFire)
		{
            return;
		}
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
        StartCoroutine(HoldFire());
    }

    void AttackTier0()
    {
        FireTheGuns(1);
    }
    void AttackTier1()
    {
        FireTheGuns(3);
    }

    void AttackTier2()
    {
        FireTheGuns(5);
    }

    private void FireTheGuns(int AmountToFire)
	{
        for (int i = 0; i < AmountToFire; i++)
        {
            GameObject projectile = Instantiate(Projectile, FirePosition[i].position, FirePosition[i].rotation);
            Projectile firedProjectile = projectile.GetComponent<Projectile>();
            firedProjectile.SetupBullet(FireRotation[i], BulletDamage, BulletSpeed);
        }
    }
	private void Start()
	{
        FireRotation = new float[FirePosition.Length];
		for (int i = 0; i < FirePosition.Length; i++)
		{
            FireRotation[i] = FirePosition[i].rotation.eulerAngles.z;
		}
    }

    public void ResetStats()
    {
        UpgradeTier = 0;
    }


    public bool IsWeaponActivated()
    {
        return IsPickedUp;
    }

    private IEnumerator HoldFire()
	{
        canFire = false;
        yield return new WaitForSeconds(FireRate);
        canFire = true;
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
