using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public KeyCode Shoot, NextWeapon, PrevWeapon;

    private PlayerWeapons pWeapons;

	private void Start()
	{
		pWeapons = GetComponent<PlayerWeapons>();
	}

	void Update()
    {
        if(Input.GetKey(Shoot))
		{
         pWeapons.Fire();
		}
		if(Input.GetKeyDown(NextWeapon))
		{
			pWeapons.CycleForward();
		}
		if(Input.GetKeyDown(PrevWeapon))
		{
			pWeapons.CycleBack();
		}
    }
}
