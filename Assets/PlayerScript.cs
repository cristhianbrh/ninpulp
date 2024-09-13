using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // private float Horizontal;
    // private float Vertical; 
    // public float velocity;
    // public Tilemap wall;

    public float speed = 20f;
    public Vector2 direction;
    private Rigidbody2D rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // direction(Input.GetAxisRaw("Horizaontal"), Input.GetAxisRaw("Vertical"));
        Movement();
        MoveForDisp();

    }
    private void FixedUpdate()
    {
        rigidbody2D.velocity = direction * speed;
    }

    private void MoveForDisp()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("Acción especial w activada");
        }
        if(Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Acción especial A activada");
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("Acción especial S activada");
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("Acción especial D activada");
        }
    }
    private void Movement()
    {
        direction = Vector2.zero;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            direction += Vector2.up;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            direction += Vector2.down;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction += Vector2.left;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            direction += Vector2.right;
        }
        // direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        direction = direction.normalized;
    }
}
