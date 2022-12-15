using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public GameObject gridManager;
    public Button thisButton;
    public int x, y;

    void Start()
    {
        gridManager.GetComponentInChildren<GridManager>().bList.Add(thisButton);
    }

    public void changeText()
    {
        if (GetComponentInChildren<Text>().text == "" && gridManager.GetComponentInChildren<GridManager>().won == false && !gridManager.GetComponentInChildren<GridManager>().won)
        {
            if (gridManager.GetComponentInChildren<GridManager>().turn == 0)
            {
                GetComponentInChildren<Text>().text = "O";
                gridManager.GetComponentInChildren<GridManager>().board[x, y] = 1;
            }
            else
            {
                GetComponentInChildren<Text>().text = "X";
                gridManager.GetComponentInChildren<GridManager>().board[x, y] = 2;
            }

            gridManager.GetComponentInChildren<GridManager>().switchTurn();
        }
    }
}
