using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomepageController : MonoBehaviour
{
    [Header("Animation Settings")]

    public Animator OpenBannerAnimation;
    public Animator animator;

    [SerializeField] bool EnableStartCutseen = false;
    [SerializeField] bool BannerDown = false;
    [SerializeField] bool Prepvideo = false; // Down Agian after Click Gacha Button in home menu

    [SerializeField] GameObject VideoPlayer;

    private IEnumerator coroutine;

    [SerializeField] bool TriggerVideoScene = false;

    public Button button;

    

    //GameObject camera = GameObject.Find("Main Camera");
    //var videoPlayer = camera.AddComponent<UnityEngine.Video.VideoPlayer>();


    //Start Banner Lift up
    public void BannerLifeUp() //Use to start lift animation banner
    {
        OpenBannerAnimation.SetBool("Lift Up", true);
        if (!Prepvideo) EnableStartCutseen = true;     
    }

    public void BannerLifeDown() 
    {
        OpenBannerAnimation.SetBool("Lift Up", false);
        Prepvideo = true;

        coroutine = PlayCutseen();
        StartCoroutine(coroutine);

    }

    public void TriggerVideo()
    {
        // Will attach a VideoPlayer to the main camera.
        GameObject camera = GameObject.Find("Video player setting");
        camera.SetActive(true);
        var videoPlayer = camera.GetComponent<UnityEngine.Video.VideoPlayer>();
        videoPlayer.Play();
        
    }

    private IEnumerator PlayCutseen()
    {
        EnableStartCutseen = false;
        if (!Prepvideo)
        {            
            yield return new WaitForSeconds(4);
            animator.SetInteger("State", 1);
            yield return new WaitForSeconds(3);
            animator.SetInteger("State", 2);
            yield return new WaitForSeconds(3);              
            //button.interactable = true;
        }
        
        if(Prepvideo)
        {
            //yield return new WaitForSeconds(3);
            //BannerLifeUp();
            yield return new WaitForSeconds(3);
            animator.SetInteger("State", 3);
            TriggerVideo();
        }
           
    }

    // Start is called before the first frame update
    void Start()
    {
        BannerLifeUp();
    }

    // Update is called once per frame
    void Update()
    {
        if(EnableStartCutseen)
        {
            coroutine = PlayCutseen();
            StartCoroutine(coroutine);
        }

        if(BannerDown) OpenBannerAnimation.SetBool("Lift Up", false);
        //if(!BannerDown) OpenBannerAnimation.SetBool("Lift Up", true);
    }
}
