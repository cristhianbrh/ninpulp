using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
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
        Movement();
    }
    private void FixedUpdate()
    {
        rigidbody2D.velocity = direction * speed;
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
        direction = direction.normalized;
    }
}
