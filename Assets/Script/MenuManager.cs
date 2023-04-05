using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject quiteButton;
    [SerializeField] private GameObject endSceneTransition;
    
    void Start()
    {
        
        StartCoroutine(FadeInText());
        Invoke("MakeButtonsVisible", 2.5f);
    }

    
    void Update()
    {
        
    }
    IEnumerator FadeInText()
    {
        Color textColor = new Color(1, 1, 1, 0);
        while (titleText.color.a <= 1)
        {
            textColor.a += (2f * Time.deltaTime);
            titleText.color = textColor;
            yield return new WaitForEndOfFrame();
        }
        
    }

   
    private void MakeButtonsVisible()
    {
        playButton.SetActive(true);
        quiteButton.SetActive(true);
    }

    public void GameScene()
    {
        endSceneTransition.SetActive(true);
        Invoke("SceneChange", 2f);
        
    }

    public void SceneChange()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
