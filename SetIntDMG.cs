using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class SetIntDMG : MonoBehaviour
{
    public int DmgInput = 0;
    public TextMeshProUGUI textDisplay; 
    public bool Original = false;
    public bool Float = false;
    public Animation Clip;


    // Start is called before the first frame update
    void Start()
    {
        //Vector3 movePoint = new Vector3(transform.position.x, transform.position.y + 50, transform.position.z);
        //Vector3 movePoint = new Vector3(GameObject.Find("Enemy Asset").transform.position.x, GameObject.Find("Enemy Asset").transform.position.y + 50, 0);
    }

    // Update is called once per frame
    void Update()
    {
        textDisplay.text = DmgInput.ToString();
      
        //transform.position = Vector3.Lerp(transform.position, movePoint, 5 * Time.deltaTime);

        if(!Original) Destroy(gameObject, 2);
        if (Float) Clip.Play("FloatDMG");
    }
}
