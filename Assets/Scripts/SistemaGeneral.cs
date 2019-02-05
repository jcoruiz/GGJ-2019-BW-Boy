using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Video;

public class SistemaGeneral : MonoBehaviour {

    public List<Mision> misionesSeleccionadas;

    private int matriz;
    private int cantidadMisiones;



    // Use this for initialization
    void Start () {
        //Carga Video
        //Carga Escena
        //Transicion
        //Musica

        //Generar Nivel


        cantidadMisiones = 2;

        matriz = 2;

        //Crear Misiones
        GameObject.Find("MisionesClass").GetComponent<MisionesClass>().Make();

        //Selecciona Misiones
        misionesSeleccionadas = SeleccionarMisiones();

        //Generar Habitaciones a partir de sistema general
       

        StartCoroutine(test2());

        //List<RoomClass> habitacionesCreadas = GameObject.Find("HouseGenerator").GetComponent<HouseGenerator>().rooms;
	}
	


    List<Mision> SeleccionarMisiones()
    {
        List<Mision> misionesMaster = GameObject.Find("MisionesClass").GetComponent<MisionesClass>().misiones;

        List<Mision> misiones = misionesMaster.OrderBy(x => System.Guid.NewGuid()).Take(cantidadMisiones).ToList();

        return misiones;
    }

    public void PonerObjetos(List<RoomClass> habitacionesCreadas,int cantidadMisiones, List<Mision> misionesSeleccionadas)
    {
        foreach (Mision mision in misionesSeleccionadas)
        {
            //Debug.Log(mision.nombre_mision);
            List<GameObject> objetos_a_colocar = mision.objetos_a_buscar;

            //Debug.Log("Objetos a colocar:"+objetos_a_colocar.Count);

            foreach (GameObject objeto in objetos_a_colocar)
            {
            
                //Tengo un plato

                int random = Random.Range((int)0, (int)habitacionesCreadas.Count - 1);
            
                RoomClass habitacionSeleccionada = habitacionesCreadas[random];

                List<Transform> lista_muebles_disponibles = new List<Transform>();

                foreach (Transform child in habitacionSeleccionada.RoomObj.transform)
                {
                    if (child.tag == "interactive_obj")
                        lista_muebles_disponibles.Add(child);
                }

                int random2 = Random.Range((int)0, (int)lista_muebles_disponibles.Count - 1);
              
                GameObject mueble_seleccionado = lista_muebles_disponibles[random2].gameObject;

                //Instantiate(objeto, mueble_seleccionado.transform.position + new Vector3(0, 5, 0), new Quaternion(0, 0, 0, 0));

                mueble_seleccionado.GetComponent<InteractiveObjectClass>().Contenido.Add(objeto);
            

                //print("mueble:" + mueble_seleccionado.GetComponent<InteractiveObjectClass>().Contenido[0]);
            }


        }
    }

    public IEnumerator test2()
    {
        
        List<RoomClass> habitacionesCreadas = GameObject.Find("HouseGenerator").GetComponent<HouseGenerator>().Make(matriz);
        yield return new WaitForSeconds(5);
        PonerObjetos(habitacionesCreadas, cantidadMisiones, misionesSeleccionadas);

    }
    

    
}
