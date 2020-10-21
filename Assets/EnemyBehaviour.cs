using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private Vector3 direction;
    [SerializeField] private float speed;
    [SerializeField] private LayerMask layerMask;
    private bool isBoard;
    private void FixedUpdate()
    {        
        var offset = Time.deltaTime * speed * direction;
        if (Raycast(offset))
        {
            direction *= -1;
            return;
        }
        transform.position += offset;

    }
    
    private bool Raycast(Vector2 direction)
    {
        var hit = Physics2D.Raycast(transform.position, direction, 0.1f, layerMask);
        if (hit.collider == null)
        {
            Debug.Log(null);
        }
        else
        {
            Debug.Log(hit.collider.name);
        }
        return hit.collider != null;
    }
}
