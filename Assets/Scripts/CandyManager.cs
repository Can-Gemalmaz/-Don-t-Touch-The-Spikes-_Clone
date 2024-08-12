using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyManager : MonoBehaviour
{
    [SerializeField] ManualList manualList;

    GameObject activeRightCandy;
    GameObject activeLeftCandy;

    int candyCount;

    public void SpawnRightCandy()
    {
        GameObject[] rightCandys = manualList.GetArray<GameObject>(ManualList.lists.rightCandyTransform);
        activeRightCandy = rightCandys[Random.Range(0,rightCandys.Length)];
        activeRightCandy.SetActive(true);
    }

    public void SpawnLeftCandy() 
    {
        GameObject[] leftCandys = manualList.GetArray<GameObject>(ManualList.lists.leftCandyTransform);
        activeLeftCandy = leftCandys[Random.Range(0, leftCandys.Length)];
        activeLeftCandy.SetActive(true);
    }

    public void DeSpawnCandy(GameObject candy) 
    {
        if (candy) 
        {
            candy.SetActive(false);
        }
        activeLeftCandy?.SetActive(false);
        activeRightCandy?.SetActive(false);
    }


    public void SetCandyCount(int candyIncrease)
    { 
        candyCount += candyIncrease; 
    }

    public int GetCandyCount()
    { 
        return candyCount; 
    }
}
