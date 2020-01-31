using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accion_enemigo : MonoBehaviour
{
    public float damage;
    public float life;
    public ParticleSystem efecto_muerte;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Proyectil") {
            Destroy(collision.gameObject);
            life -= damage;
            if (life <= 0) {
                Instantiate(efecto_muerte, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
        }
    }
}
