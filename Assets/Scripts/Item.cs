using System.Xml.Serialization;

public abstract class Item
{
	protected static int globalId;
	private int uniqueId;
	[XmlAttribute("id")]
	public string id { get; private set; }
	public decimal weight;

	protected Item(string id, decimal weight)
	{
		uniqueId = globalId++;
		this.id = id;
		this.weight = weight;
	}
}
