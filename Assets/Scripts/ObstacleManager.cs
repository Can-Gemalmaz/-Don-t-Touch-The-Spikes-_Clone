using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] ManualList manualList;

    ObjectPool objectPool;

    private void Start()
    {
        objectPool = ObjectPool.instance;

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
        int[] changeForTurn =  manualList.GetArray<int>(ManualList.lists.roundInChange);
        int[] numberOfObs = manualList.GetArray<int>(ManualList.lists.numberOfObs);
        Transform[] obstaclesCopyArray = manualList.GetArray<Transform>(lists);
        for (int i = 0; i < changeForTurn.Length; i++)
        {
            if (turn >= changeForTurn[changeForTurn.Length - 1])
            {
                int[] randomNumbers = manualList.GetArray<int>(ManualList.lists.randomNumbers, numberOfObs[numberOfObs.Length - 1]);
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
