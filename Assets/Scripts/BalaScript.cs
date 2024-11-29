using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BalaScript : MonoBehaviour
{
    [SerializeField] private float velocity;
    [SerializeField] private float attack;
    [SerializeField] public Vector2 direction;
    GameObject gameManager;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(direction);
        gameManager = GameObject.Find("GameController");
        configuration();
    }


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * velocity * Time.deltaTime);

    }
    private void configuration()
    {

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        // Aplicar la rotación
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("WallInvisible"))
        {
            Destroy(gameObject);
            return;
        }
        if (other.gameObject.tag=="Enemy")
        {
            gameManager.GetComponent<GameController>().AddScore(5);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
         if (other.gameObject.tag == "Enemy")
        {
            // Reproducir sonido y destruir el objeto si colisiona con una bala
            // AudioSource.PlayClipAtPoint(colision, transform.position);
            Destroy(gameObject);
            Debug.Log("chocado con bala");
        }
    }


     
}
