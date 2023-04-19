using System;
using System.Collections.Generic;
using System.Linq;

public class Inventory
{
	public List<Item> items = new();
	private decimal  weight, maxWeight;

	public Item GetItemByUniqueId(int id)
	{
		return items.FirstOrDefault(item => item.uniqueId == id);
	}
	
	public void AddItem(Item item)
	{
		if (item.weight > maxWeight)
			throw new ArgumentOutOfRangeException($"{item.weight} > {maxWeight} !");
		items.Add(item);
		weight += item.weight;
	}

	public void RemoveItem(Item item)
	{
		if (!items.Contains(item))
			throw new NullReferenceException("пошел нахуй");
		items.Remove(item);
		weight-=item.weight;
	}
}
