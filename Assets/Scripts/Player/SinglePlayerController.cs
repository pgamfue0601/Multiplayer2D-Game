using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinglePlayerController : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private float fuerzaSalto;
    [SerializeField] private List<GameObject> skinList;


    public Rigidbody2D rb;
    private Animator anim;
    private PlayerData localPlayerData;
    private GameObject localSkin;
    private Camera cam;
    public AudioSource jumping;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(transform.gameObject);
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        cam = FindObjectOfType<Camera>();
        jumping = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Move(); 
    }

    public void Move()
    {

        if (this.transform.rotation == Quaternion.identity) // Desplazamiento hacia la derecha
        {
            rb.velocity = (transform.right * velocidad * Input.GetAxis("Horizontal")) +
                    (transform.up * rb.velocity.y);
        }
        else
        { // Desplazamiento hacia la izuquierda
            rb.velocity = -(transform.right * velocidad * Input.GetAxis("Horizontal")) +
                (transform.up * rb.velocity.y);
        }

        // Actualizamos la posición
        this.transform.SetLocalPositionAndRotation(this.transform.position, this.transform.rotation);


        // Rotamos el jugador en función de la pulsación de teclas.
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            this.transform.rotation = Quaternion.identity;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            this.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }

        // Configuración del salto.
        if (Input.GetKeyDown(KeyCode.UpArrow) && (Mathf.Abs(rb.velocity.y) < 0.2f))
        {
            rb.AddForce(transform.up * fuerzaSalto);
            jumping.Play();
        }


        // Actualizamos la animación
        anim.SetFloat("velocidadX", Mathf.Abs(rb.velocity.x));
        anim.SetFloat("velocidadY", rb.velocity.y);

        // Seguimiento de cámara
        cam.transform.SetPositionAndRotation(new Vector3(this.transform.position.x + 2, this.transform.position.y + 2, -10), Quaternion.identity);

    }
}
