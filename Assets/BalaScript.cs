using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaScript : MonoBehaviour
{
    [SerializeField] private float velocity;
    [SerializeField] private float attack;
    [SerializeField] public Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(direction);
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
        }
    }
}
