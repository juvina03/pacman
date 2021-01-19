using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Animator))]
public class PacmanMove : MonoBehaviour
{
    private enum Direction
    {
        STOP,
        LEFT,
        RIGHT,
        UP,
        DOWN
    }

    [SerializeField] private float speed = .4f;
    Vector2 dest =  Vector2.zero;
    Rigidbody2D rb = null;
    Animator animator = null;
    Direction direction = Direction.STOP;
    

    // Start is called before the first frame update
    void Start()
    {
        dest = transform.position;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        Vector2 p = Vector2.MoveTowards(transform.position, dest, speed);
        if (rb != null)
            rb.MovePosition(p);

        if (direction == Direction.RIGHT)
            dest = (Vector2)transform.position + Vector2.right;
        if (direction == Direction.LEFT)
            dest = (Vector2) transform.position + Vector2.left;
        if (direction == Direction.UP)
            dest = (Vector2) transform.position + Vector2.up;
        if (direction == Direction.DOWN)
            dest = (Vector2) transform.position + Vector2.down;

        Vector2 dir = dest - (Vector2)transform.position;
        animator.SetFloat("DirX", dir.x);
        animator.SetFloat("DirY", dir.y);

    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
            direction = Direction.RIGHT;
        if (Input.GetKey(KeyCode.LeftArrow))
            direction = Direction.LEFT;
        if (Input.GetKey(KeyCode.UpArrow))
            direction = Direction.UP;
        if (Input.GetKey(KeyCode.DownArrow))
            direction = Direction.DOWN;
    }
}
