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

    // Sonidos para movimiento
    public AudioSource horizontalMoveSound;
    public AudioSource verticalMoveSound;
    
    private bool isMovingHorizontal;
    private bool isMovingVertical;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

        isMovingHorizontal = false;
        isMovingVertical = false;

        // Habilitar loop para ambos sonidos
        horizontalMoveSound.loop = true;
        verticalMoveSound.loop = true;
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

        bool movingHorizontally = false;
        bool movingVertically = false;

        // Detectar movimiento horizontal
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction += Vector2.left;
            playerAnimator.SetFloat("Horizontal", -1f);
            sr.flipX = true;
            movingHorizontally = true;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            direction += Vector2.right;
            playerAnimator.SetFloat("Horizontal", 1f);
            sr.flipX = false;
            movingHorizontally = true;
        }

        // Detectar movimiento vertical
        if (Input.GetKey(KeyCode.UpArrow))
        {
            direction += Vector2.up;
            playerAnimator.SetFloat("Vertical", 1f);
            movingVertically = true;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            direction += Vector2.down;
            playerAnimator.SetFloat("Vertical", -1f);
            sr.flipY = true;
            movingVertically = true;
        }

        direction = direction.normalized;

        // Manejar sonido para movimiento horizontal
        if (movingHorizontally)
        {
            if (!isMovingHorizontal)
            {
                horizontalMoveSound.Play();
                isMovingHorizontal = true;
            }
        }
        else if (isMovingHorizontal)
        {
            horizontalMoveSound.Stop();
            isMovingHorizontal = false;
        }

        // Manejar sonido para movimiento vertical
        if (movingVertically)
        {
            if (!isMovingVertical)
            {
                verticalMoveSound.Play();
                isMovingVertical = true;
            }
        }
        else if (isMovingVertical)
        {
            verticalMoveSound.Stop();
            isMovingVertical = false;
        }
    }
}
