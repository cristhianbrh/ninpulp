using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctopusScript : MonoBehaviour
{
    [SerializeField] private float speed = 20f;
    [SerializeField] public Vector2 vectorMove;
    [SerializeField] private AudioClip colision;

    void Update()
    {
        transform.Translate(vectorMove * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("WallInvisible"))
        {
            vectorMove = new Vector2(-vectorMove.x, vectorMove.y);
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }

        // Colisión con la bala
        if (other.CompareTag("Bala"))
        {
            AudioManager.Instance.EjecutarSonido(colision);
            Destroy(gameObject);
        }
    }
}
