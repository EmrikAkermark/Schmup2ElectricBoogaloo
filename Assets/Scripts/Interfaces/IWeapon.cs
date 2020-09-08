using Unity;

public interface IWeapon
{
	void Fire();

	//void Upgrade();

	void ResetStats();

	bool PickUp(int WeaponId);

	bool IsWeaponActivated();
}
