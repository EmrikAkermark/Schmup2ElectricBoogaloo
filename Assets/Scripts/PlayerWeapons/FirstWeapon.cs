using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstWeapon : WeaponBase, IWeapon
{
    public GameObject Projectile;
    public Transform[] FirePosition;
    private Vector2[] FireRotation;

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
            firedProjectile.SetDirection(FirePosition[i].rotation.eulerAngles.z);
        }
    }
	private void Start()
	{
        FireRotation = new Vector2[FirePosition.Length];
		for (int i = 0; i < FirePosition.Length; i++)
		{
            FireRotation[i] = FirePosition[i].rotation.eulerAngles;
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
