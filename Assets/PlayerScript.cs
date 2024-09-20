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
    private Animator playerAnimator;
    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
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
        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("Acción especial w activada");
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Acción especial A activada");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("Acción especial S activada");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("Acción especial D activada");
        }
    }
    private void Movement()
    {
        direction = Vector2.zero;
        playerAnimator.SetFloat("Vertical", 0f);
        playerAnimator.SetFloat("Horizontal", 0f);
        sr.flipY = false;


        if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction += Vector2.left;
            playerAnimator.SetFloat("Horizontal", -1f);
            playerAnimator.SetFloat("Vertical", 0f);
            sr.flipX = true;
            sr.flipY = false;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            direction += Vector2.right;
            playerAnimator.SetFloat("Horizontal", 1f);
            playerAnimator.SetFloat("Vertical", 0f);
            sr.flipX = false;
            sr.flipY = false;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            direction += Vector2.up;
            playerAnimator.SetFloat("Vertical", 1f);
            playerAnimator.SetFloat("Horizontal", 0f);
            sr.flipY = false;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            direction += Vector2.down;
            playerAnimator.SetFloat("Vertical", -1f);
            playerAnimator.SetFloat("Horizontal", 0f);
            sr.flipY = true;
        }
        // direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        direction = direction.normalized;
    }
}
