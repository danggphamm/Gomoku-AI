using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AIAgent : MonoBehaviour
{
    public GameObject gridManager;
    public Button[] buttonList;
    public int turn = 1;
	public int width, height;
	public bool playedFirstMove = false;
	public string agent = "";

	public string agent1 = "";
	public int agent1Turn = 0;
	public string agent2 = "";
	public int agent2Turn = 1;

	public GameObject playingAgents;
	public int numFirstMove = 0;
	public int numFirstMoveAllowed = 1;

	public bool humanVSAI = true;
	// int agentNum = 2;

	void Start()
    {
        buttonList = gridManager.GetComponentInChildren<GridManager>().buttonList;

        if (!humanVSAI)
        {
			numFirstMoveAllowed = 2;
        }
	}

    // Update is called once per frame
    void Update()
    {
		System.Threading.Thread.Sleep(1000);

		if (humanVSAI)
		{
			playingAgents.GetComponentInChildren<Text>().text = "O: Human player\n\n" + "X: " + agent;

			if (gridManager.GetComponentInChildren<GridManager>().turn == turn && !gridManager.GetComponentInChildren<GridManager>().won)
			{
				Debug.Log(agent + "'s turn");
				//GreedyAgentCheckRangeAndBlockOpponent();
				if (agent == "GreedyAgentCheckRangeAndBlockOpponent")
				{
					Debug.Log(agent + " played");
					GreedyAgentCheckRangeAndBlockOpponent(turn + 1);
				}
				if (agent == "GreedyAgentCheckRangeAndBlockOpponentAdvance")
				{
					Debug.Log(agent + " played");
					GreedyAgentCheckRangeAndBlockOpponentAdvance(turn + 1);
				}
				else if (agent == "Random")
				{
					Debug.Log(agent + " played");
					RandomAgent();
				}
				else if (agent == "GreedyAgent")
				{
					Debug.Log(agent + " played");
					GreedyAgent(turn + 1);
				}
				else if (agent == "GreedyAgentCheckRange")
				{
					Debug.Log(agent + " played");
					GreedyAgentCheckRange(turn + 1);
				}

				else if (agent == "GreedyAgentCheckRangeAdvance")
				{
					Debug.Log(agent + " played");
					GreedyAgentCheckRangeAdvance(turn + 1);
				}
				else if (agent == "DefensiveAgent")
				{
					Debug.Log(agent + " played");
					DefensiveAgent(turn + 1);
				}
				else if (agent == "DefensiveAgentAdvance")
				{
					Debug.Log(agent + " played");
					DefensiveAgentAdvance(turn + 1);
				}
				else
				{
					Debug.Log("Invalid agent name");
				}
			}
		}
        else
        {
			playingAgents.GetComponentInChildren<Text>().text = "O: " + agent1 + "\n\nX: " + agent2;
			if (gridManager.GetComponentInChildren<GridManager>().turn == agent1Turn && !gridManager.GetComponentInChildren<GridManager>().won)
			{
				Debug.Log(agent1 + "'s turn");
				//GreedyAgentCheckRangeAndBlockOpponent();
				if (agent1 == "GreedyAgentCheckRangeAndBlockOpponent")
				{
					Debug.Log(agent1 + " played");
					GreedyAgentCheckRangeAndBlockOpponent(agent1Turn + 1);
				}
				else if (agent1 == "GreedyAgentCheckRangeAndBlockOpponentAdvance")
				{
					Debug.Log(agent1 + " played");
					GreedyAgentCheckRangeAndBlockOpponentAdvance(agent1Turn + 1);
				}
				else if (agent1 == "Random")
				{
					Debug.Log(agent1 + " played");
					RandomAgent();
				}
				else if (agent1 == "GreedyAgent")
				{
					Debug.Log(agent1 + " played");
					GreedyAgent(agent1Turn + 1);
				}
				else if (agent1 == "GreedyAgentCheckRange")
				{
					Debug.Log(agent1 + " played");
					GreedyAgentCheckRange(agent1Turn + 1);
				}
				else if (agent1 == "GreedyAgentCheckRangeAdvance")
				{
					Debug.Log(agent1 + " played");
					GreedyAgentCheckRangeAdvance(agent1Turn + 1);
				}
				else if (agent1 == "DefensiveAgent")
				{
					Debug.Log(agent1 + " played");
					DefensiveAgent(agent1Turn + 1);
				}
				else if (agent1 == "DefensiveAgentAdvance")
				{
					Debug.Log(agent1 + " played");
					DefensiveAgentAdvance(agent1Turn + 1);
				}
				else
				{
					Debug.Log("Invalid agent name");
				}
			}

			else if (gridManager.GetComponentInChildren<GridManager>().turn == agent2Turn && !gridManager.GetComponentInChildren<GridManager>().won)
			{
				Debug.Log(agent2 + "'s turn");
				//GreedyAgentCheckRangeAndBlockOpponent();
				if (agent2 == "GreedyAgentCheckRangeAndBlockOpponent")
				{
					Debug.Log(agent2 + " played");
					GreedyAgentCheckRangeAndBlockOpponent(agent2Turn + 1);
				}
				if (agent2 == "GreedyAgentCheckRangeAndBlockOpponentAdvance")
				{
					Debug.Log(agent2 + " played");
					GreedyAgentCheckRangeAndBlockOpponentAdvance(agent2Turn + 1);
				}
				else if (agent2 == "Random")
				{
					Debug.Log(agent + " played");
					RandomAgent();
				}
				else if (agent2 == "GreedyAgent")
				{
					Debug.Log(agent2 + " played");
					GreedyAgent(agent2Turn + 1);
				}
				else if (agent2 == "GreedyAgentCheckRange")
				{
					Debug.Log(agent2 + " played");
					GreedyAgentCheckRange(agent2Turn + 1);
				}
				else if (agent2 == "GreedyAgentCheckRangeAdvance")
				{
					Debug.Log(agent2 + " played");
					GreedyAgentCheckRangeAdvance(agent2Turn + 1);
				}
				else if (agent2 == "DefensiveAgent")
				{
					Debug.Log(agent2 + " played");
					DefensiveAgent(agent2Turn + 1);
				}
				else if (agent2 == "DefensiveAgentAdvance")
				{
					Debug.Log(agent2 + " played");
					DefensiveAgentAdvance(agent2Turn + 1);
				}
				else
				{
					Debug.Log("Invalid agent name");
				}
			}
		}
    }

    void RandomAgent()
    {
		buttonList = gridManager.GetComponentInChildren<GridManager>().buttonList;

		width = gridManager.GetComponentInChildren<GridManager>()._width;
		height = gridManager.GetComponentInChildren<GridManager>()._height;

		if (numFirstMove < numFirstMoveAllowed)
		{
			int rndX = width/2 - 1 + Random.Range(0, 3);
			int rndY = width / 2 - 1 + Random.Range(0, 3);

			foreach (Button button in buttonList)
			{
				if (button.GetComponentInChildren<ButtonManager>().x == rndX && button.GetComponentInChildren<ButtonManager>().y == rndY)
				{
					button.GetComponentInChildren<ButtonManager>().changeText();
				}
			}
			numFirstMove++;
		}
		else
		{
			List<Button> freeSpace = new List<Button>();
			foreach (Button button in buttonList)
			{
				if (button.GetComponentInChildren<Text>().text != "X" && button.GetComponentInChildren<Text>().text != "O")
				{
					freeSpace.Add(button);
				}
			}

			int rnd = Random.Range(0, freeSpace.Count);
			Button chosenPosition = freeSpace[rnd];

			chosenPosition.GetComponentInChildren<ButtonManager>().changeText();
		}
    }

	void DefensiveAgent(int numberOnBoard)
	{
		width = gridManager.GetComponentInChildren<GridManager>()._width;
		height = gridManager.GetComponentInChildren<GridManager>()._height;

		int otherAgentNum = numberOnBoard % 2 + 1;

		if (numFirstMove < numFirstMoveAllowed)
		{
			RandomAgent();
		}
		else
		{
			int initialPoint = totalPointCheckRange(gridManager.GetComponentInChildren<GridManager>().board, numberOnBoard);

			Button bestPosition = buttonList[0];

			int highestPoint = -10000;

			List<Button> freeSpace = new List<Button>();
			foreach (Button button in buttonList)
			{
				if (button.GetComponentInChildren<Text>().text != "X" && button.GetComponentInChildren<Text>().text != "O")
				{
					int[,] boardAfter = new int[width, height];
					int[,] boardOpponentAfter = new int[width, height];

					for (int x = 0; x < width; x++)
					{
						for (int y = 0; y < height; y++)
						{
							boardAfter[x, y] = gridManager.GetComponentInChildren<GridManager>().board[x, y];
							boardOpponentAfter[x, y] = gridManager.GetComponentInChildren<GridManager>().board[x, y];
						}
					}

					boardAfter[button.GetComponentInChildren<ButtonManager>().x, button.GetComponentInChildren<ButtonManager>().y] = numberOnBoard;
					boardOpponentAfter[button.GetComponentInChildren<ButtonManager>().x, button.GetComponentInChildren<ButtonManager>().y] = otherAgentNum;

					int pointAfter = totalPointCheckRange(boardAfter, numberOnBoard) + (int)(totalPointOpponent45(boardOpponentAfter, otherAgentNum)*1.8);

					if (pointAfter - initialPoint > highestPoint)
					{
						highestPoint = pointAfter - initialPoint;
						bestPosition = button;

					}
					else if (pointAfter - initialPoint == highestPoint)
					{
						if (Random.Range(0, 2) == 1)
						{
							bestPosition = button;
						}
					}
				}
			}

			bestPosition.GetComponentInChildren<ButtonManager>().changeText();
		}
	}

	void DefensiveAgentAdvance(int numberOnBoard)
	{
		width = gridManager.GetComponentInChildren<GridManager>()._width;
		height = gridManager.GetComponentInChildren<GridManager>()._height;

		int otherAgentNum = numberOnBoard % 2 + 1;

		if (numFirstMove < numFirstMoveAllowed)
		{
			RandomAgent();
		}
		else
		{
			int initialPoint = totalPointCheckRangeAdvance(gridManager.GetComponentInChildren<GridManager>().board, numberOnBoard);

			Button bestPosition = buttonList[0];

			int highestPoint = -10000;

			List<Button> freeSpace = new List<Button>();
			foreach (Button button in buttonList)
			{
				if (button.GetComponentInChildren<Text>().text != "X" && button.GetComponentInChildren<Text>().text != "O")
				{
					int[,] boardAfter = new int[width, height];
					int[,] boardOpponentAfter = new int[width, height];

					for (int x = 0; x < width; x++)
					{
						for (int y = 0; y < height; y++)
						{
							boardAfter[x, y] = gridManager.GetComponentInChildren<GridManager>().board[x, y];
							boardOpponentAfter[x, y] = gridManager.GetComponentInChildren<GridManager>().board[x, y];
						}
					}

					boardAfter[button.GetComponentInChildren<ButtonManager>().x, button.GetComponentInChildren<ButtonManager>().y] = numberOnBoard;
					boardOpponentAfter[button.GetComponentInChildren<ButtonManager>().x, button.GetComponentInChildren<ButtonManager>().y] = otherAgentNum;

					int pointAfter = totalPointCheckRangeAdvance(boardAfter, numberOnBoard) + (int)(totalPointOpponentAdvance(boardOpponentAfter, otherAgentNum) * 1.2);

					if (pointAfter - initialPoint > highestPoint)
					{
						highestPoint = pointAfter - initialPoint;
						bestPosition = button;

					}
					else if (pointAfter - initialPoint == highestPoint)
					{
						if (Random.Range(0, 2) == 1)
						{
							bestPosition = button;
						}
					}
				}
			}

			bestPosition.GetComponentInChildren<ButtonManager>().changeText();
		}
	}

	void GreedyAgentCheckRangeAndBlockOpponentAdvance(int numberOnBoard)
	{
		width = gridManager.GetComponentInChildren<GridManager>()._width;
		height = gridManager.GetComponentInChildren<GridManager>()._height;

		int otherAgentNum = numberOnBoard % 2 + 1;

		if (numFirstMove < numFirstMoveAllowed)
		{
			Debug.Log("Hit random");
			RandomAgent();
		}
		else
		{
			int initialPoint = totalPointCheckRangeAdvance(gridManager.GetComponentInChildren<GridManager>().board, numberOnBoard);

			Button bestPosition = buttonList[0];

			int highestPoint = -10000;

			List<Button> freeSpace = new List<Button>();
			foreach (Button button in buttonList)
			{
				if (button.GetComponentInChildren<Text>().text != "X" && button.GetComponentInChildren<Text>().text != "O")
				{
					int[,] boardAfter = new int[width, height];
					int[,] boardOpponentAfter = new int[width, height];

					for (int x = 0; x < width; x++)
					{
						for (int y = 0; y < height; y++)
						{
							boardAfter[x, y] = gridManager.GetComponentInChildren<GridManager>().board[x, y];
							boardOpponentAfter[x, y] = gridManager.GetComponentInChildren<GridManager>().board[x, y];
						}
					}

					boardAfter[button.GetComponentInChildren<ButtonManager>().x, button.GetComponentInChildren<ButtonManager>().y] = numberOnBoard;
					boardOpponentAfter[button.GetComponentInChildren<ButtonManager>().x, button.GetComponentInChildren<ButtonManager>().y] = otherAgentNum;

					int pointAfter = totalPointCheckRangeAdvance(boardAfter, numberOnBoard) + totalPointOpponentAdvance(boardOpponentAfter, otherAgentNum);

					if (pointAfter - initialPoint > highestPoint)
					{
						highestPoint = pointAfter - initialPoint;
						bestPosition = button;

					}
					else if (pointAfter - initialPoint == highestPoint)
					{
						if (Random.Range(0, 2) == 1)
						{
							bestPosition = button;
						}
					}
				}
			}

			bestPosition.GetComponentInChildren<ButtonManager>().changeText();
		}
	}

	void GreedyAgentCheckRangeAndBlockOpponent(int numberOnBoard)
	{
		width = gridManager.GetComponentInChildren<GridManager>()._width;
		height = gridManager.GetComponentInChildren<GridManager>()._height;

		int otherAgentNum = numberOnBoard%2 + 1;

		if (numFirstMove < numFirstMoveAllowed)
		{
			Debug.Log("Hit random");
			RandomAgent();
		}
		else
		{
			int initialPoint = totalPointCheckRange(gridManager.GetComponentInChildren<GridManager>().board, numberOnBoard);

			Button bestPosition = buttonList[0];

			int highestPoint = -10000;

			List<Button> freeSpace = new List<Button>();
			foreach (Button button in buttonList)
			{
				if (button.GetComponentInChildren<Text>().text != "X" && button.GetComponentInChildren<Text>().text != "O")
				{
					int[,] boardAfter = new int[width, height];
					int[,] boardOpponentAfter = new int[width, height];

					for (int x = 0; x < width; x++)
					{
						for (int y = 0; y < height; y++)
						{
							boardAfter[x, y] = gridManager.GetComponentInChildren<GridManager>().board[x, y];
							boardOpponentAfter[x, y] = gridManager.GetComponentInChildren<GridManager>().board[x, y];
						}
					}

					boardAfter[button.GetComponentInChildren<ButtonManager>().x, button.GetComponentInChildren<ButtonManager>().y] = numberOnBoard;
					boardOpponentAfter[button.GetComponentInChildren<ButtonManager>().x, button.GetComponentInChildren<ButtonManager>().y] = otherAgentNum;

					int pointAfter = totalPointCheckRange(boardAfter, numberOnBoard) + totalPointOpponent45(boardOpponentAfter, otherAgentNum);

					if (pointAfter - initialPoint > highestPoint)
					{
						highestPoint = pointAfter - initialPoint;
						bestPosition = button;

					}
					else if (pointAfter - initialPoint == highestPoint)
					{
						if (Random.Range(0, 2) == 1)
						{
							bestPosition = button;
						}
					}
				}
			}

			bestPosition.GetComponentInChildren<ButtonManager>().changeText();
		}
	}

	void GreedyAgentCheckRangeAdvance(int numberOnBoard)
	{
		width = gridManager.GetComponentInChildren<GridManager>()._width;
		height = gridManager.GetComponentInChildren<GridManager>()._height;

		int otherAgentNum = (numberOnBoard + 1) % 2 + 1;

		if (numFirstMove < numFirstMoveAllowed)
		{
			RandomAgent();
		}
		else
		{
			int initialPoint = totalPointCheckRangeAdvance(gridManager.GetComponentInChildren<GridManager>().board, numberOnBoard);

			Button bestPosition = buttonList[0];

			int highestPoint = -1000;

			List<Button> freeSpace = new List<Button>();
			foreach (Button button in buttonList)
			{
				if (button.GetComponentInChildren<Text>().text != "X" && button.GetComponentInChildren<Text>().text != "O")
				{
					int[,] boardAfter = new int[width, height];

					for (int x = 0; x < width; x++)
					{
						for (int y = 0; y < height; y++)
						{
							boardAfter[x, y] = gridManager.GetComponentInChildren<GridManager>().board[x, y];
						}
					}

					boardAfter[button.GetComponentInChildren<ButtonManager>().x, button.GetComponentInChildren<ButtonManager>().y] = numberOnBoard;

					int pointAfter = totalPointCheckRangeAdvance(boardAfter, numberOnBoard);

					if (pointAfter - initialPoint > highestPoint)
					{
						highestPoint = pointAfter - initialPoint;
						bestPosition = button;

					}
					else if (pointAfter - initialPoint == highestPoint)
					{
						if (Random.Range(0, 2) == 1)
						{
							bestPosition = button;
						}
					}
				}
			}

			bestPosition.GetComponentInChildren<ButtonManager>().changeText();
		}
	}

	void GreedyAgentCheckRange(int numberOnBoard)
	{
		width = gridManager.GetComponentInChildren<GridManager>()._width;
		height = gridManager.GetComponentInChildren<GridManager>()._height;

		int otherAgentNum = (numberOnBoard + 1) % 2 + 1;

		if (numFirstMove < numFirstMoveAllowed)
		{
			RandomAgent();
		}
		else
		{
			int initialPoint = totalPointCheckRange(gridManager.GetComponentInChildren<GridManager>().board, numberOnBoard);

			Button bestPosition = buttonList[0];

			int highestPoint = -1000;

			List<Button> freeSpace = new List<Button>();
			foreach (Button button in buttonList)
			{
				if (button.GetComponentInChildren<Text>().text != "X" && button.GetComponentInChildren<Text>().text != "O")
				{
					int[,] boardAfter = new int[width, height];

					for (int x = 0; x < width; x++)
					{
						for (int y = 0; y < height; y++)
						{
							boardAfter[x, y] = gridManager.GetComponentInChildren<GridManager>().board[x, y];
						}
					}

					boardAfter[button.GetComponentInChildren<ButtonManager>().x, button.GetComponentInChildren<ButtonManager>().y] = numberOnBoard;

					int pointAfter = totalPointCheckRange(boardAfter, numberOnBoard);

					if (pointAfter - initialPoint > highestPoint)
					{
						highestPoint = pointAfter - initialPoint;
						bestPosition = button;

					}
					else if (pointAfter - initialPoint == highestPoint)
					{
						if (Random.Range(0, 2) == 1)
						{
							bestPosition = button;
						}
					}
				}
			}

			bestPosition.GetComponentInChildren<ButtonManager>().changeText();
		}
	}

	void GreedyAgent(int numberOnBoard)
    {
		buttonList = gridManager.GetComponentInChildren<GridManager>().buttonList;
		width = gridManager.GetComponentInChildren<GridManager>()._width;
		height = gridManager.GetComponentInChildren<GridManager>()._height;

		int otherAgentNum = (numberOnBoard + 1) % 2 + 1;

		if (numFirstMove < numFirstMoveAllowed)
        {
			RandomAgent();
		}
		else {
			int initialPoint = totalPoint(gridManager.GetComponentInChildren<GridManager>().board, numberOnBoard);

			Button bestPosition = buttonList[0];

			int highestPoint = -1000;

			List<Button> freeSpace = new List<Button>();
			foreach (Button button in buttonList)
			{
				if (button.GetComponentInChildren<Text>().text != "X" && button.GetComponentInChildren<Text>().text != "O")
				{
					int[,] boardAfter = new int[width, height];

					for (int x = 0; x < width; x++)
					{
						for (int y = 0; y < height; y++)
						{
							boardAfter[x, y] = gridManager.GetComponentInChildren<GridManager>().board[x, y];
						}
					}

					boardAfter[button.GetComponentInChildren<ButtonManager>().x, button.GetComponentInChildren<ButtonManager>().y] = numberOnBoard;

					int pointAfter = totalPoint(boardAfter, numberOnBoard);

					if (pointAfter - initialPoint > highestPoint)
					{
						highestPoint = pointAfter - initialPoint;
						bestPosition = button;

					}
					else if (pointAfter - initialPoint == highestPoint)
					{
						if (Random.Range(0, 2) == 1)
						{
							bestPosition = button;
						}
					}
				}
			}

			bestPosition.GetComponentInChildren<ButtonManager>().changeText();
		}
	}

    int totalPoint(int[,] board, int numToCheck)
    {
		int num2Cont = 0;
		int num3Cont = 0;
		int num4Cont = 0;
		int num5Cont = 0;

		for (int i = 0; i < width; i++)
		{
			for (int j = 0; j < height; j++)
			{
				if (board[i,j] == numToCheck)
				{
					// Right continuation
					int copyJ = j;
					int count = 1;

					while (copyJ + 1 < width && board[i,copyJ + 1] == board[i,j])
					{
						count++;
						copyJ++;
					}


					if ((j - 1 >= 0 && board[i,j] != board[i,j - 1]) || j == 0)
					{
						if (count == 2)
						{
							num2Cont++;
						}
						else if (count == 3)
						{
							num3Cont++;
						}
						else if (count == 4)
						{
							num4Cont++;
						}
						else if (count == 5)
						{
							num5Cont++;
						}
					}

					// Down continuation
					int copyI = i;
					count = 1;

					while (copyI + 1 < width && board[copyI + 1,j] == board[i,j])
					{
						count++;
						copyI++;
					}


					if ((i - 1 >= 0 && board[i,j] != board[i - 1,j]) || i == 0)
					{
						if (count == 2)
						{
							num2Cont++;
						}
						else if (count == 3)
						{
							num3Cont++;
						}
						else if (count == 4)
						{
							num4Cont++;
						}
						else if (count == 5)
						{
							num5Cont++;
						}
					}

					// Down right continuation
					copyI = i;
					copyJ = j;
					count = 1;

					while (copyI + 1 < width && copyJ + 1 < height && board[copyI + 1,copyJ + 1] == board[i,j])
					{
						count++;
						copyI++;
						copyJ++;
					}


					if ((i - 1 >= 0 && j - 1 >= 0 && board[i,j] != board[i - 1,j - 1]) || i == 0 || j == 0)
					{
						if (count == 2)
						{
							num2Cont++;
						}
						else if (count == 3)
						{
							num3Cont++;
						}
						else if (count == 4)
						{
							num4Cont++;
						}
						else if (count == 5)
						{
							num5Cont++;
						}
					}

					// Up right continuation
					copyI = i;
					copyJ = j;
					count = 1;

					while (copyI + 1 < width && copyJ - 1 >= 0 && board[copyI + 1,copyJ - 1] == board[i,j])
					{
						count++;
						copyI++;
						copyJ--;
					}


					if ((i - 1 >= 0 && j + 1 < height && board[i,j] != board[i - 1,j + 1]) || i == 0 || j == 0)
					{
						if (count == 2)
						{
							num2Cont++;
						}
						else if (count == 3)
						{
							num3Cont++;
						}
						else if (count == 4)
						{
							num4Cont++;
						}
						else if (count == 5)
						{
							num5Cont++;
						}
					}
				}
			}
		}

		int totalPoints = num2Cont * 3 + num3Cont * 12 + num4Cont * 50 + num5Cont*1000;
		return totalPoints;
	}

	int totalPointCheckRange(int[,] board, int numToCheck)
	{
		int num2Cont = 2;
		int num3Cont = 5;
		int num3ContNonBlock = 10;
		int num4Cont = 7;
		int num4ContNonBlock = 900;
		int num5Cont = 100000;
		int sum = 0;

		for (int i = 0; i < width; i++)
		{
			for (int j = 0; j < height; j++)
			{
				if (board[i, j] == numToCheck)
				{
					// Right continuation
					int copyJ = j;
					int count = 1;

					while (copyJ + 1 < width && board[i, copyJ + 1] == board[i, j])
					{
						count++;
						copyJ++;
					}


					if ((j - 1 >= 0 && board[i, j] != board[i, j - 1]) || j == 0)
					{
						if (count == 2)
						{
							if (// If 3 left is blank
								(j - 3 >= 0 && board[i, j - 3] == 0 && board[i, j - 2] == 0 && board[i, j - 1] == 0) ||
								// If two left and one right is blank
								(j - 2 >= 0 && board[i, j - 2] == 0 && board[i, j - 1] == 0 && j + 2 < width && board[i, j + 2] == 0) ||
								// If one left and two right is blank
								(j - 1 >= 0 && board[i, j - 1] == 0  && j + 3 < width && board[i, j + 2] == 0 && board[i, j + 3] == 0) ||
								// If 3 right is blank
								(j + 4 < width && board[i, j + 2] == 0 && board[i, j + 3] == 0 && board[i, j + 4] == 0)
								)
							{
								sum += num2Cont;
							}
						}
						else if (count == 3)
						{
							if (// If left is blank and right is blank
								(j - 1 >= 0 && board[i, j - 1] == 0 && j + 3 < width && board[i, j + 3] == 0))
                            {
								sum += num3ContNonBlock;
                            }
							else if(
								// If two left is blank
								(j - 2 >= 0 && board[i, j - 2] == 0 && board[i, j - 1] == 0) ||
								// If two right is blank
								(j + 4 < width && board[i, j + 3] == 0 && board[i, j + 4] == 0))
                            {
								sum += num3Cont;
							}
						}
						else if (count == 4)
						{
							//Debug.Log("Detect 4\n");
							if (// If left is blank and right is blank
								j - 1 >= 0 && board[i, j - 1] == 0 && j + 4 < width && board[i, j + 4] == 0)
							{
								//Debug.Log("Detect 4 best case\n");
								sum += num4ContNonBlock;
							}
							// If left is blank or right is blank
							else if (
									(j + 4 < width && board[i, j + 4] == 0) ||
									(j - 1 >= 0 && board[i, j - 1] == 0)
									)
                            {
								//Debug.Log("Detect 4 normal case\n");
								sum += num4Cont;
                            }
						}
						else if (count == 5)
						{
							sum += num5Cont;
						}
					}

					// Down continuation
					int copyI = i;
					count = 1;

					while (copyI + 1 < width && board[copyI + 1, j] == board[i, j])
					{
						count++;
						copyI++;
					}


					if ((i - 1 >= 0 && board[i, j] != board[i - 1, j]) || i == 0)
					{
						if (count == 2)
						{
							if (// If 3 down is blank
								(i - 3 >= 0 && board[i - 3, j] == 0 && board[i - 2, j] == 0 && board[i - 1, j] == 0) ||
								// If two down and one up is blank
								(i - 2 >= 0 && board[i - 2, j] == 0 && board[i - 1, j] == 0 && i + 2 < width && board[i + 2, j] == 0) ||
								// If one down and two up is blank
								(i - 1 >= 0 && board[i - 1, j] == 0 && i + 3 < width && board[i + 2, j] == 0 && board[i + 3, j] == 0) ||
								// If 3 up is blank
								(i + 4 < width && board[i + 2, j] == 0 && board[i + 3, j] == 0 && board[i + 4, j] == 0)
								)
							{
								sum += num2Cont;
							}
						}
						else if (count == 3)
						{
							if (// If up is blank and down is blank
								(i - 1 >= 0 && board[i - 1, j] == 0 && i + 3 < width && board[i + 3, j] == 0) )
							{
								sum += num3ContNonBlock;
							}
							else if(
								// If two down is blank
								(i - 2 >= 0 && board[i - 2, j] == 0 && board[i - 1, j] == 0) ||
								// If two up is blank
								(i + 4 < width && board[i + 3, j] == 0 && board[i + 4, j] == 0))
                            {
								sum += num3Cont;
							}
						}
						else if (count == 4)
						{
							//Debug.Log("Detect 4\n");
							if (// If up is blank and down is blank
								i - 1 >= 0 && board[i - 1, j] == 0 && i + 4 < width && board[i + 4, j] == 0)
							{
								//Debug.Log("Detect 4 best case\n");
								sum += num4ContNonBlock;
							}
							// If up is blocked or down is blocked
							else if (
									(i + 4 < width && board[i + 4, j] == 0) ||
									(i - 1 >= 0 && board[i - 1, j] == 0)
									)
							{
								//Debug.Log("Detect 4 normal case\n");
								sum += num4Cont;
							}
						}
						else if (count == 5)
						{
							sum += num5Cont;
						}
					}

					// Up right continuation
					copyI = i;
					copyJ = j;
					count = 1;

					while (copyI + 1 < width && copyJ + 1 < height && board[copyI + 1, copyJ + 1] == board[i, j])
					{
						count++;
						copyI++;
						copyJ++;
					}


					if ((i - 1 >= 0 && j - 1 >= 0 && board[i, j] != board[i - 1, j - 1]) || i == 0 || j == 0)
					{
						if (count == 2)
						{
							if (// If 3 down left is blank
								(i - 3 >= 0 && j - 3 >= 0 && board[i - 3, j - 3] == 0 && board[i - 2, j - 2] == 0 && board[i - 1, j - 1] == 0) ||
								// If two down left and one up right is blank
								(i - 2 >= 0 && j - 2 >= 0 && board[i - 2, j - 2] == 0 && board[i - 1, j - 1] == 0 && i + 2 < width && j + 2 < width && board[i + 2, j + 2] == 0) ||
								// If one down left and two up right is blank
								(i - 1 >= 0 && j - 1 >= 0 && board[i - 1, j - 1] == 0 && i + 3 < width && j + 3 < width && board[i + 2, j + 2] == 0 && board[i + 3, j + 3] == 0) ||
								// If 3 up right is blank
								(i + 4 < width && j + 4 < width && board[i + 2, j + 2] == 0 && board[i + 3, j + 3] == 0 && board[i + 4, j + 4] == 0)
								)
							{
								sum += num2Cont;
							}
						}
						else if (count == 3)
						{
							if (// If up right is blank and down left is blank
								(i-1 >= 0 && j - 1 >= 0 && board[i - 1, j - 1] == 0 && i + 3 < width && j + 3 < width && board[i + 3, j + 3] == 0) )
							{
								sum += num3ContNonBlock;
							}
							else if(
								// If two down left is blank
								(i - 2 >= 0 && j - 2 >= 0 && board[i - 2, j - 2] == 0 && board[i - 1, j - 1] == 0) ||
								// If two up right is blank
								(i + 4 < width && j + 4 < width && board[i + 3, j + 3] == 0 && board[i + 4, j + 4] == 0))
                            {
								sum += num3Cont;
							}
						}
						else if (count == 4)
						{
							//Debug.Log("Detect 4\n");
							if (// If up right is blank and down is blank
								i - 1 >= 0 && j - 1 >= 0 && board[i - 1, j - 1] == 0 && i + 4 < width && j+4 < width && board[i + 4, j + 4] == 0)
							{
								//Debug.Log("Detect 4 best case\n");
								sum += num4ContNonBlock;
							}
							// If up right is blank or down left is blank
							else if (
									(i + 4 < width && j + 4 < width && board[i + 4, j + 4] == 0) ||
									(i - 1 >= 0 && j - 1 >= 0 && board[i - 1, j - 1] == 0)
									)
							{
								//Debug.Log("Detect 4 normal case\n");
								sum += num4Cont;
							}
						}
						else if (count == 5)
						{
							sum += num5Cont;
						}
					}

					// Down right continuation
					copyI = i;
					copyJ = j;
					count = 1;

					while (copyI + 1 < width && copyJ - 1 >= 0 && board[copyI + 1, copyJ - 1] == board[i, j])
					{
						count++;
						copyI++;
						copyJ--;
					}


					if ((i - 1 >= 0 && j + 1 < height && board[i, j] != board[i - 1, j + 1]) || i == 0 || j == 0)
					{
						if (count == 2)
						{
							if (// If 3 down right is blank
								(i - 3 >= 0 && j + 3 < width && board[i - 3, j + 3] == 0 && board[i - 2, j + 2] == 0 && board[i - 1, j + 1] == 0) ||
								// If two down right and one up left is blank
								(i - 2 >= 0 && j + 2 < width && board[i - 2, j + 2] == 0 && board[i - 1, j + 1] == 0 && i + 2 < width && j - 2 >= 0 && board[i + 2, j - 2] == 0) ||
								// If one down right and two up left is blank
								(i - 1 >= 0 && j + 1 < width && board[i - 1, j + 1] == 0 && i + 3 < width && j - 3 >= 0 && board[i + 2, j - 2] == 0 && board[i + 3, j - 3] == 0) ||
								// If 3 up left is blank
								(i + 4 < width && j - 4 >=0 && board[i + 2, j - 2] == 0 && board[i + 3, j - 3] == 0 && board[i + 4, j - 4] == 0)
								)
							{
								sum += num2Cont;
							}
						}
						else if (count == 3)
						{
							if (// If down right is blank and up left is blank
								(i - 1 >= 0 && j + 1 < width && board[i - 1, j + 1] == 0 && i + 3 < width && j - 3 >0 && board[i + 3, j - 3] == 0) )
							{
								sum += num3ContNonBlock;
							}
							else if(
								// If two up left is blank
								(i - 2 >= 0 && j + 2 < width && board[i - 2, j + 2] == 0 && board[i - 1, j + 1] == 0) ||
								// If two down right is blank
								(i + 4 < width && j - 4 >= 0 && board[i + 3, j - 3] == 0 && board[i + 4, j - 4] == 0))
                            {
								sum += num3Cont;
							}
						}
						else if (count == 4)
						{
							//Debug.Log("Detect 4\n");
							if (// If down right is blank and up left is blank
								i - 1 >= 0 && j + 1 < width && board[i - 1, j + 1] == 0 && i + 4 < width && j - 4 >=0 && board[i + 4, j - 4] == 0)
							{
								//Debug.Log("Detect 4 best case\n");
								sum += num4ContNonBlock;
							}
							// If down right is blank or up left is blank
							else if (
									(i + 4 < width && j - 4 >= 0 && board[i + 4, j - 4] == 0) ||
									(i - 1 >= 0 && j + 1 < width && board[i - 1, j + 1] == 0)
									)
							{
								//Debug.Log("Detect 4 normal case\n");
								sum += num4Cont;
							}
						}
						else if (count == 5)
						{
							sum += num5Cont;
						}
					}
				}
			}
		}

		return sum;
	}

	int totalPointCheckRangeAdvance(int[,] board, int numToCheck)
	{
		int num2Cont = 2;
		int num3Cont = 5;
		int num3ContNonBlock = 10;
		int num4Cont = 7;
		int num4ContNonBlock = 900;
		int num5Cont = 100000;
		int sum = 0;

		for (int i = 0; i < width; i++)
		{
			for (int j = 0; j < height; j++)
			{
				if (board[i, j] == numToCheck)
				{
					// Count at each position
					int count3ContNonBlock = 0;
					int count4Cont = 0;

					// Right continuation
					int copyJ = j;
					int count = 1;

					while (copyJ + 1 < width && board[i, copyJ + 1] == board[i, j])
					{
						count++;
						copyJ++;
					}


					if ((j - 1 >= 0 && board[i, j] != board[i, j - 1]) || j == 0)
					{
						if (count == 2)
						{
							if (// If 3 left is blank
								(j - 3 >= 0 && board[i, j - 3] == 0 && board[i, j - 2] == 0 && board[i, j - 1] == 0) ||
								// If two left and one right is blank
								(j - 2 >= 0 && board[i, j - 2] == 0 && board[i, j - 1] == 0 && j + 2 < width && board[i, j + 2] == 0) ||
								// If one left and two right is blank
								(j - 1 >= 0 && board[i, j - 1] == 0 && j + 3 < width && board[i, j + 2] == 0 && board[i, j + 3] == 0) ||
								// If 3 right is blank
								(j + 4 < width && board[i, j + 2] == 0 && board[i, j + 3] == 0 && board[i, j + 4] == 0)
								)
							{
								sum += num2Cont;
							}
						}
						else if (count == 3)
						{
							if (// If left is blank and right is blank
								(j - 1 >= 0 && board[i, j - 1] == 0 && j + 3 < width && board[i, j + 3] == 0))
							{
								sum += num3ContNonBlock;
								count3ContNonBlock++;
							}
							else if (
								// If two left is blank
								(j - 2 >= 0 && board[i, j - 2] == 0 && board[i, j - 1] == 0) ||
								// If two right is blank
								(j + 4 < width && board[i, j + 3] == 0 && board[i, j + 4] == 0))
							{
								sum += num3Cont;
							}
						}
						else if (count == 4)
						{
							//Debug.Log("Detect 4\n");
							if (// If left is blank and right is blank
								j - 1 >= 0 && board[i, j - 1] == 0 && j + 4 < width && board[i, j + 4] == 0)
							{
								//Debug.Log("Detect 4 best case\n");
								sum += num4ContNonBlock;
							}
							// If left is blank or right is blank
							else if (
									(j + 4 < width && board[i, j + 4] == 0) ||
									(j - 1 >= 0 && board[i, j - 1] == 0)
									)
							{
								//Debug.Log("Detect 4 normal case\n");
								count4Cont++;
								sum += num4Cont;
							}
						}
						else if (count == 5)
						{
							sum += num5Cont;
						}
					}

					// Down continuation
					int copyI = i;
					count = 1;

					while (copyI + 1 < width && board[copyI + 1, j] == board[i, j])
					{
						count++;
						copyI++;
					}


					if ((i - 1 >= 0 && board[i, j] != board[i - 1, j]) || i == 0)
					{
						if (count == 2)
						{
							if (// If 3 down is blank
								(i - 3 >= 0 && board[i - 3, j] == 0 && board[i - 2, j] == 0 && board[i - 1, j] == 0) ||
								// If two down and one up is blank
								(i - 2 >= 0 && board[i - 2, j] == 0 && board[i - 1, j] == 0 && i + 2 < width && board[i + 2, j] == 0) ||
								// If one down and two up is blank
								(i - 1 >= 0 && board[i - 1, j] == 0 && i + 3 < width && board[i + 2, j] == 0 && board[i + 3, j] == 0) ||
								// If 3 up is blank
								(i + 4 < width && board[i + 2, j] == 0 && board[i + 3, j] == 0 && board[i + 4, j] == 0)
								)
							{
								sum += num2Cont;
							}
						}
						else if (count == 3)
						{
							if (// If up is blank and down is blank
								(i - 1 >= 0 && board[i - 1, j] == 0 && i + 3 < width && board[i + 3, j] == 0))
							{
								sum += num3ContNonBlock;
								count3ContNonBlock++;
							}
							else if (
								// If two down is blank
								(i - 2 >= 0 && board[i - 2, j] == 0 && board[i - 1, j] == 0) ||
								// If two up is blank
								(i + 4 < width && board[i + 3, j] == 0 && board[i + 4, j] == 0))
							{
								sum += num3Cont;
							}
						}
						else if (count == 4)
						{
							//Debug.Log("Detect 4\n");
							if (// If up is blank and down is blank
								i - 1 >= 0 && board[i - 1, j] == 0 && i + 4 < width && board[i + 4, j] == 0)
							{
								//Debug.Log("Detect 4 best case\n");
								sum += num4ContNonBlock;
							}
							// If up is blocked or down is blocked
							else if (
									(i + 4 < width && board[i + 4, j] == 0) ||
									(i - 1 >= 0 && board[i - 1, j] == 0)
									)
							{
								//Debug.Log("Detect 4 normal case\n");
								sum += num4Cont;
								count4Cont++;
							}
						}
						else if (count == 5)
						{
							sum += num5Cont;
						}
					}

					// Up right continuation
					copyI = i;
					copyJ = j;
					count = 1;

					while (copyI + 1 < width && copyJ + 1 < height && board[copyI + 1, copyJ + 1] == board[i, j])
					{
						count++;
						copyI++;
						copyJ++;
					}


					if ((i - 1 >= 0 && j - 1 >= 0 && board[i, j] != board[i - 1, j - 1]) || i == 0 || j == 0)
					{
						if (count == 2)
						{
							if (// If 3 down left is blank
								(i - 3 >= 0 && j - 3 >= 0 && board[i - 3, j - 3] == 0 && board[i - 2, j - 2] == 0 && board[i - 1, j - 1] == 0) ||
								// If two down left and one up right is blank
								(i - 2 >= 0 && j - 2 >= 0 && board[i - 2, j - 2] == 0 && board[i - 1, j - 1] == 0 && i + 2 < width && j + 2 < width && board[i + 2, j + 2] == 0) ||
								// If one down left and two up right is blank
								(i - 1 >= 0 && j - 1 >= 0 && board[i - 1, j - 1] == 0 && i + 3 < width && j + 3 < width && board[i + 2, j + 2] == 0 && board[i + 3, j + 3] == 0) ||
								// If 3 up right is blank
								(i + 4 < width && j + 4 < width && board[i + 2, j + 2] == 0 && board[i + 3, j + 3] == 0 && board[i + 4, j + 4] == 0)
								)
							{
								sum += num2Cont;
							}
						}
						else if (count == 3)
						{
							if (// If up right is blank and down left is blank
								(i - 1 >= 0 && j - 1 >= 0 && board[i - 1, j - 1] == 0 && i + 3 < width && j + 3 < width && board[i + 3, j + 3] == 0))
							{
								sum += num3ContNonBlock;count3ContNonBlock++;
							}
							else if (
								// If two down left is blank
								(i - 2 >= 0 && j - 2 >= 0 && board[i - 2, j - 2] == 0 && board[i - 1, j - 1] == 0) ||
								// If two up right is blank
								(i + 4 < width && j + 4 < width && board[i + 3, j + 3] == 0 && board[i + 4, j + 4] == 0))
							{
								sum += num3Cont;
							}
						}
						else if (count == 4)
						{
							//Debug.Log("Detect 4\n");
							if (// If up right is blank and down is blank
								i - 1 >= 0 && j - 1 >= 0 && board[i - 1, j - 1] == 0 && i + 4 < width && j + 4 < width && board[i + 4, j + 4] == 0)
							{
								//Debug.Log("Detect 4 best case\n");
								sum += num4ContNonBlock;
							}
							// If up right is blank or down left is blank
							else if (
									(i + 4 < width && j + 4 < width && board[i + 4, j + 4] == 0) ||
									(i - 1 >= 0 && j - 1 >= 0 && board[i - 1, j - 1] == 0)
									)
							{
								//Debug.Log("Detect 4 normal case\n");
								sum += num4Cont;
								count4Cont++;
							}
						}
						else if (count == 5)
						{
							sum += num5Cont;
						}
					}

					// Down right continuation
					copyI = i;
					copyJ = j;
					count = 1;

					while (copyI + 1 < width && copyJ - 1 >= 0 && board[copyI + 1, copyJ - 1] == board[i, j])
					{
						count++;
						copyI++;
						copyJ--;
					}


					if ((i - 1 >= 0 && j + 1 < height && board[i, j] != board[i - 1, j + 1]) || i == 0 || j == 0)
					{
						if (count == 2)
						{
							if (// If 3 down right is blank
								(i - 3 >= 0 && j + 3 < width && board[i - 3, j + 3] == 0 && board[i - 2, j + 2] == 0 && board[i - 1, j + 1] == 0) ||
								// If two down right and one up left is blank
								(i - 2 >= 0 && j + 2 < width && board[i - 2, j + 2] == 0 && board[i - 1, j + 1] == 0 && i + 2 < width && j - 2 >= 0 && board[i + 2, j - 2] == 0) ||
								// If one down right and two up left is blank
								(i - 1 >= 0 && j + 1 < width && board[i - 1, j + 1] == 0 && i + 3 < width && j - 3 >= 0 && board[i + 2, j - 2] == 0 && board[i + 3, j - 3] == 0) ||
								// If 3 up left is blank
								(i + 4 < width && j - 4 >= 0 && board[i + 2, j - 2] == 0 && board[i + 3, j - 3] == 0 && board[i + 4, j - 4] == 0)
								)
							{
								sum += num2Cont;
							}
						}
						else if (count == 3)
						{
							if (// If down right is blank and up left is blank
								(i - 1 >= 0 && j + 1 < width && board[i - 1, j + 1] == 0 && i + 3 < width && j - 3 > 0 && board[i + 3, j - 3] == 0))
							{
								sum += num3ContNonBlock;
								count3ContNonBlock++;
							}
							else if (
								// If two up left is blank
								(i - 2 >= 0 && j + 2 < width && board[i - 2, j + 2] == 0 && board[i - 1, j + 1] == 0) ||
								// If two down right is blank
								(i + 4 < width && j - 4 >= 0 && board[i + 3, j - 3] == 0 && board[i + 4, j - 4] == 0))
							{
								sum += num3Cont;
							}
						}
						else if (count == 4)
						{
							//Debug.Log("Detect 4\n");
							if (// If down right is blank and up left is blank
								i - 1 >= 0 && j + 1 < width && board[i - 1, j + 1] == 0 && i + 4 < width && j - 4 >= 0 && board[i + 4, j - 4] == 0)
							{
								//Debug.Log("Detect 4 best case\n");
								sum += num4ContNonBlock;
							}
							// If down right is blank or up left is blank
							else if (
									(i + 4 < width && j - 4 >= 0 && board[i + 4, j - 4] == 0) ||
									(i - 1 >= 0 && j + 1 < width && board[i - 1, j + 1] == 0)
									)
							{
								//Debug.Log("Detect 4 normal case\n");
								sum += num4Cont;
								count4Cont++;
							}
						}
						else if (count == 5)
						{
							sum += num5Cont;
						}
					}

					if(count4Cont + count3ContNonBlock >= 2)
                    {
						sum += 500;
                    }
				}
			}
		}

		return sum;
	}

	int totalPointOpponent45(int[,] board, int numToCheck)
	{
		int num4Cont = 10;
		int num4ContNonBlock = 850;
		int num5Cont = 10000;
		int sum = 0;

		for (int i = 0; i < width; i++)
		{
			for (int j = 0; j < height; j++)
			{
				if (board[i, j] == numToCheck)
				{
					// Right continuation
					int copyJ = j;
					int count = 1;

					while (copyJ + 1 < width && board[i, copyJ + 1] == board[i, j])
					{
						count++;
						copyJ++;
					}


					if ((j - 1 >= 0 && board[i, j] != board[i, j - 1]) || j == 0)
					{
						if (count == 4)
						{
							//Debug.Log("Detect 4\n");
							if (// If left is blank and right is blank
								j - 1 >= 0 && board[i, j - 1] == 0 && j + 4 < width && board[i, j + 4] == 0)
							{
								//Debug.Log("Detect opponent 4 best case\n");
								sum += num4ContNonBlock;
							}
							// If left is blank or right is blank
							else if (
									(j + 4 < width && board[i, j + 4] == 0) ||
									(j - 1 >= 0 && board[i, j - 1] == 0)
									)
							{
								//Debug.Log("Detect opponent 4 normal case\n");
								sum += num4Cont;
							}
						}
						else if (count == 5)
						{
							sum += num5Cont;
						}
					}

					// Down continuation
					int copyI = i;
					count = 1;

					while (copyI + 1 < width && board[copyI + 1, j] == board[i, j])
					{
						count++;
						copyI++;
					}


					if ((i - 1 >= 0 && board[i, j] != board[i - 1, j]) || i == 0)
					{
						if (count == 4)
						{
							//Debug.Log("Detect 4\n");
							if (// If up is blank and down is blank
								i - 1 >= 0 && board[i - 1, j] == 0 && i + 4 < width && board[i + 4, j] == 0)
							{
								//Debug.Log("Detect opponent 4 best case\n");
								sum += num4ContNonBlock;
							}
							// If up is blocked or down is blocked
							else if (
									(i + 4 < width && board[i + 4, j] == 0) ||
									(i - 1 >= 0 && board[i - 1, j] == 0)
									)
							{
								//Debug.Log("Detect opponent 4 normal case\n");
								sum += num4Cont;
							}
						}
						else if (count == 5)
						{
							sum += num5Cont;
						}
					}

					// Up right continuation
					copyI = i;
					copyJ = j;
					count = 1;

					while (copyI + 1 < width && copyJ + 1 < height && board[copyI + 1, copyJ + 1] == board[i, j])
					{
						count++;
						copyI++;
						copyJ++;
					}


					if ((i - 1 >= 0 && j - 1 >= 0 && board[i, j] != board[i - 1, j - 1]) || i == 0 || j == 0)
					{
						if (count == 4)
						{
							//Debug.Log("Detect 4\n");
							if (// If up right is blank and down is blank
								i - 1 >= 0 && j - 1 >= 0 && board[i - 1, j - 1] == 0 && i + 4 < width && j + 4 < width && board[i + 4, j + 4] == 0)
							{
								//Debug.Log("Detect opponent 4 best case\n");
								sum += num4ContNonBlock;
							}
							// If up right is blank or down left is blank
							else if (
									(i + 4 < width && j + 4 < width && board[i + 4, j + 4] == 0) ||
									(i - 1 >= 0 && j - 1 >= 0 && board[i - 1, j - 1] == 0)
									)
							{
								//Debug.Log("Detect opponent 4 normal case\n");
								sum += num4Cont;
							}
						}
						else if (count == 5)
						{
							sum += num5Cont;
						}
					}

					// Down right continuation
					copyI = i;
					copyJ = j;
					count = 1;

					while (copyI + 1 < width && copyJ - 1 >= 0 && board[copyI + 1, copyJ - 1] == board[i, j])
					{
						count++;
						copyI++;
						copyJ--;
					}


					if ((i - 1 >= 0 && j + 1 < height && board[i, j] != board[i - 1, j + 1]) || i == 0 || j == 0)
					{
						if (count == 4)
						{
							//Debug.Log("Detect 4\n");
							if (// If down right is blank and up left is blank
								i - 1 >= 0 && j + 1 < width && board[i - 1, j + 1] == 0 && i + 4 < width && j - 4 >=0 && board[i + 4, j - 4] == 0)
							{
								//Debug.Log("Detect opponent 4 best case\n");
								sum += num4ContNonBlock;
							}
							// If down right is blank or up left is blank
							else if (
									(i + 4 < width && j - 4 >= 0 && board[i + 4, j - 4] == 0) ||
									(i - 1 >= 0 && j + 1 < width && board[i - 1, j + 1] == 0)
									)
							{
								///Debug.Log("Detect opponent 4 normal case\n");
								sum += num4Cont;
							}
						}
						else if (count == 5)
						{
							sum += num5Cont;
						}
					}
				}
			}
		}

		return sum;
	}

	int totalPointOpponentAdvance(int[,] board, int numToCheck)
	{
		int num2Cont = 2;
		int num3Cont = 5;
		int num3ContNonBlock = 10;
		int num4Cont = 7;
		int num4ContNonBlock = 900;
		int num5Cont = 100000;
		int sum = 0;

		for (int i = 0; i < width; i++)
		{
			for (int j = 0; j < height; j++)
			{
				if (board[i, j] == numToCheck)
				{
					// Count at each position
					int count3ContNonBlock = 0;
					int count4Cont = 0;

					// Right continuation
					int copyJ = j;
					int count = 1;

					while (copyJ + 1 < width && board[i, copyJ + 1] == board[i, j])
					{
						count++;
						copyJ++;
					}


					if ((j - 1 >= 0 && board[i, j] != board[i, j - 1]) || j == 0)
					{
						if (count == 2)
						{
							if (// If 3 left is blank
								(j - 3 >= 0 && board[i, j - 3] == 0 && board[i, j - 2] == 0 && board[i, j - 1] == 0) ||
								// If two left and one right is blank
								(j - 2 >= 0 && board[i, j - 2] == 0 && board[i, j - 1] == 0 && j + 2 < width && board[i, j + 2] == 0) ||
								// If one left and two right is blank
								(j - 1 >= 0 && board[i, j - 1] == 0 && j + 3 < width && board[i, j + 2] == 0 && board[i, j + 3] == 0) ||
								// If 3 right is blank
								(j + 4 < width && board[i, j + 2] == 0 && board[i, j + 3] == 0 && board[i, j + 4] == 0)
								)
							{
								sum += num2Cont;
							}
						}
						else if (count == 3)
						{
							if (// If left is blank and right is blank
								(j - 1 >= 0 && board[i, j - 1] == 0 && j + 3 < width && board[i, j + 3] == 0))
							{
								sum += num3ContNonBlock;
								count3ContNonBlock++;
							}
							else if (
								// If two left is blank
								(j - 2 >= 0 && board[i, j - 2] == 0 && board[i, j - 1] == 0) ||
								// If two right is blank
								(j + 4 < width && board[i, j + 3] == 0 && board[i, j + 4] == 0))
							{
								sum += num3Cont;
							}
						}
						else if (count == 4)
						{
							//Debug.Log("Detect 4\n");
							if (// If left is blank and right is blank
								j - 1 >= 0 && board[i, j - 1] == 0 && j + 4 < width && board[i, j + 4] == 0)
							{
								//Debug.Log("Detect 4 best case\n");
								sum += num4ContNonBlock;
							}
							// If left is blank or right is blank
							else if (
									(j + 4 < width && board[i, j + 4] == 0) ||
									(j - 1 >= 0 && board[i, j - 1] == 0)
									)
							{
								//Debug.Log("Detect 4 normal case\n");
								count4Cont++;
								sum += num4Cont;
							}
						}
						else if (count == 5)
						{
							sum += num5Cont;
						}
					}

					// Down continuation
					int copyI = i;
					count = 1;

					while (copyI + 1 < width && board[copyI + 1, j] == board[i, j])
					{
						count++;
						copyI++;
					}


					if ((i - 1 >= 0 && board[i, j] != board[i - 1, j]) || i == 0)
					{
						if (count == 2)
						{
							if (// If 3 down is blank
								(i - 3 >= 0 && board[i - 3, j] == 0 && board[i - 2, j] == 0 && board[i - 1, j] == 0) ||
								// If two down and one up is blank
								(i - 2 >= 0 && board[i - 2, j] == 0 && board[i - 1, j] == 0 && i + 2 < width && board[i + 2, j] == 0) ||
								// If one down and two up is blank
								(i - 1 >= 0 && board[i - 1, j] == 0 && i + 3 < width && board[i + 2, j] == 0 && board[i + 3, j] == 0) ||
								// If 3 up is blank
								(i + 4 < width && board[i + 2, j] == 0 && board[i + 3, j] == 0 && board[i + 4, j] == 0)
								)
							{
								sum += num2Cont;
							}
						}
						else if (count == 3)
						{
							if (// If up is blank and down is blank
								(i - 1 >= 0 && board[i - 1, j] == 0 && i + 3 < width && board[i + 3, j] == 0))
							{
								sum += num3ContNonBlock;
								count3ContNonBlock++;
							}
							else if (
								// If two down is blank
								(i - 2 >= 0 && board[i - 2, j] == 0 && board[i - 1, j] == 0) ||
								// If two up is blank
								(i + 4 < width && board[i + 3, j] == 0 && board[i + 4, j] == 0))
							{
								sum += num3Cont;
							}
						}
						else if (count == 4)
						{
							//Debug.Log("Detect 4\n");
							if (// If up is blank and down is blank
								i - 1 >= 0 && board[i - 1, j] == 0 && i + 4 < width && board[i + 4, j] == 0)
							{
								//Debug.Log("Detect 4 best case\n");
								sum += num4ContNonBlock;
							}
							// If up is blocked or down is blocked
							else if (
									(i + 4 < width && board[i + 4, j] == 0) ||
									(i - 1 >= 0 && board[i - 1, j] == 0)
									)
							{
								//Debug.Log("Detect 4 normal case\n");
								sum += num4Cont;
								count4Cont++;
							}
						}
						else if (count == 5)
						{
							sum += num5Cont;
						}
					}

					// Up right continuation
					copyI = i;
					copyJ = j;
					count = 1;

					while (copyI + 1 < width && copyJ + 1 < height && board[copyI + 1, copyJ + 1] == board[i, j])
					{
						count++;
						copyI++;
						copyJ++;
					}


					if ((i - 1 >= 0 && j - 1 >= 0 && board[i, j] != board[i - 1, j - 1]) || i == 0 || j == 0)
					{
						if (count == 2)
						{
							if (// If 3 down left is blank
								(i - 3 >= 0 && j - 3 >= 0 && board[i - 3, j - 3] == 0 && board[i - 2, j - 2] == 0 && board[i - 1, j - 1] == 0) ||
								// If two down left and one up right is blank
								(i - 2 >= 0 && j - 2 >= 0 && board[i - 2, j - 2] == 0 && board[i - 1, j - 1] == 0 && i + 2 < width && j + 2 < width && board[i + 2, j + 2] == 0) ||
								// If one down left and two up right is blank
								(i - 1 >= 0 && j - 1 >= 0 && board[i - 1, j - 1] == 0 && i + 3 < width && j + 3 < width && board[i + 2, j + 2] == 0 && board[i + 3, j + 3] == 0) ||
								// If 3 up right is blank
								(i + 4 < width && j + 4 < width && board[i + 2, j + 2] == 0 && board[i + 3, j + 3] == 0 && board[i + 4, j + 4] == 0)
								)
							{
								sum += num2Cont;
							}
						}
						else if (count == 3)
						{
							if (// If up right is blank and down left is blank
								(i - 1 >= 0 && j - 1 >= 0 && board[i - 1, j - 1] == 0 && i + 3 < width && j + 3 < width && board[i + 3, j + 3] == 0))
							{
								sum += num3ContNonBlock; count3ContNonBlock++;
							}
							else if (
								// If two down left is blank
								(i - 2 >= 0 && j - 2 >= 0 && board[i - 2, j - 2] == 0 && board[i - 1, j - 1] == 0) ||
								// If two up right is blank
								(i + 4 < width && j + 4 < width && board[i + 3, j + 3] == 0 && board[i + 4, j + 4] == 0))
							{
								sum += num3Cont;
							}
						}
						else if (count == 4)
						{
							//Debug.Log("Detect 4\n");
							if (// If up right is blank and down is blank
								i - 1 >= 0 && j - 1 >= 0 && board[i - 1, j - 1] == 0 && i + 4 < width && j + 4 < width && board[i + 4, j + 4] == 0)
							{
								//Debug.Log("Detect 4 best case\n");
								sum += num4ContNonBlock;
							}
							// If up right is blank or down left is blank
							else if (
									(i + 4 < width && j + 4 < width && board[i + 4, j + 4] == 0) ||
									(i - 1 >= 0 && j - 1 >= 0 && board[i - 1, j - 1] == 0)
									)
							{
								//Debug.Log("Detect 4 normal case\n");
								sum += num4Cont;
								count4Cont++;
							}
						}
						else if (count == 5)
						{
							sum += num5Cont;
						}
					}

					// Down right continuation
					copyI = i;
					copyJ = j;
					count = 1;

					while (copyI + 1 < width && copyJ - 1 >= 0 && board[copyI + 1, copyJ - 1] == board[i, j])
					{
						count++;
						copyI++;
						copyJ--;
					}


					if ((i - 1 >= 0 && j + 1 < height && board[i, j] != board[i - 1, j + 1]) || i == 0 || j == 0)
					{
						if (count == 2)
						{
							if (// If 3 down right is blank
								(i - 3 >= 0 && j + 3 < width && board[i - 3, j + 3] == 0 && board[i - 2, j + 2] == 0 && board[i - 1, j + 1] == 0) ||
								// If two down right and one up left is blank
								(i - 2 >= 0 && j + 2 < width && board[i - 2, j + 2] == 0 && board[i - 1, j + 1] == 0 && i + 2 < width && j - 2 >= 0 && board[i + 2, j - 2] == 0) ||
								// If one down right and two up left is blank
								(i - 1 >= 0 && j + 1 < width && board[i - 1, j + 1] == 0 && i + 3 < width && j - 3 >= 0 && board[i + 2, j - 2] == 0 && board[i + 3, j - 3] == 0) ||
								// If 3 up left is blank
								(i + 4 < width && j - 4 >= 0 && board[i + 2, j - 2] == 0 && board[i + 3, j - 3] == 0 && board[i + 4, j - 4] == 0)
								)
							{
								sum += num2Cont;
							}
						}
						else if (count == 3)
						{
							if (// If down right is blank and up left is blank
								(i - 1 >= 0 && j + 1 < width && board[i - 1, j + 1] == 0 && i + 3 < width && j - 3 > 0 && board[i + 3, j - 3] == 0))
							{
								sum += num3ContNonBlock;
								count3ContNonBlock++;
							}
							else if (
								// If two up left is blank
								(i - 2 >= 0 && j + 2 < width && board[i - 2, j + 2] == 0 && board[i - 1, j + 1] == 0) ||
								// If two down right is blank
								(i + 4 < width && j - 4 >= 0 && board[i + 3, j - 3] == 0 && board[i + 4, j - 4] == 0))
							{
								sum += num3Cont;
							}
						}
						else if (count == 4)
						{
							//Debug.Log("Detect 4\n");
							if (// If down right is blank and up left is blank
								i - 1 >= 0 && j + 1 < width && board[i - 1, j + 1] == 0 && i + 4 < width && j - 4 >= 0 && board[i + 4, j - 4] == 0)
							{
								//Debug.Log("Detect 4 best case\n");
								sum += num4ContNonBlock;
							}
							// If down right is blank or up left is blank
							else if (
									(i + 4 < width && j - 4 >= 0 && board[i + 4, j - 4] == 0) ||
									(i - 1 >= 0 && j + 1 < width && board[i - 1, j + 1] == 0)
									)
							{
								//Debug.Log("Detect 4 normal case\n");
								sum += num4Cont;
								count4Cont++;
							}
						}
						else if (count == 5)
						{
							sum += num5Cont;
						}
					}

					if (count4Cont + count3ContNonBlock >= 2)
					{
						sum += 500;
					}
				}
			}
		}

		return sum;
	}
}
