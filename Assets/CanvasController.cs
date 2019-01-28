using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour {

    private List<Mision> Misiones;
    private string Texto;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Texto = "\n";

        Misiones = GameObject.Find("SistemaGeneral").GetComponent<SistemaGeneral>().misionesSeleccionadas;

        foreach (Mision mision in Misiones)
        {
            if (mision.esta_completada == false)
            {
                Texto += mision.nombre_mision + " \n";
            }
        }

        this.gameObject.GetComponent<Text>().text = Texto;

        //texto_obj
    }
}
