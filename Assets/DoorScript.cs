using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public Transform newCameraPosition;
    public Transform previewCameraPosition;
     private bool cameraAtNewPosition = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
             if (!cameraAtNewPosition) // Si la cámara no está en la nueva posición
            {
                Camera.main.GetComponent<CameraMovement>().MoveCamera(newCameraPosition.position);
                cameraAtNewPosition = true; // Marca que la cámara ha cambiado a la nueva posición
            }
            else
            {
                Camera.main.GetComponent<CameraMovement>().MoveCamera(previewCameraPosition.position);
                cameraAtNewPosition = false; // Marca que la cámara ha vuelto a la posición previa
            }
        }
    }
}
