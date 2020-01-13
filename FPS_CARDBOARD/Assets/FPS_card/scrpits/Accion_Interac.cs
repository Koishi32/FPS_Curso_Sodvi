using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accion_Interac : MonoBehaviour
{
     public string opciones; // dependiendo de lo puesto en el editor cambiara la accion
    public void accion() {
        switch (opciones){
            case "tele":
                GameObject.FindGameObjectWithTag("Player").transform.position = this.transform.position + new Vector3(0, 1, 0); 
                // instancia al jugador en su pocision con un algo de distancia hacia arriba
                break;
            case "Ene":
                Destroy(this.gameObject);
                break;
          default:
                break;
        
        }
    }
}
