using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI resultText;
    [SerializeField] private GameObject startSceneTransition;
    [SerializeField] private GameObject endSceneTransition;
    void Start()
    {
        startSceneTransition.SetActive(true);
        Invoke("DisableStartSceneTransition", 2f);
        resultTextUpdate();
    }


    

    private void DisableStartSceneTransition()
    {
        startSceneTransition.SetActive(false);
    }
    private void resultTextUpdate()
    {
        if (GameData.GameResult)
        {
            resultText.text = "Player1 Won the Game!!";
        }
        else
        {
            resultText.text = "Player2 Won the Game!!";
        }
    }

    public void RestartGame()
    {
        endSceneTransition.SetActive(true);
        Invoke("GameScene", 2f);
        
    }

    private void GameScene()
    {
        SceneManager.LoadScene(1);
    }

    public void Mainmenu()
    {
        SceneManager.LoadScene(0);
    }
}
