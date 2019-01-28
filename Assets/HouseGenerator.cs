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

    public List<room> rooms;


    public List<room> Make(int numeroGeneraciones)
    {

        Vector2 posicionInicial = new Vector2(3, 3);
        rooms = new List<room>();

        Vector3 derecha = new Vector3(espaciado + margen, 0, 0);
        Vector3 izquierda = new Vector3(-espaciado - margen, 0, 0);
        Vector3 arriba = new Vector3(0, 0, espaciado + margen);
        Vector3 abajo = new Vector3(0, 0, -espaciado - margen);

        
        GameObject pieza_derecha = Instantiate(getRandomRoom(), plane_test.transform.position + derecha, new Quaternion(0, 0, 0, 0));
        GameObject pieza_izquierda = Instantiate(getRandomRoom(), plane_test.transform.position + izquierda, new Quaternion(0, 0, 0, 0));
        GameObject pieza_arriba = Instantiate(getRandomRoom(), plane_test.transform.position + arriba, new Quaternion(0, 0, 0, 0));
        GameObject pieza_abajo = Instantiate(getRandomRoom(), plane_test.transform.position + abajo, new Quaternion(0, 0, 0, 0));

        room roomObj = new room();
        roomObj.RoomObj = pieza_derecha;
        roomObj.Type = "living d";
        roomObj.Vecinos = new int[] { 0, 0, 0, 1 };
        roomObj.Posicion = new Vector2(1, 0);
        rooms.Add(roomObj);

        room roomObj2 = new room();
        roomObj2.RoomObj = pieza_izquierda;
        roomObj2.Type = "bathroom i";
        roomObj2.Vecinos = new int[] { 0, 1, 0, 0 };
        roomObj2.Posicion = new Vector2(-1, 0);
        rooms.Add(roomObj2);

        room roomObj3 = new room();
        roomObj3.RoomObj = pieza_arriba;
        roomObj3.Type = "kitchen arr";
        roomObj3.Vecinos = new int[] { 0, 0, 1, 0 };
        roomObj3.Posicion = new Vector2(0, 1);
        rooms.Add(roomObj3);

        room roomObj4 = new room();
        roomObj4.RoomObj = pieza_abajo;
        roomObj4.Type = "dinneroom aba";
        roomObj4.Vecinos = new int[] { 1, 0, 0, 0 };
        roomObj4.Posicion = new Vector2(0, -1);
        rooms.Add(roomObj4);

        List<Vector3> posi = new List<Vector3>();
        posi.Add(new Vector3(espaciado*2 + margen*2, 0, 0)); //10, 0, 0
        posi.Add(new Vector3(espaciado + margen, 0, espaciado + margen)); //5, 0, 5
        posi.Add(new Vector3(0, 0, espaciado*2 + margen*2)); //0, 0, 10
        posi.Add(new Vector3(-espaciado - margen, 0, espaciado + margen)); //-5, 0, 5
        posi.Add(new Vector3(-espaciado*2 - margen*2, 0, 0)); //-10, 0, 0
        posi.Add(new Vector3(-espaciado - margen, 0, -espaciado - margen)); //-5, 0, -5
        posi.Add(new Vector3(0, 0, -espaciado*2 - margen*2)); //0, 0, -10
        posi.Add(new Vector3(espaciado + margen, 0, -espaciado - margen));  //5, 0, -5

        List<int> posicionesUsadas = new List<int>();
        
        for (int i = 0; i <= numeroGeneraciones; i++)
        {
            room roomObjI = new room();

            int posicion_ale = 0;
            bool isUsed = false;

            while (!isUsed)
            {
                posicion_ale = Random.Range(0, posi.Count);
                int cuenta = 0;
                foreach (var numero in posicionesUsadas)
                {
                    if (posicion_ale == numero)
                    {
                        cuenta++;
                    }
                }

                if (cuenta == 0) {
                    isUsed = true;
                }
            }
                

            posicionesUsadas.Add(posicion_ale);
            roomObjI.RoomObj = Instantiate(getRandomRoom(), (Vector3)posi[posicion_ale], new Quaternion(0, 0, 0, 0));
            roomObjI.Type = "random";

            if(posicion_ale == 0)
            {
                roomObjI.Vecinos = new int[] { 0, 0, 0, 1 };
                roomObjI.Posicion = new Vector2(2, 0);

                foreach (var room in rooms)
                {
                    if(room.Posicion == new Vector2(1, 0))
                    {
                        var roomVecino = room.Vecinos;
                        roomVecino[1] = 1;
                        room.Vecinos = roomVecino;
                    }
                }

            }
            if (posicion_ale == 1)
            {
                roomObjI.Vecinos = new int[] { 0, 0, 1, 1 };
                roomObjI.Posicion = new Vector2(1, 1);

                foreach (var room in rooms)
                {
                    if (room.Posicion == new Vector2(1, 0))
                    {
                        var roomVecino = room.Vecinos;
                        roomVecino[0] = 1;
                        room.Vecinos = roomVecino;
                    }
                    if (room.Posicion == new Vector2(0, 1))
                    {
                        var roomVecino = room.Vecinos;
                        roomVecino[1] = 1;
                        room.Vecinos = roomVecino;
                    }
                }
            }
            if (posicion_ale == 2)
            {
                roomObjI.Vecinos = new int[] { 0, 0, 1, 0 };
                roomObjI.Posicion = new Vector2(0, 2);

                foreach (var room in rooms)
                {
                    if (room.Posicion == new Vector2(0, 1))
                    {
                        var roomVecino = room.Vecinos;
                        roomVecino[0] = 1;
                        room.Vecinos = roomVecino;
                    }
                }
            }
            if (posicion_ale == 3)
            {
                roomObjI.Vecinos = new int[] { 0, 1, 1, 0 };
                roomObjI.Posicion = new Vector2(-1, 1);

                foreach (var room in rooms)
                {
                    if (room.Posicion == new Vector2(0, 1))
                    {
                        var roomVecino = room.Vecinos;
                        roomVecino[3] = 1;
                        room.Vecinos = roomVecino;
                    }
                    if (room.Posicion == new Vector2(-1, 0))
                    {
                        var roomVecino = room.Vecinos;
                        roomVecino[0] = 1;
                        room.Vecinos = roomVecino;
                    }
                }
            }
            if (posicion_ale == 4)
            {
                roomObjI.Vecinos = new int[] { 0, 1, 0, 0 };
                roomObjI.Posicion = new Vector2(-2, 0);

                foreach (var room in rooms)
                {
                    if (room.Posicion == new Vector2(-1, 0))
                    {
                        var roomVecino = room.Vecinos;
                        roomVecino[3] = 1;
                        room.Vecinos = roomVecino;
                    }
                }
            }
            if (posicion_ale == 5)
            {
                roomObjI.Vecinos = new int[] { 1, 1, 0, 0 };
                roomObjI.Posicion = new Vector2(-1, -1);

                foreach (var room in rooms)
                {
                    if (room.Posicion == new Vector2(-1, 0))
                    {
                        var roomVecino = room.Vecinos;
                        roomVecino[2] = 1;
                        room.Vecinos = roomVecino;
                    }
                    if (room.Posicion == new Vector2(0, -1))
                    {
                        var roomVecino = room.Vecinos;
                        roomVecino[3] = 1;
                        room.Vecinos = roomVecino;
                    }
                }
            }
            if (posicion_ale == 6)
            {
                roomObjI.Vecinos = new int[] { 1, 0, 0, 0 };
                roomObjI.Posicion = new Vector2(0, -2);

                foreach (var room in rooms)
                {
                    if (room.Posicion == new Vector2(0, -1))
                    {
                        var roomVecino = room.Vecinos;
                        roomVecino[2] = 1;
                        room.Vecinos = roomVecino;
                    }
                }
            }
            if (posicion_ale == 7)
            {
                roomObjI.Vecinos = new int[] { 1, 0, 0, 1 };
                roomObjI.Posicion = new Vector2(1, -1);

                foreach (var room in rooms)
                {
                    if (room.Posicion == new Vector2(0, -1))
                    {
                        var roomVecino = room.Vecinos;
                        roomVecino[1] = 1;
                        room.Vecinos = roomVecino;
                    }
                    if (room.Posicion == new Vector2(1, 0))
                    {
                        var roomVecino = room.Vecinos;
                        roomVecino[2] = 1;
                        room.Vecinos = roomVecino;
                    }
                }
            }

            rooms.Add(roomObjI);

        }
     
        habilitarMuro(rooms);
        return rooms;
        //var objTest = rooms.Where(t => t.Posicion == new Vector2(1,0)).FirstOrDefault();
        //Debug.Log(objTest.Type);
        //
    }

	void Update () {

	}

    void LlenarMuebles() {

    }

    void habilitarMuro(List<room> rooms)
    {
        foreach (var room in rooms)
        {
            if(room.Posicion == new Vector2(0, 2))
            {
                //Debug.Log(room.Vecinos);
            }
            for (int i = 0; i < room.Vecinos.Length; i++) {
           
                if (room.Vecinos[i] == 0) {
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
