using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class room
{

    public GameObject RoomObj = new GameObject();

    public string Type = "";

    public Vector2 Posicion = new Vector2(0, 0);

    /**
     * {arriba, derecha, abajo, izquierda}
     * */
    public int[] Vecinos = new int[] { };
}

