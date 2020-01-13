using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Modificacion : Seleccion
{
    public Transform Personaje_teleport;
    public override void Start()
    {
        base.Start();
        Personaje_teleport = GameObject.Find("Personaje").GetComponent<Transform>();
    }
    // Start is called before the first frame update
    public void llevar_aqui() // funcion a activar para cuando sea mirada por el usuario
    {
        Personaje_teleport.position = this.transform.position;
        print("lleva");
    }
}
