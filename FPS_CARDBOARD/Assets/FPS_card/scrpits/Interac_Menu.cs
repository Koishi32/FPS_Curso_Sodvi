using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
public class Interac_Menu : Modificacion
{
    public Menu_manager menus;
    //GvrPointerGraphicRaycaster raycast_camara;
    public override void lanza_rayos()
    {
        
        imagen_seleccion.fillAmount += 1 / limit * Time.deltaTime; // acumalara conforme al tiempo de unity(frames)

        if (imagen_seleccion.fillAmount == 1)
        {
            if (GvrPointerInputModule.CurrentRaycastResult.gameObject.name == "empieza") {
                menus.empieza();
            }
            else if (GvrPointerInputModule.CurrentRaycastResult.gameObject.tag == "salida")
            {
                menus.salir();
            }
        }
    }
   
}
