using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala : Modificacion
{
    public  GameObject proyectil;
    // Start is called before the first frame update
    public override void lanza_rayos()
    {

        imagen_seleccion.fillAmount += 1 / limit * Time.deltaTime; // acumalara conforme al tiempo de unity(frames)

        if (imagen_seleccion.fillAmount == 1)
        {
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0)); //el viewport de la camara se expresa en (x,y), 
                                                                                  //(0,0) siendo esquina inferior izquierda y (1,1) esquina superior derecha
            if (Physics.Raycast(ray, out rayo_info, Mathf.Infinity) && rayo_info.collider.tag == "Enemigo_A")
            {
                Instantiate(proyectil, transform.position, Quaternion.identity);
            }
        }
    }
}
