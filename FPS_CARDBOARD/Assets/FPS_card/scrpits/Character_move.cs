using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_move : MonoBehaviour
{
    public float vel;
    Rigidbody controlador;
    bool Can_move;
    Transform camera_player;
    Vector3 direccion_camara;

    // Start is called before the first frame update
    void Start() //inicializar variables
    {
        volar = false;
        controlador = this.GetComponent<Rigidbody>();
        Can_move = false;
        camera_player = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>(); //direccion delantera de la camara  
       
    }

    // Update is called once per frame
    void Update()
    {
        revisar_caida();
        movimiento_player();

    }
   
    void movimiento_player() {
        direccion_camara = camera_player.forward.normalized;
        if (Can_move)
        {
            //Asegurarse que el objeto tenga gravedad activida o volara
            controlador.velocity = new Vector3(direccion_camara.x, y_caida, direccion_camara.z) * vel; //recoje la direccion delantera de la camara y la multipica por velocidad
        }
        else
        {
            controlador.velocity = new Vector3(0, y_caida, 0); //Solo permite caida en el eje y
        }
    }

    public void activate_move()
    {
        if (Can_move) {
            Can_move = false;
        }
        else
        Can_move = true;
    }

    public bool volar;
    float y_caida; // Decidira si el objeto caera o sera manejado por el jugador

    void revisar_caida()
    {
        if (volar)
        {
            y_caida = direccion_camara.y; // vuela
        }
        else
        {
            y_caida = controlador.velocity.y; // cae con gravedad pura
        }
    }

    public void Activar_vuelo()
    {
        if (!volar)
        {
            volar = true;
            Invoke("desactiva_vuelo", 6.0f);
        }
    }
    void desactiva_vuelo()
    {
        volar = false;
    }
}
