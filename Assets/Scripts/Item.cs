public abstract class Item
{
	protected static int globalId;
	private int uniqueId;
	public string id { get; private set; }

	protected Item(string id)
	{
		uniqueId = globalId++;
		this.id = id;
	}
}
