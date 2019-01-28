using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class SceneOutroController : MonoBehaviour {

    public List<Mision> misionesSeleccionadas;
    public VideoPlayer Intro_Movie;
    public AudioSource audioIntro;

    public double time;
    public double currentTime;

    // Use this for initialization
    void Start () {
        Intro_Movie.Play();
    }

    IEnumerator waitForMovieEnd()
    {

        while (Intro_Movie.isPlaying) // while the movie is playing
        {
            yield return new WaitForEndOfFrame();
        }
        // after movie is not playing / has stopped.
        onMovieEnded();
    }

    void onMovieEnded()
    {
        Debug.Log("Movie Ended!");
        SceneManager.LoadScene("scene test");
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
            {
            SceneManager.LoadScene("scene intro");
        }
    }
    
    

    
}
