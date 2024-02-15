using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI puntuacion;
    private AudioSource coinPicked;
    // Start is called before the first frame update
    private void Awake()
    {
        coinPicked = GetComponent<AudioSource>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(coinPicked.clip, gameObject.transform.position);
            puntuacion.text = (Int32.Parse(puntuacion.text) + 10).ToString();
            Destroy(gameObject);
        }  
    }
}
