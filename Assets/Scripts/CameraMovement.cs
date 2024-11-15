using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public float cameraSpeed = 5f;
    public void MoveCamera(Vector3 newPosition)
    {
        newPosition.z = transform.position.z;
        StartCoroutine(MoveCameraToPosition(newPosition));
    }
    private IEnumerator MoveCameraToPosition(Vector3 newPosition)
    {
        
        while (Vector3.Distance(transform.position, newPosition) > 0.1f)
        {
            transform.position = Vector3.Lerp(transform.position, newPosition, cameraSpeed * Time.deltaTime);
            yield return null;
        }

        transform.position = newPosition;
    }
}
