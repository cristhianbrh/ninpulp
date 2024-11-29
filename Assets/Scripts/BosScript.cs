using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BosScript : MonoBehaviour
{
    [SerializeField] public Slider healthBar;
    public float maxHealth = 100f; // Vida máxima del jefe
    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth; // Establecer la vida inicial
        UpdateHealthBar();
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0)
        {
            currentHealth = 0;
            Die();
        }
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.value = currentHealth / maxHealth; // Normaliza la vida entre 0 y 1
        }
    }

    private void Die()
    {
        Debug.Log("El jefe ha sido derrotado.");
        Destroy(gameObject);
        // Lógica para manejar la muerte del jefe
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bala"))
        {
            // Reproducir sonido y destruir el objeto si colisiona con una bala
            // AudioSource.PlayClipAtPoint(colision, transform.position);
            Destroy(other.gameObject);
            Debug.Log("chocado con bala");
            TakeDamage(10f);
        }
    }
}
