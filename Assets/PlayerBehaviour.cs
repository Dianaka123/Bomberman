using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    
    private bool isMovement;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private GameObject bomb;

    public void FixedUpdate()
    {
        if (isMovement)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MovePlayerTo(Vector2.left);
        }
        
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MovePlayerTo(Vector2.right);
        }
        
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            MovePlayerTo(Vector2.up);
        }
        
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            MovePlayerTo(Vector2.down);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            var bombObj = Instantiate(bomb, (Vector2)gameObject.transform.position, Quaternion.identity);
        }

    }
    
    
    private void MovePlayerTo(Vector2 direction)
    {
        if (Raycast(direction))
        {
            return;
        }
        isMovement = true;
        var pos = (Vector2) transform.position + direction;
        transform.DOMove(pos, 0.5f)
            .OnComplete(() => isMovement = false);
    }

    private bool Raycast(Vector2 direction)
    {
        var hit = Physics2D.Raycast(transform.position, direction, 1f, layerMask);
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
