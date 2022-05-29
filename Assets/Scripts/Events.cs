public static class Events
{
	public delegate void ItemSelect(Item item);
	public static ItemSelect OnItemSelect;

	public delegate void Dead();
	public static Dead OnDead;

	public delegate void OnMove(string key);
	public static OnMove OnKeyPressed;
}
