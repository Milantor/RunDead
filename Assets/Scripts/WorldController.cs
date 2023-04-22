using Entities.Player;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class WorldController : MonoBehaviour
{
	public static WorldController Instance;

	public event Action PostInit;

	public GameObject PlayerPrefab;
	public Player MainPlayer;

	private void Awake()
	{
		Instance = this;
	}

    private void Start()
    {
        // Инициализируем игрока
		MainPlayer = Instantiate(PlayerPrefab).GetComponent<Player>();
		MainPlayer.SetController(new PlayerInputController());
    }
}