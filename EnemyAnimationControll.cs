using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyAnimationControll : MonoBehaviour
{
    public Animator EnemyAnimator;
    public SetIntDMG DMGText;
    public GameObject Test;    
    Vector3 movePoint;
    public bool test;
    private IEnumerator coroutine;
    int RoundDMGFixed = 0;
    bool enable = true;
    void IsDamaged(int Damage_Input)
    {
        
       // RoundDMGFixed += 1;
       // if (RoundDMGFixed >= 5)
        //{
          //  enable = false;
          //  coroutine = CDDMG();
          //  StartCoroutine(coroutine);
       // }

        if (enable)
        {
            EnemyAnimator.SetTrigger("Hit");
            GameObject Clone = Instantiate(Test, transform.position, Quaternion.identity, GameObject.FindGameObjectWithTag("Canvas").transform);
            Clone.GetComponent<SetIntDMG>().DmgInput = Damage_Input;
            Clone.GetComponent<SetIntDMG>().Original = false;
            Clone.GetComponent<SetIntDMG>().Float = true;
        }
        
        
    }

    private IEnumerator CDDMG()
    {        
        yield return new WaitForSeconds(4);
        RoundDMGFixed = 0;
        enable = true;

    }

    public void SetTestDMG(bool Input)
    {
        test = Input;
    }

    // Start is called before the first frame update
    void Start()
    {
        //IsDamaged(100);
    }

    // Update is called once per frame
    void Update()
    {
        //For Demo 
        if (test)
        {
            int A = Random.Range(1000, 3000);
            IsDamaged(A);
            test = false;
        }
    }
}
