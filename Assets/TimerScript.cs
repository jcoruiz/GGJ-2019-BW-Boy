using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour {

    public Text cosa;

    private float nextActionTime = 0.0f;
    public float period = 1.0f;
    private int segundos = 138;

    private void Start()
    {
        cosa.text = segundos.ToString();
    }
    // Update is called once per frame
    void Update () {

        if (Time.time > nextActionTime)
        {
            nextActionTime += period;
            // execute block of code here
            segundos--;
            cosa.text = segundos.ToString();

        }

        if (segundos <= 0) {
            SceneManager.LoadScene("scene outro");
            segundos = 160;
        }

    }


}
