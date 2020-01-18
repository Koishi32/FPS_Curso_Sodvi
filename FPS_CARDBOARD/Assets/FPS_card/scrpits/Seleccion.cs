using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seleccion : MonoBehaviour
{
    public float rot_vel;
    bool turnsAround;
    Color original_color; // Para cambiar el color
    public virtual void Start() // permite que se sobreescriba el objeto
    {
        original_color = gameObject.GetComponent<Renderer>().material.color;
        turnsAround = false;
    }

   public void select_rot() { //cambiaa color y deja girar
        if (!turnsAround)
        {
            turnsAround = true;
            gameObject.GetComponent<Renderer>().material.color = Color.blue;
        }
        else {
            turnsAround = false;
            gameObject.GetComponent<Renderer>().material.color = original_color;
        }
    }

    private void Update() // para que siga girando
    {
        if(turnsAround)
        this.transform.Rotate(new Vector3(0, rot_vel * Time.deltaTime, 0), Space.Self);
    }
}
