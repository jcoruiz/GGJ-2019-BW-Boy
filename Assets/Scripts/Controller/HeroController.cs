using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class HeroController : MonoBehaviour
{
    //Hero Class
    public HeroClass heroClass;

    //Variables de Movimiento
    private bool down;
    private bool up;
    private bool left;
    private bool rigth;
    private bool carryObject;

    //Componetes de Hero
    private Rigidbody2D thisRigidbody;
    private Animator thisAnimator;


    public Sprite sombra;
    public GameObject hud;


    private GameObject objeto_en_mano;

    private void Awake()
    {
        heroClass = new HeroClass(
            velocity: 5.0f,
            isHandFree: true);

        thisRigidbody = gameObject.GetComponent<Rigidbody2D>();
        thisAnimator = gameObject.GetComponent<Animator>();


    }


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //hud = GameObject.Find("Hud");


        if (Input.GetKeyUp(KeyCode.W))
        {
            thisAnimator.SetBool("down", false);
            thisAnimator.SetBool("up", false);
            thisAnimator.SetBool("left", false);
            thisAnimator.SetBool("right", false);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            thisAnimator.SetBool("down", false);
            thisAnimator.SetBool("up", false);
            thisAnimator.SetBool("left", false);
            thisAnimator.SetBool("right", false);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            thisAnimator.SetBool("down", false);
            thisAnimator.SetBool("up", false);
            thisAnimator.SetBool("left", false);
            thisAnimator.SetBool("right", false);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            thisAnimator.SetBool("down", false);
            thisAnimator.SetBool("up", false);
            thisAnimator.SetBool("left", false);
            thisAnimator.SetBool("right", false);
        }

        if (Input.GetKey(KeyCode.W))
        {
            thisRigidbody.AddForce(new Vector2(0, heroClass.velocity));
            thisAnimator.SetBool("down", false);
            thisAnimator.SetBool("up", true);
            thisAnimator.SetBool("left", false);
            thisAnimator.SetBool("right", false);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            thisRigidbody.AddForce(new Vector2(0, -heroClass.velocity));
            thisAnimator.SetBool("down", true);
            thisAnimator.SetBool("up", false);
            thisAnimator.SetBool("left", false);
            thisAnimator.SetBool("right", false);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            thisRigidbody.AddForce(new Vector2(-heroClass.velocity, 0));
            thisAnimator.SetBool("down", false);
            thisAnimator.SetBool("up", false);
            thisAnimator.SetBool("left", true);
            thisAnimator.SetBool("right", false);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            thisRigidbody.AddForce(new Vector2(heroClass.velocity, 0));
            thisAnimator.SetBool("down", false);
            thisAnimator.SetBool("up", false);
            thisAnimator.SetBool("left", false);
            thisAnimator.SetBool("right", true);
        }
        else
        {
            //
        }

        if (Input.GetKeyDown(KeyCode.L) && heroClass.isHandFree == false)
        {
            heroClass.isHandFree = true;
            objeto_en_mano.GetComponent<Collider>().enabled = true;
            //objeto_en_mano.GetComponent<Rigidbody>().AddForce(thisRigidbody.velocity - new Vector3(thisRigidbody.velocity.x / 4, 0, thisRigidbody.velocity.y / 4), ForceMode.VelocityChange);
            objeto_en_mano.transform.Find("sombra").gameObject.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            hud.SetActive(!hud.activeSelf);
        }



    }

    void FixedUpdate()
    {
        if (heroClass.isHandFree == false)
        {
            objeto_en_mano.transform.position = transform.position + new Vector3(0, 0, 3);
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
                    GameObject objetoInstanciado = Instantiate(script.Contenido[i], other.gameObject.transform.position + new Vector3(0, 5, -script.gameObject.transform.localScale.z / 2), new Quaternion(0, 0, 0, 0));

                    //objetoInstanciado.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -heroClass.velocity), ForceMode.VelocityChange);

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
            if (Input.GetKeyDown(KeyCode.K) && heroClass.isHandFree == true)
            {
                heroClass.isHandFree = false;
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
