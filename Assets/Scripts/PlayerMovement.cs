using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public event Action<int, int> OnPlayerDead;

    [SerializeField] float velocity = 2f;
    [SerializeField] float jumpForce = 2f;
    [SerializeField] LayerMask obstacle;
    [SerializeField] ObstacleManager obstacleManager;
    CandyManager candyManager;

    Rigidbody2D playerRigidBody;
    BoxCollider2D boxCollider2D;

    Vector2 linearVelocity;
    int turns = 0;

    private void Awake()
    {
        if(obstacleManager == null)
        {
            obstacleManager = GameObject.FindWithTag("ObstacleManager").GetComponent<ObstacleManager>();
            Debug.Log("couldnt find obstacle Manager");
        }
        candyManager = obstacleManager.GetComponent<CandyManager>();

    }

    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();

        boxCollider2D = GetComponent<BoxCollider2D>();

        linearVelocity = new Vector2(velocity, 0);
        playerRigidBody.AddForce(linearVelocity);
        
        
        //obstacleManager.SpawnRightObstacles(0);
        candyManager.SpawnRightCandy();
    }


    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Mouse0)) 
        {
            Vector2 jumpDirection = new Vector2(0, jumpForce);
            playerRigidBody.AddForce(jumpDirection);
        }
        
    }




    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Obstacle")
        {
            //Player is dead
            OnPlayerDead?.Invoke(turns, candyManager.GetCandyCount());
            obstacleManager.DeActiveAllObs();
            candyManager.DeSpawnCandy(null);
            gameObject.SetActive(false);
            turns = 0;

        }
        if (collision.gameObject.tag == "Wall")
        {
            turns++;
            if (turns % 2 == 1)
            {
                playerRigidBody.AddForce(-linearVelocity);
                obstacleManager.DeActiveAllObs();
                obstacleManager.SpawnLeftObstacles(turns);
            }
            else 
            {
                playerRigidBody.AddForce(linearVelocity);
                obstacleManager.DeActiveAllObs();
                obstacleManager.SpawnRightObstacles(turns);
            }
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (turns % 2 == 0)
        {
            //Left turn
            candyManager.DeSpawnCandy(collision.gameObject);
            candyManager.SpawnLeftCandy();
            candyManager.SetCandyCount(1);

        }
        else
        {
            //Right turn
            candyManager.DeSpawnCandy(collision.gameObject);
            candyManager.SpawnRightCandy();
            candyManager.SetCandyCount(1);

        }
    }

    public void PlayerInitialForce()
    {
        obstacleManager.SpawnRightObstacles(0);
        playerRigidBody.AddForce(linearVelocity);
    }

    public int GetTurnScore()
    { 
        return turns; 
    }

}
