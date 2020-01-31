using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plano_Mov : Interactuar
{
    public Movimiento Control_jugador;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start(); // start del padre se ejecuta
        Control_jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<Movimiento>();
    }
    public void Activar_movimiento() {

        if (!Control_jugador.puede_mover)
        {
            Control_jugador.puede_mover = true;
        }
        else
        {
            Control_jugador.puede_mover = false;
        }
    }
    

}
