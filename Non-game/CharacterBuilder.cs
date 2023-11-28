using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBuilder : MonoBehaviour
{
    public static GameObject buildChar(string charName, string charLevel, string charTeam)
    {
        if (charName == "Sample")
        {
            GameObject result = Resources.Load("Prefabs/SampleCharacter") as GameObject;

            //Need Transforming Functions
            result.GetComponent<Tank>().SetLevel(1);

            //Need Transforming Functions
            result.GetComponent<Tank>().SetTeam(Team.CATALOG);

            return result;
        }

        return null;
    }
}
