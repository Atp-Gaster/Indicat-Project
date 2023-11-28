using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Canvas_Controller : MonoBehaviour
{
    [Header("Animation Settings")]
    public Animator OpenBannerAnimation;

    public Animator ToturialAnimation;
    [SerializeField] private int Display_Current = 0;
    [SerializeField] private int Display_MaxScene = 0;    
    private IEnumerator coroutine;
    [SerializeField] bool ToturialStart = false;
    [SerializeField] bool EnableStart = false;

    [Header("Interface Settings")]
    public TextMeshProUGUI [] currencies;
    public Slider[] StatusBar;
    public Slider[] Player1_Bar;
    public Slider[] Player2_Bar;
    public Slider[] Player3_Bar;
    public Slider[] Player4_Bar;
    public Slider[] Player5_Bar;
    [SerializeField] int updateSpeedSecond = 5;

    public int CountAttack = 0;
    public bool NextScene = false;

    public Button button;

    public bool ToggleButton = false;
    #region Animation

    //Cutseen Animation Trigger
        private IEnumerator PlayCutseen()
        {
            if (NextScene == false)
            {
                Debug.Log("Test2");
                //yield return new WaitForSeconds(3);
                //ToturialAnimation.SetInteger("State", 0);
                yield return new WaitForSeconds(9);
                ToturialAnimation.SetInteger("State", 1);


                yield return new WaitForSeconds(5);
                ToturialAnimation.SetInteger("State", 2);
                yield return new WaitForSeconds(10);
                ToturialAnimation.SetInteger("State", 3);
                yield return new WaitForSeconds(5);
                ToturialAnimation.SetInteger("State", 4);                
                button.interactable = true;
            }            

            if (NextScene == true) 
            {                
                yield return new WaitForSeconds(3);
                ToturialAnimation.SetInteger("State", 6);
                yield return new WaitForSeconds(4);
                ToturialAnimation.SetInteger("State", 7);
                yield return new WaitForSeconds(5);
                SceneManager.LoadScene(2);
                Debug.Log("Test3");
            }          
        }
        
        //Start Banner Lift up
        public void BannerLifeUp() //Use to start lift animation banner
        {
            OpenBannerAnimation.SetBool("Lift Up", true);
        }

    #endregion

    #region Interface

        public void SetMoneyText(int indicoin , int goldcoin ,int catral)
        {       
            this.currencies[0].text = indicoin.ToString();
            this.currencies[1].text = goldcoin.ToString();
            this.currencies[2].text = catral.ToString();
        }

        public void SetWidthBar(int CurrentXP, int CurrentHp)
        {       
            StatusBar[0].value = CurrentXP;
            StatusBar[1].value = CurrentHp;
        }

        public void SetMaxBar(int MaxXP, int MaxHp)
        {
            StatusBar[0].maxValue = MaxXP;
            StatusBar[1].maxValue = MaxHp;
        }     
    
        public void SetCharacterBar(int PlayerNumber,int HP, int MP)
        {
            switch(PlayerNumber)
            {
                case 1:
                    Player1_Bar[0].value = HP;
                    Player1_Bar[1].value = MP;
                    break;
                case 2:
                    Player2_Bar[0].value = HP;
                    Player2_Bar[1].value = MP;
                    break;
                case 3:
                    Player3_Bar[0].value = HP;
                    Player3_Bar[1].value = MP;
                    break;
                case 4:
                    Player4_Bar[0].value = HP;
                    Player4_Bar[1].value = MP;
                    break;
                case 5:
                    Player5_Bar[0].value = HP;
                    Player5_Bar[1].value = MP;
                    break;
            }
        }

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        SetMoneyText(99999, 99999, 99999);
        SetMaxBar(100, 500);
        SetWidthBar(10,500);
        /*
        SetCharacterBar(1, 100, 0);
        SetCharacterBar(2, 100, 0);
        SetCharacterBar(3, 100, 0);
        SetCharacterBar(4, 100, 0);
        SetCharacterBar(5, 100, 0);
        */
        //Debug.Log(Player5_Bar[1].value);


    }

    // Update is called once per frame
    void Update()
    {        
        if (OpenBannerAnimation.GetBool("Lift Up") == true && ToturialStart == false )
        {
            ToturialStart = true;
            Debug.Log("Test");
            ToturialAnimation.SetInteger("State", 0);
            if (EnableStart == true)
            {
                EnableStart = false;
                coroutine = PlayCutseen();
                StartCoroutine(coroutine);
                
            }
        }

        if (NextScene == true)
        {
            coroutine = PlayCutseen();
            StartCoroutine(coroutine);
        }

        if(ToggleButton) button.interactable = false;
    }
    //
}
