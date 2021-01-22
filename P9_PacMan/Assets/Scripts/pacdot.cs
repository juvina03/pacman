using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pacdot : MonoBehaviour
{
    public delegate void OnpacdoteatenHandler();
    public event OnpacdoteatenHandler Onpacdoteaten;

    void OnTriggerEnter2D(Collider2D co)
    {
        if (co.name == "pacman")
        {
            Onpacdoteaten();
            Destroy(gameObject);
        }
    }
}