using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class SistemaGeneral : MonoBehaviour {

    public List<Mision> misionesSeleccionadas;
    
    // Use this for initialization
    void Start () {
        //Carga Video
        //Carga Escena
        //Transicion
        //Musica

        //Generar Nivel


        int cantidadMisiones = 1;
        int cantidadHabitacionesExtras = 7;

        //Crear Misiones
        GameObject.Find("MisionesClass").GetComponent<MisionesClass>().Make();

        //Selecciona Misiones
        misionesSeleccionadas = SeleccionarMisiones(cantidadMisiones);

        //Generar Habitaciones a partir de sistema general
       

        StartCoroutine(test2(cantidadHabitacionesExtras, cantidadMisiones, misionesSeleccionadas));

        List<room> habitacionesCreadas = GameObject.Find("Sistema Generacion").GetComponent<HouseGenerator>().rooms;
	}
	
	// Update is called once per frame
	void Update () {
      
    }

    List<Mision> SeleccionarMisiones(int cantidadMisiones)
    {
        List<Mision> misiones = GameObject.Find("MisionesClass").GetComponent<MisionesClass>().misiones;
        
        List<Mision> misionesSeleccionadas = new List<Mision>();

        for (int i = 0; i < cantidadMisiones; i++)
        {
            int random = 0;
            bool estaSeleccionada = true;

            while (estaSeleccionada)
            {
                random = Random.Range((int)0, (int)misiones.Count);
              
                estaSeleccionada = false;
                foreach (var mision in misionesSeleccionadas)
                {
                    if (mision.nombre_mision == misiones[random].nombre_mision)
                    {
                        estaSeleccionada = true;
                    }
                }
            }
           
            misionesSeleccionadas.Add(misiones[random]);
        }

        return misionesSeleccionadas;
    }

    public void PonerObjetos(List<room> habitacionesCreadas,int cantidadMisiones, List<Mision> misionesSeleccionadas)
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
            
                room habitacionSeleccionada = habitacionesCreadas[random];

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

    public IEnumerator test2(int cantidadHabitacionesExtras, int cantidadMisiones, List<Mision> misionesSeleccionadas)
    {
        
        List<room> habitacionesCreadas = GameObject.Find("Sistema Generacion").GetComponent<HouseGenerator>().Make(cantidadHabitacionesExtras);
        yield return new WaitForSeconds(5);
        PonerObjetos(habitacionesCreadas, cantidadMisiones, misionesSeleccionadas);

    }
    

    
}
