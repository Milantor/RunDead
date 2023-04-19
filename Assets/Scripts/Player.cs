using UnityEngine;

public class Player : Entity
{
	private string nickname;
	public Inventory inventory;
	
	public Player(int maxHP) : base(maxHP)
	{
		nickname = "Player" + Random.Range(0, 9999).ToString("D4");
		inventory = new Inventory();
	}

	public override void Debug()
	{
		UnityEngine.Debug.Log($"Player:{nickname}, id:{id} \nHP:{HealthPoint}/{maxHealthPoint} ");
	}
}