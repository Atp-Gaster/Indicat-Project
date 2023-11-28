using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Button[] PlayerTargetpos;
    public Button[] EnemyTarget;
    

    public void SelectPlayer(int PlayerPosition)
    {
        for (int i = 0; i < EnemyTarget.Length; ++i)
        {
            int EnemyPosition = i; // Keep this line, it's essential
            EnemyTarget[EnemyPosition].onClick.AddListener(() => SelectEnemy(PlayerPosition,EnemyPosition));
        }        
    }

    void SelectEnemy(int PlayerPosition, int EnemyPosition)
    {
        print("Now Player: " + PlayerPosition + " Select to Attacking on " + EnemyPosition);
        //Recived this data by create new function here

        //
        RemoveListeners();
    }

    public void RemoveListeners()
    {       
        // Remove the listeners from the buttons
        for (int i = 0; i < EnemyTarget.Length; ++i)
        {
            EnemyTarget[i].onClick.RemoveAllListeners();
        }
    }  

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < PlayerTargetpos.Length; ++i)
        {
            int buttonIndex = i; // Keep this line, it's essential
            PlayerTargetpos[buttonIndex].onClick.AddListener(() => SelectPlayer(buttonIndex));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
