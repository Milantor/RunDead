using UnityEditor;

public abstract class Item
{
	protected static int globalId;
	public int uniqueId { get; private set; }
	public string id { get; private set; }
	public decimal weight;

	protected Item(string id)
	{
		uniqueId = globalId++;
		ItemPreset preset = WorldController._instance.itemPresets[id];
		this.id = id;
		this.weight = preset.weight;
	}

	protected Item(string id, decimal weight)
	{
		uniqueId = globalId++;
		this.id = id;
		this.weight = weight;
	}
}