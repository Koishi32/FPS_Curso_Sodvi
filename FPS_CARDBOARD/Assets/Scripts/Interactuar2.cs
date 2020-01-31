using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactuar2 : MonoBehaviour
{
    public Transform Size;
    public bool cambio = false;
    public void Incrementar_tamano() {
        if (!cambio)
        {
            cambio = true;
            Size.localScale = Size.localScale * 2;
        }
        else {
            cambio = false;
            Size.localScale = Size.localScale / 2;
        }
    }
}
