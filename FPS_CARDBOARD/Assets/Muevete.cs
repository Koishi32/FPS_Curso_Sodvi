using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muevete : MonoBehaviour
{
    public Transform camera_mine;
    public Rigidbody rigido;
   // public float gravedad;
    public float velocidad;
    // Start is called before the first frame update
    void Start()
    {
        camera_mine = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
        rigido = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
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
        else {
            rigido.velocity = Vector3.zero;
        }

   

    }
}
