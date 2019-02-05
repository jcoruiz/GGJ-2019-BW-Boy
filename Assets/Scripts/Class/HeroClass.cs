using UnityEngine;

public class HeroClass {


    /*
    public float velocidad = 5.0f;
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

    private Rigidbody thisRigidbody;

    */

    public float velocity { get; set; }
    public bool isHandFree { get; set; }

    public HeroClass(float velocity, bool isHandFree)
    {
        this.velocity = velocity;
        this.isHandFree = isHandFree;       
    }
}
