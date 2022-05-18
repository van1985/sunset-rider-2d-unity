using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_handler : MonoBehaviour
{
    Vector2 velocidad;
    bool is_grounded = false;
    public float vel_desp;
    public GameObject spr1;
    public GameObject spr2;
    // Start is called before the first frame update
    void Start()
    {
        int vidasJugador;
        int puntosJugador = 0;
        string nombreJugador = "Billy";
        float golpeJugador = 50.4f;

        vidasJugador = 2;
        nombreJugador = "GAME OVER";
        // Debug.Log(vidasJugador);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 posicion = transform.position;
        if (Input.GetKeyDown(KeyCode.A)) {
            velocidad.x -= 0.7f;
            //transform.position = posicion;
            Debug.Log("A");
            if (!spr1.GetComponent<SpriteRenderer>().flipX) {
                spr1.GetComponent<SpriteRenderer>().flipX = true;
                spr2.GetComponent<SpriteRenderer>().flipX = true;
                //spr2.transform.position += new Vector3(-0.07f, 0, 0);
            }
            GetComponent<Animator>().SetInteger("estado", 1);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            velocidad.x = 0.7f;
            //transform.position = posicion;
            Debug.Log("D");
            if (spr1.GetComponent<SpriteRenderer>().flipX)
            {
                spr1.GetComponent<SpriteRenderer>().flipX = false;
                spr2.GetComponent<SpriteRenderer>().flipX = false;
                //spr2.transform.position += new Vector3(+0.07f, 0, 0);
            }
            GetComponent<Animator>().SetInteger("estado", 1);
        }

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D)) {
            velocidad.x = 0.0f;
            GetComponent<Animator>().SetInteger("estado", 0);
        }

        if (Input.GetKeyDown(KeyCode.W)) {
            Debug.Log("W");
        }

        if (Input.GetKeyDown(KeyCode.S)) {
            Debug.Log("S");
        }

    }

    private void FixedUpdate()
    {
        Debug.Log("entro3");
        if (!is_grounded) {
            velocidad += Physics2D.gravity * Time.deltaTime;
        }

        GetComponent<Rigidbody2D>().position += velocidad * Time.deltaTime;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Suelo") {
            Debug.Log("entro");
            if (!is_grounded) {
                Debug.Log("entro2");
                is_grounded = true;
                velocidad.y = 0;
            }
        }
        
    }
}
