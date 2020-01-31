using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_imput : Gaze_input
{
    public Menu_manager menu;

    public override void ejecutar()
    {
        if (GvrPointerInputModule.CurrentRaycastResult.gameObject.name == "Start")
        {
            menu.empieza();
        }
        else if (GvrPointerInputModule.CurrentRaycastResult.gameObject.name == "Exit") {
            menu.salir();
        }
    }
    public override void lanzar()
    {
        Vector3 dir_camara = Camera.main.transform.forward.normalized *2;
        var clon = Instantiate(bala, Camera.main.transform.position + dir_camara, Camera.main.transform.rotation);
        clon.GetComponent<Rigidbody>().AddForce(clon.transform.forward * velocidad_bala);
        Destroy(clon.gameObject, duracion_bala);
    }
}
