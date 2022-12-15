using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridManager : MonoBehaviour
{
    [SerializeField] private Tile _TilePrefab;
    [SerializeField] private Transform _camera;

    public List<Button> bList = new List<Button>();
    public Button[] buttonList;
    public int numButton = 100;
    public int _width, _height;

    public int buttonDistance = 30;

    public GameObject spawnerPosition;
    public int turn = 0;
    public int[,] board;
    public string winner = "?";
    public bool won = false;
    public string firstPlayer = "O";
    public GameObject AIAgent;
    public GameObject AIGoFirstButton;
    bool generatedGrid = false;

    void Start()
    {
        buttonList = new Button[numButton];
    }

    void Update()
    {
        if (!generatedGrid && bList.Count == numButton)
        {
            generatedGrid = true;
            GenerateGrid();
        }
    }

    void GenerateGrid()
    {
        _width = (int)System.Math.Sqrt(numButton);
        _height = _width;
        for(int i = 0; i < bList.Count; i++)
        {
            buttonList[i] = bList[i];
        }

        board = new int[_width, _height];
        int count = 0;
        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                buttonList[count].transform.position = new Vector3(spawnerPosition.transform.position.y + y * buttonDistance, spawnerPosition.transform.position.x + x * buttonDistance);

                buttonList[count].GetComponent<ButtonManager>().x = x;
                buttonList[count].GetComponent<ButtonManager>().y = y;
                count++;
            }
        }

        _camera.transform.position = new Vector3((float)_width / 2 - 0.5f, (float)_height / 2 - 0.5f, -10);
    }

    public void switchTurn()
    {
        checkWin();

        if (!won)
        {
            turn = (turn + 1) % 2;
        }
        //Debug.Log(board[4, 0] + " " + board[4, 1] + " " + board[4, 2] + " " + board[4, 3] + " " + board[4, 4]);
        //Debug.Log(board[3, 0] + " " + board[3, 1] + " " + board[3, 2] + " " + board[3, 3] + " " + board[3, 4]);
        //Debug.Log(board[2, 0] + " " + board[2, 1] + " " + board[2, 2] + " " + board[2, 3] + " " + board[2, 4]);
        //Debug.Log(board[1, 0] + " " + board[1, 1] + " " + board[1, 2] + " " + board[1, 3] + " " + board[1, 4]);
        //Debug.Log(board[0, 0] + " " + board[0, 1] + " " + board[0, 2] + " " + board[0, 3] + " " + board[0, 4]);
        //Debug.Log("\n");
    }

    public void checkWin()
    {
        for(int x =0; x<_width; x++)
        {
            for(int y=0; y<_height; y++)
            {
                if (board[x, y] != 0)
                {
                    // Check 4 on the right
                    if (y + 1 < _width && y + 2 < _width && y + 3 < _width && y + 4 < _width 
                        && board[x, y] == board[x, y + 1] && board[x, y] == board[x, y + 2] && board[x, y] == board[x, y + 3] && board[x, y] == board[x, y + 4])
                    {
                        Debug.Log("won");
                        won = true;
                    }

                    // Check 4 on the up
                    else if (x + 1 < _height && x + 2 < _height && x + 3 < _height && x + 4 < _height 
                        && board[x, y] == board[x + 1, y] && board[x, y] == board[x + 2, y] && board[x, y] == board[x + 3, y] && board[x, y] == board[x + 4, y])
                    {
                        Debug.Log("won");
                        won = true;
                    }

                    // Check 4 on the up right diagonal
                    else if (x + 1 < _height && x + 2 < _height && x + 3 < _height && x + 4 < _height
                        && y+1 <_height && y+2 <_height && y + 3 < _height && y + 4 < _height
                        && board[x, y] == board[x + 1, y + 1] && board[x, y] == board[x + 2, y + 2] && board[x, y] == board[x + 3, y + 3] && board[x, y] == board[x + 4, y + 4])
                    {
                        Debug.Log("won");
                        won = true;
                    }

                    // Check 4 on the down right diagonal
                    else if (x - 1 >=0 && x - 2 >= 0 && x - 3 >= 0 && x - 4 >= 0
                        && y + 1 <_width && y + 2 < _width && y + 3 < _width && y + 4 < _width
                        && board[x, y] == board[x - 1, y + 1] && board[x, y] == board[x - 2, y + 2] && board[x, y] == board[x - 3, y + 3] && board[x, y] == board[x - 4, y + 4])
                    {
                        Debug.Log(x + " " + y + ", Value:" + board[x, y]);
                        Debug.Log("won");
                        won = true;
                    }

                    if (won == true)
                    {
                        if (board[x, y] == 1)
                        {
                            winner = "O";
                        }
                        else if(board[x, y] == 2)
                        {
                            winner = "X";
                        }
                        else
                        {
                            winner = "Something wrong";
                        }
                        x = _width;
                        y = _height;
                    }
                }
            }
        }
    }

    public void ResetGame()
    {
        AIGoFirstButton.GetComponentInChildren<FirstPlayerButton>().switched = false;
        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                board[x, y] = 0;
            }
        }

        foreach (Button button in buttonList)
        {
            button.GetComponentInChildren<Text>().text = "";
        }

        AIAgent.GetComponentInChildren<AIAgent>().playedFirstMove = false;
        AIAgent.GetComponentInChildren<AIAgent>().numFirstMove = 0;
        turn = 0;
        won = false;
    }
}
