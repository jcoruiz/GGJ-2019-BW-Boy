using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerController : MonoBehaviour {

    private Text thisText;

    private float nextActionTime = 0.0f;
    private float period = 1.0f;
    private int segundos = 30;

    private float initialTime;

    private void Awake()
    {
        thisText = GetComponent<Text>();

    }

    private void Start()
    {
        thisText.text = segundos.ToString();
        initialTime = Time.time;
    }

    // Update is called once per frame
    void Update () {

        if ( (Time.time - initialTime) > nextActionTime)
        {
            nextActionTime += period;
            // execute block of code here
            segundos--;
            thisText.text = segundos.ToString();

        }

        if (segundos <= 0) {
            SceneManager.LoadScene("scene outro");
        }

    }


}
