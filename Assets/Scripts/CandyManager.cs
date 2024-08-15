using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyManager : MonoBehaviour
{
    [SerializeField] ManualList manualList;
    [SerializeField] GameObject[] rightCandyTransforms;
    [SerializeField] GameObject[] leftCandyTransforms;


    GameObject activeRightCandy;
    GameObject activeLeftCandy;

    MyList<GameObject> leftCandys;
    MyList<GameObject> rightCandys;

    int candyCount;

    float timer = 5f;

    private void Awake()
    {


    }

    private void Start()
    {
        rightCandys = new MyList<GameObject>(rightCandyTransforms.Length);
        for (int i = 0; i < rightCandyTransforms.Length; i++)
        {
            //GameObject candyBig = rightCandyTransforms[i];
            rightCandys.Add(rightCandyTransforms[i]);
        }

        leftCandys = new MyList<GameObject> (leftCandyTransforms.Length);
        for (int i = 0; i < leftCandyTransforms.Length; i++)
        {
            leftCandys.Add(leftCandyTransforms[i]);
        }
        SpawnRightCandy();

    }


    public void SpawnRightCandy()
    {
        activeRightCandy = rightCandys[Random.Range(0,rightCandys.Count)];

        activeRightCandy.SetActive(true);
    }

    public void SpawnLeftCandy() 
    {
        activeLeftCandy = leftCandys[Random.Range(0, leftCandys.Count)];
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
