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
            Debug.Log("RightCandysByName: " + rightCandys[i].name);
        }

    }
    private void Update()
    {


        /*GameObject candy = rightCandyTransforms[0];
        Debug.Log(candy.name);
        Debug.Log("RightCandys[0]: " + rightCandys[0]);
        rightCandys[0] = candy;
        Debug.Log("rightCandys: " + rightCandys[0].name);*/


    }

    public void SpawnRightCandy()
    {

        //GameObject[] rightCandys = manualList.GetArray<GameObject>(ManualList.lists.rightCandyTransform);
        /*if (rightCandys == null)
        {
            Debug.Log("Tell me why");
        }
        for (int i = 0; i < rightCandys.Count; i++)
        {
            Debug.Log("Candys" + i + " name: " + rightCandys[i].name);
        }
        activeRightCandy = rightCandys[Random.Range(0, rightCandys.Count)];
        if (activeRightCandy == null)
        {
            Debug.Log("ActiveeightCandy is null");
        }
        activeRightCandy.SetActive(true);*/
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
