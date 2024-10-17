using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctopusScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float speed = 20f;
    [SerializeField] public Vector2 vectorMove;
    GameObject gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameController");
    }

    // Update is called once per frame
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
        if (other.CompareTag("Player"))
        {
            gameManager.GetComponent<GameController>().ModifyHealt(-1);
        }
    }
}
