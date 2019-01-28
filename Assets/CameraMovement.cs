using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public float velocidad = 5.0f;
    public int offset = 65; 
    public GameObject player;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (player.transform.position.x > -offset/2 && player.transform.position.x < offset/2) {
            transform.position = Vector3.Lerp(transform.position, new Vector3(0, transform.position.y, transform.position.z), 0.2f);
        }
        if (player.transform.position.z > -offset/2 && player.transform.position.z < offset/2)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y, 0), 0.2f);
        }

        // derecha
        if (player.transform.position.x > offset/2 && player.transform.position.x < offset + offset/2) {
            transform.position = Vector3.Lerp(transform.position, new Vector3(offset, transform.position.y, transform.position.z),0.2f);
        }
        if (player.transform.position.x > offset + offset / 2 && player.transform.position.x < offset*2)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(offset*2, transform.position.y, transform.position.z), 0.2f);
        }

        // izquierda
        if (player.transform.position.x < -offset/2 && player.transform.position.x > -offset -offset/2)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(-offset, transform.position.y, transform.position.z), 0.2f);
        }
        if (player.transform.position.x < -offset - offset / 2 && player.transform.position.x > -offset*2)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(-offset*2, transform.position.y, transform.position.z), 0.2f);
        }


        //arriba
        if (player.transform.position.z > offset/2 && player.transform.position.z < offset + offset/2)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y, offset), 0.2f);
        }
        if (player.transform.position.z > offset + offset/2 && player.transform.position.z < offset*2)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y, offset*2), 0.2f);
        }

        //abajo
        if (player.transform.position.z < -offset/2 && player.transform.position.z > -offset - offset/2)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y, -offset), 0.2f);
        }
        if (player.transform.position.z < -offset - offset/2 && player.transform.position.z > -offset*2)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y, -offset * 2), 0.2f);
        }
        
    }

    private void FixedUpdate()
    {

    }
}
