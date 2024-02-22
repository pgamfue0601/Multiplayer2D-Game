using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishGoal : MonoBehaviour
{
    [SerializeField] private AudioSource m_AudioSource;
    private AudioSource win;
    // Start is called before the first frame update
    void Start()
    {
        win = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(EndGoal(collision));
    }

    private IEnumerator EndGoal(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            m_AudioSource.Stop();
            if (collision.GetComponent<SinglePlayerController>())
            {
                collision.GetComponent<SinglePlayerController>().rb.velocity = Vector3.zero;
                collision.GetComponent<SinglePlayerController>().rb.AddForce(collision.GetComponent<SinglePlayerController>().gameObject.transform.up * 325, ForceMode2D.Impulse);
            }

            if (collision.GetComponent<PlayerController>())
            {
                collision.GetComponent<SinglePlayerController>().rb.velocity = Vector3.zero;
                collision.GetComponent<PlayerController>().rb.AddForce(collision.GetComponent<PlayerController>().gameObject.transform.up * 325, ForceMode2D.Impulse);
            }
            win.Play();
            yield return new WaitForSeconds(9f);
            Debug.Log("Juego finalizado");
            SceneManager.LoadScene("MenuScene");
        }
        
    }
}
