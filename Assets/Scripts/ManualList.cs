
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class ManualList: MonoBehaviour
{
    [SerializeField] Transform[] rightObstaclesTransforms;
    [SerializeField] Transform[] leftObstaclesTransforms;
    [SerializeField] GameObject[] rightCandys;
    [SerializeField] GameObject[] leftCandys;
    [SerializeField] int[] obstacleNumbers;
    [SerializeField] int[] obstacleChangeInTurn;

    //private List<int> randomPlaces = new List<int>();
    private int[] randomPlaces;

    private void Awake()
    {
        randomPlaces = new int[rightObstaclesTransforms.Length];
    }
 

    public enum lists
    {
        rightObsTransform,
        leftObsTransform,
        rightCandyTransform,
        leftCandyTransform,
        roundInChange,
        numberOfObs,
        randomNumbers
    }


    public T[] GetArray<T>(lists typeOfList, int length = 0) 
    {
        switch (typeOfList) 
        {
            case lists.rightObsTransform:
                return (T[])(object)rightObstaclesTransforms;                 
            case lists.leftObsTransform:
                return (T[])(object)leftObstaclesTransforms;
            case lists.rightCandyTransform:
                return (T[])(object)rightCandys;
            case lists.leftCandyTransform:
                return (T[])(object)leftCandys;
            case lists.roundInChange:
                return (T[])(object)obstacleChangeInTurn;
            case lists.numberOfObs:
                return (T[])(object)obstacleNumbers;
            case lists.randomNumbers:
                RandomNumberGenerator(typeOfList,length);
                return (T[])(object)randomPlaces;
        }
        return null;
    }
    private void RandomNumberGenerator(lists lists,int length)
    {
        //randomizing the list with non repatitive numbers
        int counter = 0;

        randomPlaces = new int[length];
        int range = rightObstaclesTransforms.Length;
        while (counter < length)
        {
            int randomInt = UnityEngine.Random.Range(0, range);
            if (Array.IndexOf(randomPlaces,randomInt) < 0)
            {
                randomPlaces[counter] = randomInt;
                counter++;
            }
        }
    }
}
