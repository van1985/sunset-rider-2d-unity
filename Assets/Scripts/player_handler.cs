using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_handler : MonoBehaviour
{
    Vector2 velocidad;
    bool is_grounded = true;
    public float vel_desp;
    public float vel_jump;
    public GameObject spr1;
    public GameObject spr2;
    private Vector2 pos_min;
    private Vector2 pos_max;
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        int vidasJugador;
        int puntosJugador = 0;
        string nombreJugador = "Billy";
        float golpeJugador = 50.4f;

        vidasJugador = 2;
        nombreJugador = "GAME OVER";
        pos_min = GameObject.Find("Level_min").transform.position;
        pos_max = GameObject.Find("Level_max").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 posicion = transform.position;
        if (Input.GetKeyDown(KeyCode.A)) {
            velocidad.x -= 0.7f;
            if (!spr1.GetComponent<SpriteRenderer>().flipX) {
                spr1.GetComponent<SpriteRenderer>().flipX = true;
                spr2.GetComponent<SpriteRenderer>().flipX = true;
                if (is_grounded) {
                    if (velocidad.x != 0)
                    {
                        spr1.transform.position += new Vector3(-0.035f, 0, 0);
                    }
                    else {
                        spr1.transform.position += new Vector3(-0.025f, 0, 0);
                    }
                    
                }
            }

            if (is_grounded)
            {
                GetComponent<Animator>().SetInteger("estado", 1);
            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            velocidad.x = 0.7f;
            if (spr1.GetComponent<SpriteRenderer>().flipX)
            {
                spr1.GetComponent<SpriteRenderer>().flipX = false;
                spr2.GetComponent<SpriteRenderer>().flipX = false;
            }
            if (is_grounded) {
                GetComponent<Animator>().SetInteger("estado", 1);
            }
            
        }

        if ((Input.GetKeyUp(KeyCode.A) && velocidad.x < 0) || (Input.GetKeyUp(KeyCode.D) && velocidad.x > 0 )) {
            velocidad.x = 0.0f;
            if (is_grounded)
            {
                GetComponent<Animator>().SetInteger("estado", 0);
            }
        }

        if (Input.GetKeyDown(KeyCode.W)) {
            Debug.Log("W");
        }

        if (Input.GetKeyDown(KeyCode.S)) {
            Debug.Log("S");
        }

        if (Input.GetKeyUp(KeyCode.C) && is_grounded) { // Jump
            GetComponent<Animator>().SetInteger("estado", 2);
            velocidad.y += vel_jump;
            is_grounded = false;
            if (!spr1.GetComponent<SpriteRenderer>().flipX)
            {
                spr2.transform.position += new Vector3(-0.01f, 0, 0);
            }
            else 
            {
                spr2.transform.position += new Vector3(0.01f, 0, 0);
            }
        }
        
        if (Input.GetKeyDown(KeyCode.X)){
          GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
        }

    }

    private void FixedUpdate()
    {
        if (!is_grounded) {
            velocidad += Physics2D.gravity * Time.deltaTime;
        }

        GetComponent<Rigidbody2D>().position += velocidad * Time.deltaTime;
        checkBounds();
    }

    void checkBounds() {
        if (GetComponent<Rigidbody2D>().position.x > pos_max.x)
        {
            GetComponent<Rigidbody2D>().position = new Vector2(pos_max.x, GetComponent<Rigidbody2D>().position.y);
        }
        else if ( GetComponent<Rigidbody2D>().position.x < pos_min.x) {
            GetComponent<Rigidbody2D>().position = new Vector2(pos_min.x, GetComponent<Rigidbody2D>().position.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Suelo") {
            if (!is_grounded) {
                is_grounded = true;
                velocidad.y = 0;
                if (velocidad.x != 0)
                {
                    GetComponent<Animator>().SetInteger("estado", 1);
                }
                else {
                    GetComponent<Animator>().SetInteger("estado", 0);
                }
                
            }
        }
        
    }
}
