using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactuar : MonoBehaviour
{
    public float vel_rot;
    bool rueda;
    Color Original_color;
    public virtual void Start(){
        rueda = false;
        Original_color = gameObject.GetComponent<Renderer>().material.color; // guarda color original
    }
    // Update is called once per frame
    void Update()
    {
        if (rueda) {
            this.transform.Rotate(new Vector3(0, vel_rot * Time.deltaTime,0)); // gira conforme al tiempo
        }
    }
    public void me_mira() {
        if (!rueda)
        {
            rueda = true;
            gameObject.GetComponent<Renderer>().material.color = Color.blue; // en select cambia color a azul
        }
        else {
            rueda = false;
            gameObject.GetComponent<Renderer>().material.color = Original_color; // regresa a color original
        }
    }
    
}
