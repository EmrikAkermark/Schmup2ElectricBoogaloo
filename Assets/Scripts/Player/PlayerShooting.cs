using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public KeyCode Shoot;

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
    }
}
