using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ColliderChecker : MonoBehaviour
{
    public bool IsTouch { get => connectedCollidets.Count > 0; }
    LinkedList<Collider2D> connectedCollidets = new();

    private void OnTriggerEnter2D(Collider2D collision) => connectedCollidets.AddLast(collision);
    private void OnTriggerExit2D(Collider2D collision) => connectedCollidets.Remove(collision);
}
