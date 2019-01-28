using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObjectClass : MonoBehaviour
{
    public bool State;
    public List<GameObject> Contenido;//

    void Start()
    {
        //Debug.Log("Entre a sobreescribir los datos :D");
        State = false;
        Contenido = new List<GameObject>();
    }

}
