using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }


    [SerializeField] private GameObject player1Die;
    [SerializeField] private GameObject player2Die;
    [SerializeField] private GameObject startSceneTransition;
    [SerializeField] private GameObject endSceneTransition;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        player1Die.SetActive(true);
        player2Die.SetActive(false);
        startSceneTransition.SetActive(true);
        Invoke("DisableStartSceneTransition", 2f);
    }

    
    void Update()
    {
        
    }

    private void DisableStartSceneTransition()
    {
        startSceneTransition.SetActive(false);
    }

    public void GameOver()
    {
        endSceneTransition.SetActive(true);
        Invoke("GameOverScene", 2f);
    }

    private void GameOverScene()
    {
        SceneManager.LoadScene(2);
    }

    public void Player1Pressed()
    {
        player1Die.SetActive(false);
        player2Die.SetActive(true);
    }

    public void Player2Pressed()
    {
        player2Die.SetActive(false);
        player1Die.SetActive(true);
        
    }

}
