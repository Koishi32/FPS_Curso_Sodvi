using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoVolador : Seleccion
{
    public Character_move personaje;
    
    public override void Start()
    {
        base.Start(); /// hace el start del objeto del que hereda
        personaje = GameObject.Find("Personaje").GetComponent<Character_move>();
    }
    // Start is called before the first frame update
    public void click_temporizador() {
        personaje.Empieza_volar();
        StartCoroutine("contador");
    }
    IEnumerator contador() {
        
       yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
    }
    
}
