using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteraccionObjetoPersonaje : MonoBehaviour
{

    public bool EstaTomado;// = false;
    public string Nombre;
    //public GameObject Contenido;// = new GameObject();

    void Start()
    {

        EstaTomado = false;
        //Contenido = new GameObject();
    }

    private void OnTriggerEnter(Collider other)
    {
        bool se_utilizo_objeto = false;
        List<Mision> misiones = GameObject.Find("MisionesClass").GetComponent<MisionesClass>().misiones;

        foreach (Mision mision in misiones)
        {
            if (mision.esta_completada == false && mision.lugar_destino == other.gameObject.name)
            {
                foreach (GameObject item in mision.objetos_a_buscar)
                {

                    if (item.GetComponent<InteraccionObjetoPersonaje>().Nombre == this.Nombre && se_utilizo_objeto == false)
                    {
                        mision.progreso++;
                        se_utilizo_objeto = true;
                        gameObject.SetActive(false);
                        if (GameObject.Find("Hero").GetComponent<HeroClass>().isHandFree == false)
                        {
                            GameObject.Find("Hero").GetComponent<HeroClass>().isHandFree = true;
                        }

                    }

                }

                if (mision.progreso == mision.objetos_a_buscar.Count)
                {

                    mision.esta_completada = true;
                }
            }

        }

        if (se_utilizo_objeto)
        {

            //desactivar el objeto en vez de destruirlo;
            // que objeto??



        }
    }
}
