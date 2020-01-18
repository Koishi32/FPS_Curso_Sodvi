using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class Modificacion : MonoBehaviour
{
    public Image imagen_seleccion;
    public bool staring_to;
    public float limit; // Entre mas grande mas lento se llena cuando mira
    public RaycastHit rayo_info;
    
    public  void Start()
    {
     staring_to = false;
    imagen_seleccion = this.GetComponent<Image>();
    imagen_seleccion.fillAmount = 0;
    }
    // Start is called before the first frame update
    private void Update()
    {
        if (staring_to) {
            lanza_rayos();
        }   
    }
    public virtual void  lanza_rayos() {
        imagen_seleccion.fillAmount += 1 / limit * Time.deltaTime; // acumalara conforme al tiempo de unity(frames)
       
        if (imagen_seleccion.fillAmount == 1)
        {
            ejecutar();
        }
    }
    public  void ejecutar() {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0)); //el viewport de la camara se expresa en (x,y), 
                                                                      //(0,0) siendo esquina inferior izquierda y (1,1) esquina superior derecha
        if (Physics.Raycast(ray, out rayo_info, Mathf.Infinity))
        {  //Recoje la informacion de ray para rayo_info a una distancia de 20 unidades
            if (rayo_info.collider.tag == "Portal") {
                rayo_info.collider.GetComponent<Accion_Interac>().teletransportacion();
            } else if (rayo_info.collider.tag == "Enemigo") {
                rayo_info.collider.GetComponent<Accion_Interac>().Enemigo_act();
            } 
        }
    }

    // Se llamara estas funciones desde el GVR editor para actvivar y desactivar el puntero
    public void mirar()
    {
        staring_to = true;
    }
    public void no_mirar() {
        staring_to = false;
        imagen_seleccion.fillAmount =0;
    }
    
}
