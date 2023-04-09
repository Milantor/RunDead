using System;
using UnityEngine;

public class CollisionReader : MonoBehaviour
{
	public Action<Collider2D, Collision2D> collisionEnter, collisionExit;

	private void OnCollisionEnter2D(Collision2D col)
	{
		collisionEnter(GetComponent<Collider2D>(), col);
	}

	private void OnCollisionExit2D(Collision2D other)
	{
		collisionExit(GetComponent<Collider2D>(), other);
	}
}
