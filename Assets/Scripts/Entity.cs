using System;

public class Entity
{
	private static int globalID;
	private static Entity[] allEntities;
	public int ID { get; private set; }

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
		ID = globalID++;
		maxHealthPoint = maxHP;
		HealthPoint = maxHealthPoint;
	}

	public static Entity GetEntityById(int id)
	{
		if (id <= 0) throw new ArgumentOutOfRangeException(nameof(id));
		foreach (var entity in allEntities)
		{
			if (entity.ID == id) return entity;
		}
		throw new IndexOutOfRangeException(nameof(id));
	}

	public virtual void Death()
	{
		
	}
	
	public virtual void Debug()
	{
		UnityEngine.Debug.Log($"ID:{ID} \nHP:{HealthPoint}/{maxHealthPoint} ");
	}
}