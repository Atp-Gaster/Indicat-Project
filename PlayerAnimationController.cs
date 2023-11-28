using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    //position Setting
    [Header("Position Setting")]
    public int Character_Type = 0;//Select type of Character behavious
    public int ThisPosition = 0;// Set Character position
    public bool IsPlayer = false; // Set team of character

    public Transform[] PlayerPos; //character position checkpoint
    public Transform[] EnemyPos; //character position checkpoint

    //public UnityEngine.UI.Image image; // Set this.picture???

    [Header("Target & Projectile Setting")]
    public bool ReadyToFire;
    public Transform movePoint;

    public GameObject[] BulletObj;
    public GameObject BulletNormal;
    public GameObject BulletPassive;

    [Header("Setting")]
    //This Obeject property
    Animator Anim;
    public GameObject gameObject;
    public int MoveSpeed = 0;

    //public GameObject SupportBulletPrefab;    

    public Canvas_Controller Canvas_Controller;

    private IEnumerator coroutine;

    public bool EnabelLoopDEMO = false;
    public EnemyAnimationControll EnemyAnim;

    public float attackCooldown;
    private float normalAttackTimer = 0;
    private float PassiveAttackTimer = 0;

    bool AlreadyWalk = false;

    bool PassiveATK = false;

  
    void SetupPosition()
    {
        if(IsPlayer)
        {
            switch (ThisPosition)
            {
                case 0:
                    transform.position = new Vector3(PlayerPos[0].position.x, PlayerPos[0].position.y, PlayerPos[0].position.z);
                    break;
                case 1:
                    transform.position = new Vector3(PlayerPos[1].position.x, PlayerPos[1].position.y, PlayerPos[1].position.z);
                    break;
                case 2:
                    transform.position = new Vector3(PlayerPos[2].position.x, PlayerPos[2].position.y, PlayerPos[2].position.z);
                    break;
                case 3:
                    transform.position = new Vector3(PlayerPos[3].position.x, PlayerPos[3].position.y, PlayerPos[3].position.z);
                    break;
                case 4:
                    transform.position = new Vector3(PlayerPos[4].position.x, PlayerPos[4].position.y, PlayerPos[4].position.z);
                    break;
            }
        }
        else if(!IsPlayer)
        {
            switch (ThisPosition)
            {
                case 0:
                    transform.position = new Vector3(EnemyPos[0].position.x, EnemyPos[0].position.y, EnemyPos[0].position.z);
                    break;
                /*   Use after Demo
                case 1:
                    transform.position = new Vector3(EnemyPos[1].position.x, EnemyPos[1].position.y, EnemyPos[1].position.z);
                    break;
                case 2:
                    transform.position = new Vector3(EnemyPos[2].position.x, EnemyPos[2].position.y, EnemyPos[2].position.z);
                    break;
                case 3:
                    transform.position = new Vector3(EnemyPos[3].position.x, EnemyPos[3].position.y, EnemyPos[3].position.z);
                    break;
                case 4:
                    transform.position = new Vector3(EnemyPos[4].position.x, EnemyPos[4].position.y, EnemyPos[4].position.z);
                    break;
                */
            }
        }
    }

    //For Close-Combat Role
    void MoveToTarget(int TargetPos)
    {
        switch (TargetPos)
        {
            case 0:
                movePoint.position = new Vector3(EnemyPos[0].position.x - 130, EnemyPos[0].position.y, EnemyPos[0].position.z); //Move waypoint(movePoint) // -130 for make it stop in front of target
                break;
                /*   Use after Demo
                case 1:
                    transform.position = new Vector3(EnemyPos[1].position.x, EnemyPos[1].position.y, EnemyPos[1].position.z);
                    break;
                case 2:
                    transform.position = new Vector3(EnemyPos[2].position.x, EnemyPos[2].position.y, EnemyPos[2].position.z);
                    break;
                case 3:
                    transform.position = new Vector3(EnemyPos[3].position.x, EnemyPos[3].position.y, EnemyPos[3].position.z);
                    break;
                case 4:
                    transform.position = new Vector3(EnemyPos[4].position.x, EnemyPos[4].position.y, EnemyPos[4].position.z);
                    break;
                */
        }                                            
    }

    private IEnumerator Attacking_Anim(int Attacking)
    {
        if(Character_Type == 1)//Close Combat
        {
            if(Attacking == 0)//Normal Attack
            {
                Anim.SetBool("Attacking", true);
                Anim.SetInteger("AttackType", Attacking);
                yield return new WaitForSeconds(0.1f);
                Anim.SetBool("Attacking", false);
                EnemyAnim.SetTestDMG(true);
                yield return new WaitForSeconds(0.1f);
                EnemyAnim.SetTestDMG(false);
            }
            if (Attacking == 1)//Passive Attack
            {
                Anim.SetBool("Attacking", true);
                Anim.SetInteger("AttackType", Attacking);
                yield return new WaitForSeconds(0.1f);
                Anim.SetBool("Attacking", false);
                EnemyAnim.SetTestDMG(true);
                yield return new WaitForSeconds(0.1f);
                EnemyAnim.SetTestDMG(false);
            }
        }
        if (Character_Type == 2)//Range Combat
        {
            switch (Attacking)
            {
                case 0://Basic
                    yield return new WaitForSeconds(0.48f); // Wait for animation to playing Attacking Animation // Maybe it still depend on each character animation?
                    Anim.SetInteger("State", 1); // Set It State 

                    GameObject cloneBullet = Instantiate(BulletObj[0]) as GameObject; // Recreate the Bullet and select each type of bullet to Display


                    cloneBullet.transform.parent = GameObject.Find("Image Player 1").transform; //Make the new bullet to childe (For Demo)
                    cloneBullet.transform.position = BulletObj[0].transform.position; //Bring the local position of the orignaal bullet
                    cloneBullet.transform.localScale = new Vector2(BulletObj[0].GetComponent<Bullet_Lerp>().ScaleBulletSize.x, BulletObj[0].GetComponent<Bullet_Lerp>().ScaleBulletSize.y); //Change the scale of the game object 
                    cloneBullet.GetComponent<Bullet_Lerp>().ReadyToFire = true;// Activate the bullert lerb script

                    //Set the Bullet Alpha property 
                    UnityEngine.UI.Image image;
                    image = cloneBullet.GetComponent<UnityEngine.UI.Image>(); // Set image UI setting
                    Color c = image.color; // Set Alpha color
                    c.a = 255;
                    image.color = c; // Set Alpha color

                    yield return new WaitForSeconds(3.0f);
                    Anim.SetInteger("State", 0);
                    EnemyAnim.SetTestDMG(true);
                    yield return new WaitForSeconds(0.1f);
                    EnemyAnim.SetTestDMG(false);
                    break;
                case 1://Passive / Second
                    yield return new WaitForSeconds(0.48f); // Wait for animation to playing Attacking Animation // Maybe it still depend on each character animation?
                    Anim.SetInteger("State", 1); // Set It State 

                    GameObject cloneBullet2 = Instantiate(BulletObj[1]) as GameObject; // Recreate the Bullet and select each type of bullet to Display


                    cloneBullet2.transform.parent = GameObject.Find("Image Player 1").transform; //Make the new bullet to childe
                    cloneBullet2.transform.position = BulletObj[1].transform.position; //Bring the local position of the orignaal bullet
                    
                    cloneBullet2.transform.localScale = new Vector2(BulletObj[1].GetComponent<Bullet_Lerp>().ScaleBulletSize.x, BulletObj[1].GetComponent<Bullet_Lerp>().ScaleBulletSize.y); //Change the scale of the game object 
                    cloneBullet2.GetComponent<Bullet_Lerp>().ReadyToFire = true;// Activate the bullert lerb script

                    //Set the Bullet Alpha property 
                    UnityEngine.UI.Image image2;
                    image = cloneBullet2.GetComponent<UnityEngine.UI.Image>(); // Set image UI setting
                    Color c2 = image.color; // Set Alpha color
                    c.a = 255;
                    image.color = c2; // Set Alpha color

                    Anim.SetInteger("State", 2);
                    yield return new WaitForSeconds(3.0f);
                    Anim.SetInteger("State", 0);
                    EnemyAnim.SetTestDMG(true);
                    yield return new WaitForSeconds(0.1f);
                    EnemyAnim.SetTestDMG(false);
                    break;
                case 2://Ultimate
                    Anim.SetInteger("State", 3);
                    yield return new WaitForSeconds(3.0f);
                    Anim.SetInteger("State", 0);
                    EnemyAnim.SetTestDMG(true);
                    yield return new WaitForSeconds(0.1f);
                    EnemyAnim.SetTestDMG(false);
                    break;
            }           
        }
        if(Character_Type == 3)//Support
            switch (Attacking)
            {
                case 99://Healing
                    Anim.SetInteger("State", 99);
                    yield return new WaitForSeconds(1.2f);
                    Anim.SetInteger("State", 0);
                    break;
                case 1://Basic
                    yield return new WaitForSeconds(0.48f); // Wait for animation to playing Attacking Animation // Maybe it still depend on each character animation?
                    Anim.SetInteger("State", 1); // Set It State 

                    GameObject cloneBullet = Instantiate(BulletObj[0]) as GameObject; // Recreate the Bullet and select each type of bullet to Display


                    cloneBullet.transform.parent = GameObject.Find("Image Player 3").transform; //Make the new bullet to childe (For Demo)
                    cloneBullet.transform.position = BulletObj[0].transform.position; //Bring the local position of the orignaal bullet
                    cloneBullet.transform.localScale = new Vector2(BulletObj[0].GetComponent<Bullet_Lerp>().ScaleBulletSize.x, BulletObj[0].GetComponent<Bullet_Lerp>().ScaleBulletSize.y); //Change the scale of the game object 
                    cloneBullet.GetComponent<Bullet_Lerp>().ReadyToFire = true;// Activate the bullert lerb script

                    //Set the Bullet Alpha property 
                    UnityEngine.UI.Image image;
                    image = cloneBullet.GetComponent<UnityEngine.UI.Image>(); // Set image UI setting
                    Color c = image.color; // Set Alpha color
                    c.a = 255;
                    image.color = c; // Set Alpha color

                    yield return new WaitForSeconds(3.0f);
                    Anim.SetInteger("State", 0);
                    EnemyAnim.SetTestDMG(true);
                    yield return new WaitForSeconds(0.1f);
                    EnemyAnim.SetTestDMG(false);
                    break;               
            }        
        
    }
    //public void Attacking(int Attacktype)
    public void Attacking(int Attacktype)
    {
        //int Attacktype = 1;//For Demo
        coroutine = Attacking_Anim(Attacktype);
        StartCoroutine(coroutine);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            ReadyToFire = false;
            AlreadyWalk = true;
            //Debug.Log("Hit!");
            ReadyToFire = false; 
            Anim.SetBool("Walking", false);
            //For Testing
            coroutine = Attacking_Anim(0);
            StartCoroutine(coroutine);
        }        
    }
    bool OneTimeUseForDEMO = true;
    public void UseUltimate()
    {        
        if (Character_Type == 2 && OneTimeUseForDEMO)
        {
            print("Using Ultimate");
            OneTimeUseForDEMO = false;
            Attacking(2);
            Canvas_Controller.NextScene = true;
            Canvas_Controller.ToggleButton = true;
        }            
    }


    // Start is called before the first frame update
    void Start()
    {
        Anim = this.GetComponent<Animator>(); //Set up Anim        
        gameObject.SetActive(false);
        //Set up stage
        SetupPosition();

        MoveToTarget(0);//For Testing

        //Invoke("Attacking", 2);
        //For Testing        
    }

    ///Used for Demo Only
    void ReadytoFireTG()
    {
        int Count = 0;
        ReadyToFire = true;      
    }

    void ReadytoFireTGPassive()
    {
        int Count = 0;
        PassiveATK = true;
    }

    // Update is called once per frame
    void Update()
    {
        Animator CutSeenAnim = GameObject.Find("Background").GetComponent<Animator>();
        if(CutSeenAnim.GetInteger("State") >= 1 && EnabelLoopDEMO && CutSeenAnim.GetInteger("State") != 3)
        {
            print(GlobalTimer.getTime());
            GlobalTimer.playTimer();
            if (GlobalTimer.getTime() - normalAttackTimer > attackCooldown)
            {
                normalAttackTimer = GlobalTimer.getTime();
                ReadytoFireTG();
                //Debug.Log("==================Attacking=======================");
            }
            if (GlobalTimer.getTime() - PassiveAttackTimer > attackCooldown * 2 - Random.Range(-3,3)) // Added Radom.range For fun
            {
                PassiveAttackTimer = GlobalTimer.getTime();
                ReadytoFireTGPassive();
                //Debug.Log("================== Passive Attacking=======================");
            }
        }  
        else
        {
            GlobalTimer.pauseTimer();
        }

        if (ReadyToFire && !PassiveATK)// Use for test only
        {
            if(Character_Type == 1)
            {                
                transform.position = Vector3.Lerp(transform.position, movePoint.position, MoveSpeed * Time.deltaTime);
                Anim.SetBool("Walking", true);
                if(AlreadyWalk)
                {
                    Attacking(0);
                    ReadyToFire = false;
                }                              
            }
            if (Character_Type == 2)
            {
                Attacking(0);
                ReadyToFire = false;
            }
            if (Character_Type == 3)
            {
                Attacking(1);
                ReadyToFire = false;
            }            
        }

        if (PassiveATK)// Use for test only
        {
            if (Character_Type == 1)
            {
                transform.position = Vector3.Lerp(transform.position, movePoint.position, MoveSpeed * Time.deltaTime);
                Anim.SetBool("Walking", true);
                if (AlreadyWalk)
                {
                    Attacking(1);
                    PassiveATK = false;
                }
            }
            if (Character_Type == 2)
            {
                Attacking(1);
                PassiveATK = false;
            }
            if (Character_Type == 3)
            {
                Attacking(99);
                ReadyToFire = false;
            }
        }
    }
}
