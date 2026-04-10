using System;
using UnityEngine;

public class LevelOverController: MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            Debug.Log("Level finsihed by the Player");
        }
    }
}
