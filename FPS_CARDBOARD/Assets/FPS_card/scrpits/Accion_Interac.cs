using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Accion_Interac : MonoBehaviour
{
    public float recarga_portal; // tiempo de espera para que el portal se reactive
    bool puede_usar;
    public float offset_y; // distancia que aparecera por arriba del portal
    Transform posicionPlayer;
    public Transform lugar_instancia;
    public float fuerza;
    public GameObject proyectil;
    public  void Start()
    {
        puede_usar = true;
        posicionPlayer = GameObject.FindGameObjectWithTag("Player").transform;
    }
   public void teletransportacion()
    {
        if (puede_usar)
        {
            posicionPlayer.position = new Vector3(this.transform.position.x, this.transform.position.y + offset_y, this.transform.position.z);
            puede_usar = false;
            StartCoroutine("tiempo_carga");
            // instancia al jugador en su pocision con un algo de distancia hacia arriba
        }

    }

    public void Enemigo_act() {
        var bala = Instantiate(proyectil,lugar_instancia.position,Quaternion.identity);
        
        posicionPlayer.gameObject.GetComponentInChildren<Image>().fillAmount = 0;
        posicionPlayer.gameObject.GetComponentInChildren<Modificacion>().staring_to = false; // reinica parametros del puntero
        posicionPlayer.gameObject.GetComponentInChildren<Modificacion>().no_mirar();
    }

    private IEnumerator tiempo_carga()
    { // funcion que espera unos segundos antes de usarse
        yield return new WaitForSeconds(recarga_portal);
        puede_usar = true;
    }
}
