using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DispPlayer : MonoBehaviour
{
    [SerializeField] private Transform controllerDisp;
    [SerializeField] private GameObject bala;
    [SerializeField] private float timeIntoDisp = 0.01f;
    [SerializeField] private AudioSource proyectilSonido;

    private float tiempoDesdeUltimoDisparo;

    // void Update()
    // {
    //     tiempoDesdeUltimoDisparo += Time.deltaTime;

    //     if (tiempoDesdeUltimoDisparo >= timeIntoDisp)
    //     {
    //         Vector2? direction = null;

    //         if (Input.GetKeyDown(KeyCode.W)) direction = Vector2.up;
    //         else if (Input.GetKeyDown(KeyCode.A)) direction = Vector2.left;
    //         else if (Input.GetKeyDown(KeyCode.S)) direction = Vector2.down;
    //         else if (Input.GetKeyDown(KeyCode.D)) direction = Vector2.right;

    //         if (direction.HasValue)
    //         {
    //             Debug.Log($"Acción especial {direction} activada");
    //             Atack(direction.Value);
    //             tiempoDesdeUltimoDisparo = 0f;
    //         }
    //     }
    // }

    private void Atack(Vector2 direction)
    {
        GameObject newBala = Instantiate(bala, controllerDisp.position, controllerDisp.rotation);
        newBala.tag = "Bala";
        proyectilSonido.Play();
        BalaScript balaScript = newBala.GetComponent<BalaScript>();
        if (balaScript != null)
        {
            balaScript.direction = direction;
        }
    }
    void Update()
    {
        tiempoDesdeUltimoDisparo += Time.deltaTime;
        if (tiempoDesdeUltimoDisparo >= timeIntoDisp)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                Debug.Log("Acción especial w activada");
                Atack(Vector2.up);
                tiempoDesdeUltimoDisparo = 0f;

            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                Debug.Log("Acción especial A activada");
                Atack(Vector2.left);
                tiempoDesdeUltimoDisparo = 0f;

            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                Debug.Log("Acción especial S activada");
                Atack(Vector2.down);
                tiempoDesdeUltimoDisparo = 0f;

            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                Debug.Log("Acción especial D activada");
                Atack(Vector2.right);
                tiempoDesdeUltimoDisparo = 0f;

            }
        };
    }
}


