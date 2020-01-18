using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu_manager : MonoBehaviour
{
    public void empieza() => SceneManager.LoadScene(1); 
    
       
    public void salir() =>  Application.Quit();  //  Especificar el numero que le corresponde a la escena de nivel en Build settings
           
    
}
