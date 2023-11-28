using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainpageController : MonoBehaviour
{
    [Header("Animation Settings")]
    public Animator OpenBannerAnimation;

    //Start Banner Lift up
    public void BannerLifeUp() //Use to start lift animation banner
    {
        OpenBannerAnimation.SetBool("Lift Up", true);
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
