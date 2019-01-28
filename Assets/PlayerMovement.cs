using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

    public float velocidad = 5.0f;
    public Rigidbody player_rb;
    public bool tiene_manos_libres = true;
    public Sprite sombra;
    public GameObject hud;
    public Canvas cv;

    public bool down;
    public bool up;
    public bool left;
    public bool rigth;
    public bool carryObject;

    private GameObject objeto_en_mano;
    public Animator animator;

    void Start () {
		
	}

    // Update is called once per frame
    void Update() {
       

        if (Input.GetKeyUp(KeyCode.W)) {
            animator.SetBool("down", false);
            animator.SetBool("up", false);
            animator.SetBool("left", false);
            animator.SetBool("right", false);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            animator.SetBool("down", false);
            animator.SetBool("up", false);
            animator.SetBool("left", false);
            animator.SetBool("right", false);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            animator.SetBool("down", false);
            animator.SetBool("up", false);
            animator.SetBool("left", false);
            animator.SetBool("right", false);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("down", false);
            animator.SetBool("up", false);
            animator.SetBool("left", false);
            animator.SetBool("right", false);
        }

        if (Input.GetKey(KeyCode.W))
        {
            player_rb.AddForce(new Vector3(0, 0, velocidad), ForceMode.VelocityChange);
            animator.SetBool("down", false);
            animator.SetBool("up", true);
            animator.SetBool("left", false);
            animator.SetBool("right", false);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            player_rb.AddForce(new Vector3(0, 0, -velocidad), ForceMode.VelocityChange);
            animator.SetBool("down", true);
            animator.SetBool("up", false);
            animator.SetBool("left", false);
            animator.SetBool("right", false);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            player_rb.AddForce(new Vector3(-velocidad, 0, 0), ForceMode.VelocityChange);
            animator.SetBool("down", false);
            animator.SetBool("up", false);
            animator.SetBool("left", true);
            animator.SetBool("right", false);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            player_rb.AddForce(new Vector3(velocidad, 0, 0), ForceMode.VelocityChange);
            animator.SetBool("down", false);
            animator.SetBool("up", false);
            animator.SetBool("left", false);
            animator.SetBool("right", true);
        }
        else {
            //
        }

        if(Input.GetKeyDown(KeyCode.L) && tiene_manos_libres == false)
        {
            tiene_manos_libres = true;
            objeto_en_mano.GetComponent<Collider>().enabled = true;
            objeto_en_mano.GetComponent<Rigidbody>().AddForce(player_rb.velocity - new Vector3(player_rb.velocity.x/4, 0, player_rb.velocity.z/4), ForceMode.VelocityChange);
            objeto_en_mano.transform.Find("sombra").gameObject.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            hud.GetComponent<SpriteRenderer>().enabled = !hud.GetComponent<SpriteRenderer>().enabled;
            cv.GetComponent<Text>().enabled = !cv.GetComponent<Text>().enabled;
        }



    }

    void FixedUpdate()
    {
        if(tiene_manos_libres == false)
        {
            objeto_en_mano.transform.position = transform.position + new Vector3(0,0,3);
            objeto_en_mano.transform.Find("sombra").gameObject.SetActive(false);
        }

        //sombra.gameObject.transform.position = transform.position + new Vector3(0, 0, -2);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "interactive_obj")
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                InteractiveObjectClass script = other.gameObject.GetComponent<InteractiveObjectClass>();
                script.State = (!script.State);

                for (int i = 0; i < script.Contenido.Count; i++)
                {
                   // Debug.Log("Se quiere crear instancia con nombre: " + script.Contenido[i].GetComponent<InteraccionObjetoPersonaje>().Nombre);
                    GameObject objetoInstanciado = Instantiate(script.Contenido[i], other.gameObject.transform.position + new Vector3(0, 5, -script.gameObject.transform.localScale.z/2),new Quaternion(0, 0, 0, 0));

                    objetoInstanciado.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -velocidad), ForceMode.VelocityChange);

                    objetoInstanciado.GetComponent<InteraccionObjetoPersonaje>().Nombre = script.Contenido[i].GetComponent<InteraccionObjetoPersonaje>().Nombre;

                   // Debug.Log("Se creo instancia con nombre: " + objetoInstanciado.GetComponent<InteraccionObjetoPersonaje>().Nombre);
                    
                }

                script.Contenido = new List<GameObject>();


                //Debug.Log(script.State);
                //Destroy(other.gameObject);
            }
        }

        if (other.tag == "tomable")
        {
            if (Input.GetKeyDown(KeyCode.K) && tiene_manos_libres == true)
            {
                tiene_manos_libres = false;
                InteraccionObjetoPersonaje script = other.gameObject.GetComponent<InteraccionObjetoPersonaje>();
                script.EstaTomado = true;

                other.gameObject.GetComponent<Collider>().enabled = false;
                GameObject objetoTomado = script.gameObject;
                objeto_en_mano = objetoTomado;

                //foreach (GameObject elemento in script.Contenido)
                //{
                //    Instantiate(elemento, other.gameObject.transform.position + new Vector3(0, 14, 0), new Quaternion(0, 0, 0, 0));
                //    Debug.Log("aparecio" + elemento.transform.position.x);
                //}

                //Debug.Log(script.EstaTomado);
                //Destroy(other.gameObject);
            }
        }
    }
}
