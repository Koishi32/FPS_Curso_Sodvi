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
    public float gravedad;
    public GameObject volador;
    public GameObject No_volador;
    public Accion_Interac Activar_manual;
    //Recordar que structs y primitivos pasan sus variables por valor
    // clases y otros pasan su valor por referencia como el transform que siempre hara referencia a la camara
    // Start is called before the first frame update
    void Start() //inicializar variables
    {
        volar = false;
        No_volador.SetActive(true);
        volador.SetActive(false);
        controlador = this.GetComponent<Rigidbody>();
        Can_move = false;
        camera_player = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>(); //direccion delantera de la camara  
       
    }

    // Update is called once per frame
    void Update()
    {

        movimiento_player();
        checa_sprite();
        Disparar();
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }
    }
    void checa_sprite() {
        if (volar) {
            volador.SetActive(true);
            No_volador.SetActive(false);
                } else {
            volador.SetActive(false);
            No_volador.SetActive(true);
        }
    }
    void Disparar() {
        if (Input.GetButtonDown("Fire1"))
        {
            Activar_manual.Enemigo_act();
        }
    }
    void movimiento_player() {
        direccion_camara = camera_player.forward.normalized; // como es un valor se tiene que actualizar contantemente
        if (Can_move)
        {
            //Asegurarse que el objeto tenga gravedad activida o volara
            if (volar)
            {
                controlador.velocity = direccion_camara * vel/2; //recoje la direccion delantera de la camara y la multipica por velocidad
            }// Se divide entre dos para que no vuele tan rapido
            
            else{
                controlador.velocity = new Vector3(direccion_camara.x * vel, -gravedad, direccion_camara.z * vel) ; // siempre estara cayendo (gravedad)
            }
        }
      
    }

    public void activate_move() //llamado con un trigger en otro objeto
    {
        if (Can_move) { //Para no mover
            controlador.isKinematic = true; //  sera afectado por las fisicas 
            Can_move = false;
        }
        else //Para mover
        {
            Can_move = true;
            controlador.isKinematic = false; //No Sera afectado por las fisicas mientras se mueve
        }
      
    }

    public float tiempo_vuelo;
    public void Empieza_volar() { //Deja volar
        volar = true;
        //this.GetComponent<Rigidbody>().useGravity = false;
        StopAllCoroutines(); // Permite que se se extienda el tiempo de vuelo
         StartCoroutine("contador1");
    }

    IEnumerator contador1() //Deja caer
    {
        yield return new WaitForSeconds(tiempo_vuelo);
        volar = false;
        //this.GetComponent<Rigidbody>().useGravity = true;
    }
}


