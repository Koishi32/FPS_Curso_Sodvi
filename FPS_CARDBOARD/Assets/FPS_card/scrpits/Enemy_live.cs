using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_live : MonoBehaviour
{
    public float mylife;
    public float damage_taken;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "proyectil") // si colisiona con el proyectil, lo destruira y reducira su vida
        {
           
            Destroy(collision.gameObject);
            mylife -= damage_taken;
            if (mylife <=0) {
                Destroy(this.gameObject);
            }
        }
    }
}
