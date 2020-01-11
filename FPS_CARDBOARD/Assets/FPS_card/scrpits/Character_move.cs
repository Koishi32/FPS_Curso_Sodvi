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
    public bool volar;
    float y_caida; // Decidira si el objeto caera o sera manejado por el jugador

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
      
    }

    public void activate_move()
    {
        if (Can_move) {
            controlador.isKinematic = true; // No sera afectado por las fisicas 
            Can_move = false;
        }
        else
        {
            Can_move = true;
            controlador.isKinematic = false; // Sera afectado por las fisicas mientras se mueve
        }
      
    }
    //Revisa si deberia seguir la camara (volar) o seguir la gravedad
    void revisar_caida()
    {
        if (volar)
        {
            y_caida = direccion_camara.y; // vuela
        }
    }



}
