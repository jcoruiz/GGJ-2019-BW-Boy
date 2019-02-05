using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraController : MonoBehaviour
{
    public MainCameraClass mainCameraClass;

    private void Awake()
    {
        mainCameraClass = new MainCameraClass(65, GameObject.Find("Hero"));
    }

    void Update()
    {
        int offset = mainCameraClass.Offset;

        float playerX = mainCameraClass.Player.transform.position.x;
        float playerY = mainCameraClass.Player.transform.position.y;

        float thisZ = transform.position.z;

        float t = 0.2f;
        float space = 65f;

        float vectorX = Mathf.Floor((playerX + space/2) / space);
        float vectorY = Mathf.Floor((playerY + space / 2) / space);


        transform.position = Vector3.Lerp(transform.position, new Vector3(space * vectorX, space * vectorY, thisZ), t);

    }
}
