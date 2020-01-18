using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class life_bullet : MonoBehaviour
{
    public float duration_ball;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, duration_ball);
    }

   
}
