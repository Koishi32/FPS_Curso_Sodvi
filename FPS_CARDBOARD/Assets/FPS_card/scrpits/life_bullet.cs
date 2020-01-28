using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class life_bullet : MonoBehaviour
{
    public float duration_ball;
    public float fuerza;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * fuerza, ForceMode.Impulse);
        Destroy(this.gameObject, duration_ball);
    }

   
}
