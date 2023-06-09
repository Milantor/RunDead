using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEngine.KeyCode;

public static class Constants
{
	// Player
	public const float DASH_TIME = .3f;
	public const float DASH_SPEED = 10f;

	public const float JUMP_POWER = 500f;
	public const float MAX_WALK_ACCELERATION = 6f;
	public const float MAX_WALK_SPEED = 8f;

	// Control
	/// <summary>
	/// Нужен для назначения нескольких клавиш на одно действие
	/// </summary>
	private static Dictionary<string, List<KeyCode>> keysDefinitions = new()
	{
		{ "Jump", new List<KeyCode>() { KeyCode.Space } },
		{ "Dash", new List<KeyCode>() { LeftControl } },
		{ "Reload", new List<KeyCode>() { R } },
		{ "Inventory", new List<KeyCode>() { Tab } },
	};

	public static bool IsKeyDown(string name)
	{
		var keys = keysDefinitions[name];
		return keys.Any(i => Input.GetKeyDown(i));
	}

	public static bool IsKey(string name)
	{
		var keys = keysDefinitions[name];
		return keys.Any(i => Input.GetKey(i));
	}

	public static bool IsKeyUp(string name)
	{
		var keys = keysDefinitions[name];
		return keys.Any(i => Input.GetKeyUp(i));
	}

	public static bool IsMouseDown(int button)
	{
		return Input.GetMouseButtonDown(button);
	}

	public static bool IsMouse(int button)
	{
		return Input.GetMouseButton(button);
	}

	public static bool IsMouseUp(int button)
	{
		return Input.GetMouseButtonUp(button);
	}
}