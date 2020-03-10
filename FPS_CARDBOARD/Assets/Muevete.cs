using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muevete : MonoBehaviour
{
    public Transform camera_mine;
    public Rigidbody rigido;
   // public float gravedad;
    public float velocidad;
    GvrPointerPhysicsRaycaster rayo;
    public GameObject particulon;
    public GameObject particulon2;
    [SerializeField]
    float velocidad_bala;
    [SerializeField]
    float offset;
    [SerializeField]
    float time_bullet;
    // Start is called before the first frame update
    void Start()
    {
        camera_mine = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
        rigido = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        movement();
        checa_fire();
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }
    }
    void movement() {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        var dir = camera_mine.forward.normalized;
        if ((hor + ver) != 0)
        {
            Vector3 vel = new Vector3(hor, 0, ver) * velocidad;
            Vector3 targetDirection = Camera.main.transform.TransformDirection(vel);
            //vel = vel.Normalize();
            rigido.velocity = targetDirection;
        }
        else
        {
            rigido.velocity = Vector3.zero;
        }
    }
    void checa_fire() {
        if (Input.GetButtonDown("Fire1"))
        {
            dispara();
        }
        else if (Input.GetButtonDown("Fire2") || Input.GetButtonDown("Fire3"))
        {
            Vector3 dir_camara = Camera.main.transform.forward.normalized * offset;
            var clon = Instantiate(particulon2, Camera.main.transform.position + dir_camara, Camera.main.transform.rotation);
            clon.GetComponent<Rigidbody>().AddForce(clon.transform.forward * velocidad_bala);
            Destroy(clon.gameObject, time_bullet);
        }
    }
    void dispara() {
        /*Vector3 dir_camara = Camera.main.transform.forward.normalized;
        var clon = Instantiate(particulon, Camera.main.transform.position + dir_camara, Camera.main.transform.rotation);
        Destroy(clon.gameObject, 6);*/
        if (GvrPointerInputModule.CurrentRaycastResult.gameObject != null) {


            Vector3 Localizacion_impacto = GvrPointerInputModule.CurrentRaycastResult.gameObject.transform.position;
            var referencia = GameObject.Instantiate(particulon, Localizacion_impacto, Quaternion.identity);
            Destroy(referencia.gameObject, 6);
        }
    }
           
    }
   