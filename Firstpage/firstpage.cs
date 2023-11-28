using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class firstpage : MonoBehaviour
{
    public bool NextScene = false;
    // Start is called before the first frame update
    void StartVideo ()
    {

        GameObject anim = GameObject.Find("Canvas");
        anim.GetComponent<Animator>().SetTrigger("Start");
        // Will attach a VideoPlayer to the main camera.
        GameObject camera = GameObject.Find("Video Player");
        var videoPlayer = camera.GetComponent<UnityEngine.Video.VideoPlayer>();
        videoPlayer.Play();
        anim.GetComponent<Animator>().SetTrigger("Start");

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(NextScene) SceneManager.LoadScene(1);
    }
}
