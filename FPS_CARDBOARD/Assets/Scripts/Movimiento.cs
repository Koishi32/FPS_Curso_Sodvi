using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public bool puede_mover;
    public float velocidad;
    Transform Camara_principal;
    Rigidbody Mi_rgb;
    public bool puede_volar;
    public float gravedad;
    public float tiempo_volando;
    // Start is called before the first frame update
    void Start()
    {
        puede_volar = false;
        Mi_rgb = this.GetComponent<Rigidbody>(); // Cuerpo jugador
        puede_mover = false; // No se mueve
        Camara_principal = Camera.main.GetComponent<Transform>(); // Direccion camara
    }
    public void Tipo_movimiento() {
        if (puede_volar)
        {
            Mi_rgb.velocity = Camara_principal.forward.normalized * velocidad; // Vuela normal
        }
        else {
            var dir = Camara_principal.forward.normalized;
            Mi_rgb.velocity = new Vector3(dir.x * velocidad, -gravedad, dir.z * velocidad);
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        Movimiento_Player();
    }
    public void Tiempo_vuelo() {
        puede_volar = true;
        StopAllCoroutines(); //Evita que se sobreponan los tiempos
        StartCoroutine("Tiempo");
    }
    IEnumerator Tiempo() {
        yield return new WaitForSeconds(tiempo_volando);//Espera
        puede_volar = false;
    }
    void Movimiento_Player() {
        if (puede_mover)
        {
            Mi_rgb.isKinematic = false; //perimite moverse
            Tipo_movimiento();
        }
        else {
            Mi_rgb.isKinematic = true; // se detine
        }
    }
}
