using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class WorldController : MonoBehaviour
{
	public static WorldController _instance { get; private set; }
	public Dictionary<string, Sprite> sprites { get; private set; }
	public Dictionary<GameObject, Player> players = new();
	public Action callback;

	private void Awake()
	{
		if (_instance != null)
			throw new Exception(">1 WorldControllers? u cringe.");
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
		StartCoroutine(test());
	}

	private IEnumerator test()
	{
		yield return new WaitForSeconds(.1f);
		InitializePlayer();
	}

	#region Player

	private void InitializePlayer()
	{
		var _go = new GameObject();
		var lossyScale = _go.transform.lossyScale;
		var _player = new Player(Random.Range(90, 110));
		var _sr = _go.AddComponent<SpriteRenderer>();
		var sprite = _sr.sprite;
		var _col = _go.AddComponent<BoxCollider2D>();
		_go.AddComponent<CollisionReader>();
		_go.AddComponent<Rigidbody2D>();
		players.Add(_go, _player);
		_player.Debug();
		sprite = sprites["player"];
		_sr.sprite = sprite;
		_col.offset = new Vector2(0, 0);
		_col.size = new Vector3
		(sprite.bounds.size.x / lossyScale.x,
			sprite.bounds.size.y / lossyScale.y,
			sprite.bounds.size.z / lossyScale.z);
		callback();
	}

	#endregion
}