using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Lerp : MonoBehaviour
{
    public bool ReadyToFire;
    public Transform movePoint;
    public Transform[] TargetPos;
    public float moveSpeed;

    public Animator BulletAnimation;    

    public Transform OriginalPosition; //Position that Bullet will come out

    private IEnumerator coroutine;
    public UnityEngine.UI.Image image;

    public Vector2 ScaleBulletSize;
    
    public int SetMaxTypeBullet = 0;
    [SerializeField] int Type_Bullet = 0;    
    [SerializeField] bool RandomBullet = false;

    public void Set_Bullet_Type(int BulletType) //Use to Random Image of bullet
    {        
        switch(BulletType)
        {
            case 1:
                BulletAnimation.SetInteger("BulletType", 1);
                break;
            case 2:
                BulletAnimation.SetInteger("BulletType", 2);
                break;
            case 3:
                BulletAnimation.SetInteger("BulletType", 3);
                break;
        }        
    }  

    private IEnumerator DelaySetposition()
    {
        //print("Test IE");        
        yield return new WaitForSeconds(0.5f);
        //print("Test IE 2");             
        BulletAnimation.SetBool("Fire", false);
        BulletAnimation.SetBool("Hit", false);
        //transform.position = new Vector3(OriginalPosition.position.x, OriginalPosition.position.y, OriginalPosition.position.z);
        ReadyToFire = false;

        //GameObject clone = Instantiate(Bullet);        
        //Vector3 newPosition = new Vector3(OriginalPosition.position.x, OriginalPosition.position.y, OriginalPosition.position.z);
        //clone.transform.localPosition = newPosition;

        Destroy(gameObject);
    }


    private IEnumerator DelayFire()
    {
        Set_Bullet_Type(Type_Bullet);
        yield return new WaitForSeconds(0.5f);

        //image = GetComponent<UnityEngine.UI.Image>(); // Set image UI setting
        //Color c = image.color; // Set Alpha color
        //c.a = 255;
        //image.color = c; // Set Alpha color

        Vector3 Movepoint = new Vector3(movePoint.position.x + 30, movePoint.position.y, movePoint.position.z); //A little bit closer to target (-130 to -80 )
        transform.position = Vector3.Lerp(transform.position, movePoint.position, Time.deltaTime); // Start Leap to target
        transform.position = Vector3.Lerp(transform.position, Movepoint, moveSpeed * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("test");
        if (other.tag == "Enemy")
        {            
            print("FFF");
            BulletAnimation.SetBool("Hit", true);            
            coroutine = DelaySetposition();
            StartCoroutine(coroutine);                                                               
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //ScaleBulletSize = this.transform.lossyScale;
    }

    // Update is called once per frame
    void Update()
    {       
        if(ReadyToFire)
        {            
            BulletAnimation.SetBool("Fire", true);            
            ReadyToFire = false;
            if(RandomBullet) Type_Bullet = Random.Range(1, SetMaxTypeBullet + 1); // Using for Random the bullet;
        }
        if (BulletAnimation.GetBool("Fire") == true)
        {
            coroutine = DelayFire();
            StartCoroutine(coroutine);
        }                         
    }
}
