using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Accion_Interac : MonoBehaviour
{
     public string opciones; // dependiendo de lo puesto en el editor cambiara la accion
    public float recarga_portal; // tiempo de espera para que el portal se reactive
    bool puede_usar;
    public float offset_y; // distancia que aparecera por arriba del portal
    Transform posicionPlayer;
    public GameObject sistema_particulas;
    public void Start()
    {
        puede_usar = true;
        posicionPlayer = GameObject.FindGameObjectWithTag("Player").transform;
        
    }
    public void accion() { // depende de lo quese quiera hacer con la mira
        switch (opciones){
            case "tele":
                if (puede_usar)
                {
                    posicionPlayer.position = new Vector3(this.transform.position.x, this.transform.position.y + offset_y, this.transform.position.z);
                    puede_usar = false;
                    StartCoroutine("tiempo_carga");
                    // instancia al jugador en su pocision con un algo de distancia hacia arriba
                }
                    break;
            case "Ene":

                GameObject.Instantiate(sistema_particulas, this.transform.position, Quaternion.identity); //instancia sistema particulas para efecto
                sistema_particulas.GetComponent<ParticleSystem>().Play();
                posicionPlayer.gameObject.GetComponentInChildren<Image>().fillAmount = 0;
                posicionPlayer.gameObject.GetComponentInChildren<Modificacion>().staring_to = false; // reinica parametros del puntero
                Destroy(this.gameObject); // se destruira cuando se dejen de
                break;
          default:
                break;
        
        }
    }
    private IEnumerator tiempo_carga() { // funcion que espera unos segundos antes de usarse
        yield return new WaitForSeconds(recarga_portal);
        puede_usar = true;
    }

}
