using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalTimer : MonoBehaviour
{
    private static float global = 0;
    private static bool isPause = true;
    
    private static float debug = 0;

    // Start is called before the first frame update
    void Start()
    {
        global = 0;
        isPause = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPause)
        {
            global += Time.deltaTime;

            debug += Time.deltaTime;
        }

        if (debug >= 5)
        {
            Debug.Log("Time: " + global);

            debug -= 5;
        }
    }

    public static float getTime()
    {
        return global;
    }

    public static void pauseTimer()
    {
        isPause = true;
    }

    public static void playTimer()
    {
        isPause = false;
    }

    public static void resetTimer()
    {
        global = 0;
    }
}
