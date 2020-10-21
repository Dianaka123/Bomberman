using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.SceneManagement.SceneManager;

public class TNT : MonoBehaviour
{
    [SerializeField] private float seconds = 3;
    private IEnumerator Start()
    {
        Debug.Log(transform.position);
        yield return  new WaitForSeconds(seconds);
        Bum();
        
    }

    [SerializeField] private LayerMask explosiveMask;
    private void Bum()
    {
        var colliders = Physics2D.OverlapCircleAll(transform.position, 1f, explosiveMask);

        foreach (var collider in colliders)
        {
            if (collider.gameObject.layer == 10)
            {
                Scene scene = SceneManager.GetActiveScene(); 
                SceneManager.LoadScene(scene.name);
            }
            Destroy(collider.gameObject);
        }
        Destroy(gameObject);
    }
}
