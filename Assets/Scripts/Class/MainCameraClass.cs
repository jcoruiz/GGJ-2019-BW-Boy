using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraClass
{

    private int offset;
    private GameObject player;

    public int Offset
    {
        get
        {
            return offset;
        }

        set
        {
            offset = value;
        }
    }

    public GameObject Player
    {
        get
        {
            return player;
        }

        set
        {
            player = value;
        }
    }

    public MainCameraClass(int offset, GameObject player)
    {
        this.Offset = offset;
        this.Player = player;
    }

}
