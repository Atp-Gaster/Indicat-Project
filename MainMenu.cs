using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public bool StartCutseen = false;
    [SerializeField] private int Display_Current = 0;
    [SerializeField] private int Display_MaxScene = 0;
    [SerializeField] private Animation[] Cutseen;    
    private IEnumerator coroutine;

    //public GameObject Mainmenu;
    

    private IEnumerator PlayCutseen()
    {       
        for (int i = 0; i < Display_MaxScene; i++)
        {            
            print("Test Enum");
            Display_Current++;
            Cutseen[i].Play();
            if(i != Display_MaxScene - 1)
            {
                yield return new WaitForSeconds(3);
            }                  
        }
        SceneManager.LoadScene(1);
    }

    public void Begin_CutSeen()
    {
        StartCutseen = true;
        //Mainmenu.GetComponent<Animation>().Play();
    }      

    // Update is called once per frame
    void Update()
    {
        if(StartCutseen)
        {
            Begin_CutSeen();
            coroutine = PlayCutseen();
            StartCoroutine(coroutine);
            StartCutseen = false;
        }
    }
}
