using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal : MonoBehaviour
{
    public Transform posicion_player;

    public void teleportar() => posicion_player.position = this.transform.position + new Vector3(0, 1, 0);
}
