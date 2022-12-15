using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnText : MonoBehaviour
{
    public GameObject gridManager;
    public GameObject AIAgent;

    // Update is called once per frame
    void Update()
    {
        if(gridManager.GetComponentInChildren<GridManager>().winner != "?")
        {
            if (AIAgent.GetComponentInChildren<AIAgent>().humanVSAI)
            {
                if (gridManager.GetComponentInChildren<GridManager>().winner == "O")
                {
                    GetComponentInChildren<Text>().text = "Player - O won";
                }
                else
                {
                    GetComponentInChildren<Text>().text = "AI Agent - X won";
                }
            }
            else
            {
                if (gridManager.GetComponentInChildren<GridManager>().winner == "O")
                {
                    GetComponentInChildren<Text>().text = AIAgent.GetComponentInChildren<AIAgent>().agent1 + " - O won";
                }
                else
                {
                    GetComponentInChildren<Text>().text = AIAgent.GetComponentInChildren<AIAgent>().agent2 + " - X won";
                }
            }
        }
        else if (gridManager.GetComponentInChildren<GridManager>().turn == 0)
        {
            GetComponentInChildren<Text>().text = "O's Turn";
        }
        else
        {
            GetComponentInChildren<Text>().text = "X's Turn";
        }
    }
}
