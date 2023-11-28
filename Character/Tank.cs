using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : Character
{
    public override void NormalAttack()
    {
        GameObject target = CharacterPositioning.GetPosition(isPlayer);
        target.GetComponent<Character>().TakeDamage(damage);
        Debug.Log("Attack Performed");
    }

    public override void PassiveSkill()
    {

    }

    public override void UltimateSkill()
    {

    }
}
