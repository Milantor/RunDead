using UnityEngine;

public class Player : Entity
{
	private string nickname;
	public Player(int maxHP) : base(maxHP)
	{
		nickname = "Player" + Random.Range(0, 9999).ToString("D4");
	}

	public override void Debug()
	{
		UnityEngine.Debug.Log($"Player:{nickname}, ID:{ID} \nHP:{HealthPoint}/{maxHealthPoint} ");
	}
}