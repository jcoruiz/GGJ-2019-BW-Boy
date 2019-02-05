using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mision : MonoBehaviour
{
    public string nombre_mision;
    public List<GameObject> objetos_a_buscar;
    //public List<GameObject> lugar_destino;
    public string lugar_destino;
    public bool se_destruye; // 0 no(pala) 1 si
    public int progreso;
    public bool esta_completada;

    private void Start()
    {
        nombre_mision = "";
        objetos_a_buscar = new List<GameObject>();
        //lugar_destino = new List<GameObject>();
        lugar_destino = "";
        se_destruye = true;
        progreso = 0;
        esta_completada = false;
    }
}
