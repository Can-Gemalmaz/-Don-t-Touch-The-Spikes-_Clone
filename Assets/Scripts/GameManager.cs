using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject gameSettings;
    [SerializeField] Button playAgainButton;
    [SerializeField] Button quitButton;
    [SerializeField] Transform playerSpawnPoint;
    [SerializeField] UIManager uIManager;
    [SerializeField] PlayerMovement player;

    int bestScore;
    private void Awake()
    {
        playAgainButton.onClick.AddListener(() =>
        {
           player.transform.position = playerSpawnPoint.position;
           player.transform.rotation = playerSpawnPoint.rotation;
           gameSettings.SetActive(false);
           player.gameObject.SetActive(true);
           player.PlayerInitialForce();
          
            
            player.OnPlayerDead += OnPlayerDeadEvent;
        });
        quitButton.onClick.AddListener(() =>
        {
            Application.Quit();
        });
        
    }

    // Start is called before the first frame update
    void Start()
    {
        bestScore = 0;
        if(!player)
        { 
             player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>(); 
        }

        player.OnPlayerDead += OnPlayerDeadEvent;
        uIManager.LoadPrefs();
    }

    private void OnPlayerDeadEvent(int obj, int candy)
    {
        gameSettings.SetActive(true);
        uIManager.OnDeadUI(obj, candy);

        uIManager.SavePrefs();

        player.OnPlayerDead -= OnPlayerDeadEvent;
    }

    // Update is called once per frame
    void Update()
    {
        uIManager.UpdateScoreBoard(player.GetTurnScore());

    }

}
