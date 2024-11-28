using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnTrigger : MonoBehaviour
{
    public string nextSceneName; // Nombre de la escena a cargar

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si el objeto que colisiona es el personaje
        if (other.CompareTag("Player")) 
        {
            SceneManager.LoadScene(nextSceneName); // Cambia a la escena indicada
        }
    }
}
