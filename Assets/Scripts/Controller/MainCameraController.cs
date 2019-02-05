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
        float playerZ = mainCameraClass.Player.transform.position.z;

        float thisY = transform.position.y;

        float t = 0.2f;
        float space = 65f;

        float vectorX = Mathf.Floor((playerX + space/2) / space);
        float vectorZ = Mathf.Floor((playerZ + space / 2) / space);


        transform.position = Vector3.Lerp(transform.position, new Vector3(space * vectorX, thisY, space * vectorZ), t);

    }
}
