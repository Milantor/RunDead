using System;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
	// VisualCointroller visual;
	// ������� ����� ��������� � ���� ���������� � �������� � ��������.
	// ������� ��� �������� ��������. �� ����������� ��������� VisibleEntity?

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
    // FIXME: ������� �������
    public override string ToString() => ($"Entity \"{GetType().Name}\"");
}