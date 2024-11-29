using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para trabajar con escenas

public class OctopusScriptFin : MonoBehaviour
{
    [SerializeField] private float speed = 20f;
    [SerializeField] public Vector2 vectorMove;
    [SerializeField] private AudioClip colision;
    private bool isStopped = false;

    void Start()
    {
        // Inicialización si es necesario
    }

    void Update()
    {
       
            // Solo movemos horizontalmente
            vectorMove.y = 0;

            // Movemos al objeto
            transform.Translate(vectorMove * speed * Time.deltaTime);
       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("WallInvisible") || other.CompareTag("Enemy"))
        {
            // Solo cambiar la dirección cuando estamos en la escena "Final_Fight"
            
                vectorMove = new Vector2(-vectorMove.x, vectorMove.y);
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            
        }
        if (other.CompareTag("WallInvisible2"))
        {
            // Detenerse completamente si colisionamos con "WallInvisible2"
            vectorMove = Vector2.zero;
            isStopped = true;
        }

        if (other.CompareTag("Bala"))
        {
            // Reproducir sonido y destruir el objeto si colisiona con una bala
            AudioSource.PlayClipAtPoint(colision, transform.position);
            Destroy(gameObject);
        }
        if (other.CompareTag("Player"))
        {
            // Si colisiona con el jugador, modificar la salud
            GameObject gameManager = GameObject.Find("GameController");
            gameManager.GetComponent<GameController>().ModifyHealt(-1);
        }
    }
}