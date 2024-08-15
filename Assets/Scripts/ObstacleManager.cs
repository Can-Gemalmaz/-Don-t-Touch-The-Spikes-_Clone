using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] ManualList manualList;

    ObjectPool objectPool;
    MyList<int> changeForTurn;
    MyList<int> numberOfObs;

    private void Start()
    {
        objectPool = ObjectPool.instance;

        changeForTurn = new MyList<int>(manualList.GetArray<int>(ManualList.lists.roundInChange).Length);
        numberOfObs = new MyList<int>(manualList.GetArray<int>(ManualList.lists.numberOfObs).Length);

        for (int i = 0; i < manualList.GetArray<int>(ManualList.lists.numberOfObs).Length; i++)
        {
            changeForTurn.Add(manualList.GetArray<int>(ManualList.lists.roundInChange)[i]);
            numberOfObs.Add(manualList.GetArray<int>(ManualList.lists.numberOfObs)[i]);
        }

        SpawnRightObstacles(0);
    }

    public void SpawnRightObstacles(int turn)
    {
        SpawnObstacles(ManualList.lists.rightObsTransform, turn);
    }

    public void SpawnLeftObstacles(int turn)
    {
        SpawnObstacles(ManualList.lists.leftObsTransform, turn);
    }

    private void SpawnObstacles(ManualList.lists lists, int turn)
    {

        //int[] changeForTurn =  manualList.GetArray<int>(ManualList.lists.roundInChange);
        //int[] numberOfObs = manualList.GetArray<int>(ManualList.lists.numberOfObs);
        //Transform[] obstaclesCopyArray = manualList.GetArray<Transform>(lists);
        MyList<Transform> obstaclesCopyArray = new MyList<Transform>(manualList.GetArray<Transform>(lists).Length);
        for (int i = 0; i < manualList.GetArray<Transform>(lists).Length; i++)
        {
            obstaclesCopyArray.Add(manualList.GetArray<Transform>(lists)[i]);
        }
        for (int i = 0; i < changeForTurn.Count; i++)
        {
            if (turn >= changeForTurn[changeForTurn.Count - 1])
            {
                int[] randomNumbers = manualList.GetArray<int>(ManualList.lists.randomNumbers, numberOfObs[numberOfObs.Count - 1]);
                for (int j = 0; j < randomNumbers.Length; j++)
                {
                    GameObject triangleObstacle = ObjectPool.instance.GetPooledObject();
                    triangleObstacle.transform.rotation = obstaclesCopyArray[randomNumbers[j]].rotation;
                    triangleObstacle.transform.position = obstaclesCopyArray[randomNumbers[j]].position;
                    triangleObstacle.SetActive(true);
                    
                }
                return;
            }
            else if (turn >= changeForTurn[i] && turn < changeForTurn[i + 1])
            {
                int[] randomNumbers = manualList.GetArray<int>(ManualList.lists.randomNumbers, numberOfObs[i]);
                for(int j = 0; j < randomNumbers.Length; j++)
                {
                    GameObject triangleObstacle = objectPool.GetPooledObject();
                    triangleObstacle.transform.rotation = manualList.GetArray<Transform>(lists)[randomNumbers[j]].rotation;
                    triangleObstacle.transform.position = manualList.GetArray<Transform>(lists)[randomNumbers[j]].position;
                    triangleObstacle.SetActive(true);
     
                    
                }
                return;
            }
        }
    }

    public void DeActiveAllObs()
    {
        ObjectPool.instance.DeActiveAllObstacles();
    }



}
