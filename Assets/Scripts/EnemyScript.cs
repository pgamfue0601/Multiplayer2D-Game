using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Transform respawn;
    private AudioSource stomp;
    // Start is called before the first frame update
    void Start()
    {
        stomp = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.GetComponent<SinglePlayerController>())
            {
                collision.GetComponent<SinglePlayerController>().rb.velocity = Vector3.zero;
                collision.GetComponent<SinglePlayerController>().rb.AddForce(collision.GetComponent<SinglePlayerController>().gameObject.transform.up * 325);
            }

            if (collision.GetComponent<PlayerController>())
            {
                collision.GetComponent<PlayerController>().rb.velocity = Vector3.zero;
                collision.GetComponent<PlayerController>().rb.AddForce(collision.GetComponent<PlayerController>().gameObject.transform.up * 325);
            }
            AudioSource.PlayClipAtPoint(stomp.clip, gameObject.transform.position);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.position = respawn.position;
        }
    }
}
