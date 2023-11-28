using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLogo : MonoBehaviour
{
    public Animator animator;

    public void ExitTrigger()
    {
        animator.SetBool("Exit", true);
    }
    void Start()
    {
        animator.SetBool("Loop button", true);
    }
}
