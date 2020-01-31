using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Gaze_input : MonoBehaviour
{
    public Image Imagen_ojo;
    bool is_staring;
    public float limite;
    public RaycastHit rayo_info;

    public GameObject bala;
    public float velocidad_bala;
    public float duracion_bala;
    // Start is called before the first frame update
    void Start()
    {
        is_staring = false;
        Imagen_ojo.fillAmount = 0;
    }
    public void Mirando() {
        is_staring = true;
    }
    public void Deja_mirar() {
        is_staring = false;
        Imagen_ojo.fillAmount = 0;
    }
    // Update is called once per frame
    void Update()
    {
        salir();
        mirada();
        Disparo_manual();
    }
    public void Disparo_manual() {
        if (Input.GetButtonDown("Fire1")) {
            lanzar();
        }
    }
    void mirada() {
        if (is_staring)
        {
            Imagen_ojo.fillAmount += 1 / limite * Time.deltaTime; //LLena la imagen conforme al tiempo
            if (Imagen_ojo.fillAmount == 1)
            {
                ejecutar();  // Ejecuta una accion cuando la imagen esta completa
                Imagen_ojo.fillAmount = 0;
                is_staring = false;
            }
        }
    }
    public virtual void lanzar() {
        //rayo_info.collider.GetComponent<Accion_enemigo>().Accion_ene(); //Destruye Enemigo
        var clon = Instantiate(bala, Camera.main.transform.position, Camera.main.transform.rotation);
        clon.GetComponent<Rigidbody>().AddForce(clon.transform.forward * velocidad_bala);
        Destroy(clon.gameObject, duracion_bala);
    }
    public virtual void ejecutar() {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        if (Physics.Raycast(ray,out rayo_info,Mathf.Infinity)) {
            if (rayo_info.collider.tag == "Ene")
            {
                lanzar();
            }
            else if (rayo_info.collider.tag == "Tele") {
                rayo_info.collider.GetComponent<portal>().teleportar();
            }
        }
    }
    public void salir() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }
    }

}
