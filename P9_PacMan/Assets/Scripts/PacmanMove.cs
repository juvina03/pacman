using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PacmanMove : MonoBehaviour
{
    public float speed = 0.4f;
    Vector2 dest = Vector2.zero;
    private bool death = false;
    void Start()
    {
        dest = transform.position;
    }
    void FixedUpdate()
    {
        // Move closer to Destination
        Vector2 p = Vector2.MoveTowards(transform.position, dest, speed);
        GetComponent<Rigidbody2D>().MovePosition(p);

        if (Input.GetKey(KeyCode.RightArrow))
            dest = (Vector2)transform.position + Vector2.right;
        if (Input.GetKey(KeyCode.LeftArrow))
            dest = (Vector2)transform.position + Vector2.left;
        if (Input.GetKey(KeyCode.DownArrow))
            dest = (Vector2)transform.position - Vector2.up;
        if (Input.GetKey(KeyCode.UpArrow))
            dest = (Vector2)transform.position - Vector2.down;

        // Animation Parameters
        Vector2 dir = dest - (Vector2)transform.position;
        GetComponent<Animator>().SetFloat("DirX", dir.x);
        GetComponent<Animator>().SetFloat("DirY", dir.y);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (death)
        {
            return;
        }
        if (collision.TryGetComponent<GhostMove>(out GhostMove ghost))
        {
            GetComponent<Animator>().SetBool("Death",true);
            death = true;
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            GetComponent<Animator>().SetFloat("DirX", 0);
            GetComponent<Animator>().SetFloat("DirY", 0);
        }
    }
}
