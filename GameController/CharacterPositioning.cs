using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPositioning : MonoBehaviour
{
    public GameObject playerArea;
    public GameObject enemyArea;
    //0 - 4 = Player Side, 5 - 9 = Enemy Side
    public GameObject[] character_slot = new GameObject[10];

    //Actual Object Position
    private static GameObject[] player_side = new GameObject[5];
    private static GameObject[] enemy_side = new GameObject[5];

    public string[,] playerBuildData = { { "Sample", "1", "CATALOG" }, { "Sample", "1", "CATALOG" }, { "Sample", "1", "CATALOG" }, { "Sample", "1", "CATALOG" }, { "Sample", "1", "CATALOG" } };
    public string[,] enemyBuildData = { { "Sample", "1", "CATALOG" }, { "Sample", "1", "CATALOG" }, { "Sample", "1", "CATALOG" }, { "Sample", "1", "CATALOG" }, { "Sample", "1", "CATALOG" } };

    // Start is called before the first frame update
    void Start()
    {
        //Initiate Player
        for (int i = 0; i < 5; i++)
        {
            GameObject newChar = Instantiate(CharacterBuilder.buildChar(playerBuildData[i,0], playerBuildData[i, 1], playerBuildData[i, 2]), character_slot[i].transform.position, Quaternion.identity, playerArea.transform);
            newChar.transform.Rotate(0.0f, 180.0f, 0.0f, Space.Self);
            newChar.GetComponent<Character>().setSidePlayer(true);
            player_side[i] = newChar;
            Debug.Log("Created Character " + playerBuildData[i, 0]);
        }

        //Initiate Enemy
        for (int i = 0; i < 5; i++)
        {
            GameObject newChar = Instantiate(CharacterBuilder.buildChar(enemyBuildData[i, 0], enemyBuildData[i, 1], enemyBuildData[i, 2]), character_slot[i + 5].transform.position, Quaternion.identity, enemyArea.transform);
            newChar.GetComponent<Character>().setSidePlayer(false);
            enemy_side[i] = newChar;
            Debug.Log("Created Character " + enemyBuildData[i, 0]);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static GameObject GetPlayerPosition()
    {
        for (int i = 0; i < 5; i++)
        {
            if (!(player_side[i].GetComponent<Character>().isDead))
            {
                return player_side[i];
            }
        }

        return null;
    }

    public static GameObject GetEnemyPosition()
    {
        for (int i = 0; i < 5; i++)
        {
            if (!(enemy_side[i].GetComponent<Character>().isDead))
            {
                return enemy_side[i];
            }
        }

        return null;
    }

    public static GameObject GetPosition(bool isPlayer)
    {
        if (isPlayer)
        {
            return GetPlayerPosition();
        }
        
        return GetEnemyPosition();
    }
}
