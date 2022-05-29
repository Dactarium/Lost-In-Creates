interface IInteractable
{
	void Interact();
}

interface IPickable
{
	void PickItem();
}

public interface IDamageable
{
	public void TakeDamage(int damage);
}
