using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoVolador : Seleccion
{
    public Character_move personaje;
    
    public override void Start() // override en el start para que haga mas cosas en el inicio
    {
        base.Start(); /// hace el start del objeto del que hereda
        personaje = GameObject.FindGameObjectWithTag("Player").GetComponent<Character_move>();
    }
    // Start is called before the first frame update
    public void click_temporizador() {
        personaje.Empieza_volar();
        StartCoroutine("contador");
    }
    IEnumerator contador() { // Destruye este objeto para que ya no pueda usarlo otra vez
        
       yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
    }
    
}
