using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WorldController : MonoBehaviour
{
	public static WorldController _instance { get; private set; }
	public Dictionary<string, Sprite> sprites { get; private set; } 
	private Dictionary<GameObject, Player> players = new();

	private void Awake()
	{
		_instance = this;
		sprites = new Dictionary<string, Sprite>();
		// ReSharper disable once Unity.UnknownResource
		var _sprites = Resources.LoadAll<Sprite>("Sprites");
		foreach (var sprite in _sprites)
		{
			sprites.Add(sprite.name, sprite);
		}
	}

	private void Start()
	{ 
		InitializePlayer(); // temp
	}
	
	#region Player
	private void InitializePlayer()
	{
		var _go = new GameObject();
		var _player = new Player(Random.Range(90,110));
		_player.Debug();
		//_go.AddComponent<SpriteRenderer>().sprite = sprites["player"];
		_go.AddComponent<BoxCollider2D>();
		players.Add(_go, _player);
	}
	#endregion
}