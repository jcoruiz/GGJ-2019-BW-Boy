using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitController : MonoBehaviour
{
    public GameObject timer;
    //public GameObject hud;

    private void Awake()
    {
        Instantiate(timer);
        //Instantiate(hud);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
