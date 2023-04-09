using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;

public class MovementController : MonoBehaviour
{
	private WorldController _worldController;
	private (GameObject?, Player) _player;
	private Rigidbody2D _rb;
	private List<Collision2D> floors = new();
	private bool onGround;

	private void Start()
	{
		_worldController = WorldController._instance;
		Debug.Log(_worldController);
		_worldController.callback = Do;
	}

	private void Do()
	{
		_player = (_worldController.players.First().Key, _worldController.players.First().Value);
		_player.Item1.GetComponent<CollisionReader>().collisionEnter = CollisionEnter;
		_player.Item1.GetComponent<CollisionReader>().collisionExit = CollisionExit;
		_rb = _player.Item1.GetComponent<Rigidbody2D>();
	}

	private void CollisionEnter(Collider2D self, Collision2D other)
	{
		//if (self.bounds.min.y >= other.gameObject.GetComponent<Collider2D>().bounds.max.y)
		//{
			floors.Add(other);
			onGround = true;
	//	}
	}
	private void CollisionExit(Collider2D self, Collision2D other)
	{
		if (floors.Contains(other))
		{
			floors.Remove(other);
		}

		if (floors.Count == 0)
		{
			onGround = false;
		}
	}

	private void Update()
	{
		if (_player.Item1 is not null)
		{
			Move(Input.GetAxisRaw("Horizontal"));
			if (Constants.IsKeyDown("Jump")) Jump();
		}
	}

	private void Move(float value)
	{
		if (Mathf.Abs(value) > 0.01)
		{
			_rb.AddForce(value > 0
				? new Vector2(
					Mathf.Clamp(Constants.MAX_WALK_SPEED - _rb.velocity.x, 0, Constants.MAX_WALK_ACCELERATION),
					0)
				: new Vector2(
					-Mathf.Clamp(Constants.MAX_WALK_SPEED + _rb.velocity.x, 0, Constants.MAX_WALK_ACCELERATION),
					0));
			_rb.drag = 0;
		}
		else
		{
			_rb.drag = 2;
		}
	}

	private void Jump()
	{
		if(onGround)
			_rb.AddForce(new Vector2(0, 4).normalized * Constants.JUMP_POWER);
	}

	private void Dash()
	{

	}
}