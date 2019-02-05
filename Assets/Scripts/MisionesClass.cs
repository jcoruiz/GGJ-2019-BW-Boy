using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisionesClass : MonoBehaviour {

    public GameObject contenedorObjetos;
    public List<Mision> misiones;

    public void Make () {
        misiones = new List<Mision>();

        Mision misionPlato = new Mision();
        misionPlato.nombre_mision = "Lavar los platos";
        
        List<GameObject> misionPlato_obj_buscar = new List<GameObject>();

        GameObject plato1 = contenedorObjetos.transform.Find("Plato1").gameObject;
        plato1.GetComponent<InteraccionObjetoPersonaje>().Nombre = "Plato";
        misionPlato_obj_buscar.Add(plato1);

        GameObject plato2 = contenedorObjetos.transform.Find("Plato1").gameObject;
        plato2.GetComponent<InteraccionObjetoPersonaje>().Nombre = "Plato";
        misionPlato_obj_buscar.Add(plato2);

        GameObject plato3 = contenedorObjetos.transform.Find("Plato1").gameObject;
        plato3.GetComponent<InteraccionObjetoPersonaje>().Nombre = "Plato";
        misionPlato_obj_buscar.Add(plato3);

        misionPlato.objetos_a_buscar = misionPlato_obj_buscar;

        misionPlato.lugar_destino = "Lavaplato";

        ////misionPlato.lugar_destino = ;
        misionPlato.se_destruye = true;
        misionPlato.esta_completada = false;
        misiones.Add(misionPlato);

        //print();

        /*
        Mision misionRopa = new Mision();
        misionRopa.nombre_mision = "Lavar la ropa";
        misionRopa.objetos_a_buscar = new List<GameObject>();

        List<GameObject> misionRopa_obj_buscar = new List<GameObject>();

        GameObject ropa1 = contenedorObjetos.transform.Find("Ropa1").gameObject;
        ropa1.GetComponent<InteraccionObjetoPersonaje>().Nombre = "Ropa";
        misionRopa_obj_buscar.Add(ropa1);

        GameObject ropa2 = contenedorObjetos.transform.Find("Ropa1").gameObject;
        ropa2.GetComponent<InteraccionObjetoPersonaje>().Nombre = "Ropa";
        misionRopa_obj_buscar.Add(ropa2);

        GameObject ropa3 = contenedorObjetos.transform.Find("Ropa1").gameObject;
        ropa3.GetComponent<InteraccionObjetoPersonaje>().Nombre = "Ropa";
        misionRopa_obj_buscar.Add(ropa3);

        misionPlato.lugar_destino = "Lavadora";

        misionRopa.se_destruye = true;
        misiones.Add(misionRopa);
        */
        /*
        Mision misionComidaPerro = new Mision();
        misionComidaPerro.nombre_mision = "Dar de comer al perro";
        misionComidaPerro.objetos_a_buscar = new List<GameObject>();
        ////misionPlato.lugar_destino = ;
        misionComidaPerro.se_destruye = true;
        misiones.Add(misionComidaPerro);


        Mision misionCacaPerro = new Mision();
        misionCacaPerro.nombre_mision = "Limpiar la caca del perro";
        misionCacaPerro.objetos_a_buscar = new List<GameObject>();
        ////misionPlato.lugar_destino = ;
        misionCacaPerro.se_destruye = true;
        misiones.Add(misionCacaPerro);


        Mision misionDescongelar = new Mision();
        misionDescongelar.nombre_mision = "Descongelar la carne";
        misionDescongelar.objetos_a_buscar = new List<GameObject>();
        ////misionPlato.lugar_destino = ;
        misionDescongelar.se_destruye = true;
        misiones.Add(misionDescongelar);


        Mision misionBarrer = new Mision();
        misionBarrer.nombre_mision = "Limpiar Suciedad";
        misionBarrer.objetos_a_buscar = new List<GameObject>();
        ////misionPlato.lugar_destino = ;
        misionBarrer.se_destruye = false;
        misiones.Add(misionBarrer);
        */
    }
	
}
