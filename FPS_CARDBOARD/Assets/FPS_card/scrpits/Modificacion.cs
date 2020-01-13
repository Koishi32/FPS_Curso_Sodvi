using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Modificacion : MonoBehaviour
{
    public Image imagen_seleccion;
    bool staring_to;
    public float limit; // Entre mas grande mas lento se llena cuando mira
    RaycastHit rayo_camara; // almacena informacion conseguida del objeto colisionada con el raycast
    GvrPointerPhysicsRaycaster gvrPointer;
    public  void Start()
    {
     staring_to = false;
    imagen_seleccion = this.GetComponent<Image>();
    imagen_seleccion.fillAmount = 0;
    }
    // Start is called before the first frame update
    private void Update()
    {
        llenar();
    }
    private void LateUpdate ()
    {
        
        Transform camarita = Camera.main.transform; //transform de la main camera
       
        if (Physics.Raycast(camarita.position, camarita.forward, out rayo_camara, 2000, 0) && rayo_camara.transform.tag == "Interactuable")
        {
            staring_to = true; // si mira a algo interactuable entonces la imagen se empezara a llenar
        }
        else {
            staring_to = false;
        }
    }
    private void llenar () {
        if (!staring_to)
        {
            imagen_seleccion.fillAmount = 0; // Reiinicia el gaze Input
        }
        else
        {
            if (imagen_seleccion.fillAmount == 1)
            {
                staring_to = false;
                imagen_seleccion.fillAmount = 0; // Reinicia los parametros 
                rayo_camara.transform.gameObject.GetComponent<Accion_Interac>().accion();
            }
            else
            {
                imagen_seleccion.fillAmount += 1 / limit * Time.deltaTime;
            }
        }
    }
    
}
