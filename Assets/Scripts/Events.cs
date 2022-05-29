public static class Events
{
	public delegate void ItemSelect(Item item);
	public static ItemSelect OnItemSelect;

	public delegate void Dead();
	public static Dead OnDead;
}
