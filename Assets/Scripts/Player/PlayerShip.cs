﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour, IDamagable
{
	public float Health, ShieldUpTime, ShieldCooldown;
	public KeyCode Shield;
	public GameObject ShieldSprite;

	private bool hasShield = false, shieldIsReady = true;

	private Coroutine ShieldIsUp, ChargingShield;

	private void Update()
	{
		if(Input.GetKeyDown(Shield))
		{
			ActivateShield();
		}
	}

	public void GetHit(float damage)
	{
		if(hasShield)
		{
			return;
		}
		Health -= damage;
		if (Health <= 0f)
		{
			gameObject.SetActive(false);
		}
	}

	public void ActivateShield()
	{
		if(shieldIsReady)
		ShieldIsUp = StartCoroutine(ShieldActivated());
	}

	public void PlayerCollision()
	{
		if(hasShield)
		{
			StopCoroutine(ShieldIsUp);
			hasShield = false;
			ShieldSprite.SetActive(false);
			ChargingShield = StartCoroutine(RechargeShield());
		}
		else
		{
			Health -= 4f;
			if (Health <= 0f)
			{
				Debug.Log("Ded");
			}
		}
	}

	//public void ShieldQuickCharge()
	//{
	//	if(!shieldIsReady)
	//	{
	//		shieldIsReady = true;
	//		StopCoroutine(ChargingShield);
	//	}
	//	else if(hasShield)
	//	{
	//		ShieldIsUp = StartCoroutine(ShieldActivated());
	//	}
	//}

	IEnumerator RechargeShield()
	{
		yield return new WaitForSeconds(ShieldCooldown);
		shieldIsReady = true;
	}

	IEnumerator ShieldActivated()
	{
		shieldIsReady = false;
		hasShield = true;
		ShieldSprite.SetActive(true);
		yield return new WaitForSeconds(ShieldUpTime);
		hasShield = false;
		ShieldSprite.SetActive(false);
		ChargingShield = StartCoroutine(RechargeShield());
	}

	public void Delete()
	{

	}
}
