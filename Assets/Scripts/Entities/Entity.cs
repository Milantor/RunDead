using System;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
	// VisualCointroller visual;
	// который будет содержать в себе информацию о спрайтах и анимаций.
	// Задаётся при создании сущности. Мб реализовать отедльную VisibleEntity?

	public delegate void OnDestroyEvent();
    public event OnDestroyEvent OnDestroy;

	public virtual void DestroyEntity()
	{
		OnDestroy?.Invoke();
		Destroy(gameObject);
	}
    protected virtual void Start()
    {
        
    }
	protected virtual void Update()
	{

	}
    // FIXME: сделать логгеры
    public override string ToString() => ($"Entity \"{GetType().Name}\"");
}