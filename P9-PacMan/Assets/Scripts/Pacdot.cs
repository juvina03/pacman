using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pacdot : MonoBehaviour
{
    public delegate void OnDestroyHandle(Pacdot pacdot);
    public event OnDestroyHandle OnDestroyed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "pacman_0")
        {
            OnDestroyed?.Invoke(this);
            Destroy(gameObject);
        }
    }
}
