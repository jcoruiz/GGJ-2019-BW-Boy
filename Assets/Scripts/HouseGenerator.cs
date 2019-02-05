using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class HouseGenerator : MonoBehaviour
{
    public GameObject plane_test;
    public float espaciado = 5.5f;
    public float margen = 0.5f;
    //public int numeroGeneraciones = 7;
    public GameObject contenedorEstructuras;

    public List<RoomClass> rooms;


    public List<RoomClass> Make(int matriz)
    {
        int width = 65;

        rooms = new List<RoomClass>();

        for (int x = 0; x < matriz; x++)
        {

            for (int y = 0; y < matriz; y++)
            {
                GameObject room = Instantiate(getRandomRoom(), new Vector3( y * width, 0, x * -width), new Quaternion(0, 0, 0, 0));

                RoomClass roomObj = new RoomClass();
                roomObj.RoomObj = room;
                roomObj.Type = "";
                roomObj.Vecinos = new bool[] { (x != 0), (y < (matriz - 1)), (x < (matriz - 1)), (y != 0) }; //Arriba, Derecha, Abajo, Izquierda
                roomObj.Posicion = new Vector2(x, y);
                rooms.Add(roomObj);
            }
        }


        habilitarMuro(rooms);
        return rooms;
    }

    void LlenarMuebles() {

    }

    void habilitarMuro(List<RoomClass> rooms)
    {
        foreach (var room in rooms)
        {
            if(room.Posicion == new Vector2(0, 2))
            {
                //Debug.Log(room.Vecinos);
            }
            for (int i = 0; i < room.Vecinos.Length; i++) {
           
                if (room.Vecinos[i] == false) {
                    GameObject muro = room.RoomObj.transform.Find("wallpatapar_" + i).gameObject;
                    muro.SetActive(true);
                    //Debug.Log("entro");
                }
            }
        }
    }

    GameObject getRandomRoom()
    {
        GameObject response = new GameObject();
        int maxBano = 2;
        int maxCocina = 1;
        int maxPieza = 10;
        int maxLiving = 3;

        string[] tipo = new string[] { "Cocina", "Bano", "Pieza", "Living" };

        int randomTipo = Random.Range((int)0, (int)4);
        Debug.Log(randomTipo);

        if (tipo[randomTipo] == "Cocina")
        {
            int random = Random.Range(1, 4);
            Debug.Log(random);
            response = contenedorEstructuras.transform.Find("EstructuraCocina_" + random).gameObject;
        }
        if (tipo[randomTipo] == "Bano")
        {
            int random = Random.Range(1, 4);
            Debug.Log(random);
            response = contenedorEstructuras.transform.Find("EstructuraBano_" + random).gameObject;
        }
        if (tipo[randomTipo] == "Pieza")
        {
            int random = Random.Range(1, 1);
            Debug.Log(random);
            response = contenedorEstructuras.transform.Find("EstructuraPieza_" + random).gameObject;
        }

        if (tipo[randomTipo] == "Living")
        {
            int random = Random.Range(1, 1);
            Debug.Log(random);
            response = contenedorEstructuras.transform.Find("EstructuraLiving_" + random).gameObject;
        }

        //int random = Random.Range(1, 4); //Random.Rango con INT es exclusivo en el max, por lo que esto puede devolver [1,2,3];
        return response;
    }
}
