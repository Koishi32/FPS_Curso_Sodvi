using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activar_vuelo : MonoBehaviour
{
    public Movimiento vuelo_jugador;
    bool se_activo = false;
    // Start is called before the first frame update
    public void activa_vuelo() {
        if (!se_activo) {
            se_activo = true;
            vuelo_jugador.Tiempo_vuelo();
            StartCoroutine("Tiempo_vida");
        }
    }
    IEnumerator Tiempo_vida() {
        //HACER ESTO ANTES
        yield return new WaitForSeconds(0.5f);//espera
        Destroy(this.gameObject); //Destruye Objeto
        //DESPUES   
    }
}
