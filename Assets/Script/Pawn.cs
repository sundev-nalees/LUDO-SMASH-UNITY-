using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Pawn : MonoBehaviour
{
    [SerializeField] private Route currentRoute;
    [SerializeField] private TextMeshProUGUI dieNumber;

    private int routePosition;
    private bool isMoving;

    public int steps;

    

    private void Update()
    {
        
        if (routePosition+1 == currentRoute.childNodeList.Count)
        {
            if (this.tag == "Player1")
            {
                
                GameData.GameResult = true;
                Debug.Log("GameOver Player1 Won");
                GameOverScene();
            }
            else
            {
                GameData.GameResult = false;
                Debug.Log("GameOver Player2 Won");
                GameOverScene();
            }
            
        }
    }
    private  void GameOverScene()
    {
        GameManager.Instance.GameOver();
        
    }

    public void RollDice()
    {

        
        steps = Random.Range(1, 7);
        dieNumber.text = "No:" + steps;
        Debug.Log("Dice Rolled :" + steps);
        if (routePosition + steps < currentRoute.childNodeList.Count)
        {
           StartCoroutine(Move());
        }
        else
        {
           Debug.Log("RolledNumber is too high");
        }

       
    }
    IEnumerator Move()
    {
        if (isMoving)
        {
            yield break;
        }
        isMoving = true;

        while (steps > 0)
        {
            Vector3 nextPos = currentRoute.childNodeList[routePosition + 1].position;
            while (MoveToNextNode(nextPos)) { yield return null; }

            yield return new WaitForSeconds(0.1f);
            steps--;
            routePosition++;
        }

        isMoving = false;
    }

    bool MoveToNextNode(Vector3 target)
    {
        return target != (transform.position = Vector3.MoveTowards(transform.position, target, 2f * Time.deltaTime));
    }
 
}
