using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    //Basics
    public string chara_name;
    public int characterLevel;


    //Required Attributes
    public int hitPoints;
    public int damage;
    public int defensePoint;
    public int manaPoints;
    public float criticalMultiplier;
    public float criticalChance;
    public float attackCooldown;
    public float passiveCooldown;
    public float ultimateCooldown;
    public Team team;
    
    protected bool isPlayer = false;

    //Other
    public bool isDead;

    //Timer
    private float normalAttackTimer = 0;

    public abstract void NormalAttack();
    public abstract void PassiveSkill();
    public abstract void UltimateSkill();
    
    public void SetLevel(int characterLevel)
    {
        this.characterLevel = characterLevel;
    }

    public void SetTeam(Team team)
    {
        this.team = team;
    }

    public void displayData()
    {
        Debug.Log(chara_name + ", HP: " + hitPoints);
    }

    public void setSidePlayer(bool side)
    {
        isPlayer = side;
    }

    public void TakeDamage(int damage)
    {
        hitPoints -= damage;
    }

    void Start()
    {

    }

    void Update()
    {
        if (GlobalTimer.getTime() - normalAttackTimer > attackCooldown)
        {
            normalAttackTimer = GlobalTimer.getTime();
            NormalAttack();
        }
    }
    //public abstract void mountItem(GameObject item,string type);


}
