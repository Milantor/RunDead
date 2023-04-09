using System;

public class Entity
{
	private static int globalId;
	private static Entity[] allEntities;
	public int id { get; private set; }

	public readonly int maxHealthPoint;
	private int healthPoint;
	public int HealthPoint
	{
		get => healthPoint;
		private set => healthPoint = value > maxHealthPoint ? maxHealthPoint : value;
	}
	public int ChangeHp(int value)
	{
		HealthPoint += value;
		return HealthPoint;
	}

	protected Entity(int maxHP)
	{
		id = globalId++;
		maxHealthPoint = maxHP;
		HealthPoint = maxHealthPoint;
	}

	public static Entity GetEntityById(int id)
	{
		if (id <= 0) throw new ArgumentOutOfRangeException(nameof(id));
		foreach (var entity in allEntities)
		{
			if (entity.id == id) return entity;
		}
		throw new IndexOutOfRangeException(nameof(id));
	}

	public virtual void Death()
	{
		
	}
	
	public virtual void Debug()
	{
		UnityEngine.Debug.Log($"id:{id} \nHP:{HealthPoint}/{maxHealthPoint} ");
	}
}