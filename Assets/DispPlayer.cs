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

    void Update()
    {
        tiempoDesdeUltimoDisparo += Time.deltaTime;

        if (tiempoDesdeUltimoDisparo >= timeIntoDisp)
        {
            Vector2? direction = null;

            if (Input.GetKeyDown(KeyCode.W)) direction = Vector2.up;
            else if (Input.GetKeyDown(KeyCode.A)) direction = Vector2.left;
            else if (Input.GetKeyDown(KeyCode.S)) direction = Vector2.down;
            else if (Input.GetKeyDown(KeyCode.D)) direction = Vector2.right;

            if (direction.HasValue)
            {
                Debug.Log($"Acción especial {direction} activada");
                Atack(direction.Value);
                tiempoDesdeUltimoDisparo = 0f;
            }
        }
    }

    private void Atack(Vector2 direction)
    {
        GameObject newBala = Instantiate(bala, controllerDisp.position, controllerDisp.rotation);
        newBala.tag = "Bala";
        proyectilSonido.Play();

        if (newBala.TryGetComponent(out BalaScript balaScript))
        {
            balaScript.direction = direction;
        }
    }
}