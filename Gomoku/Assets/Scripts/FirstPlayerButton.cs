using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPlayerButton : MonoBehaviour
{
    public GameObject gridManager;
    public bool switched = false;

    public void AIGoFirst()
    {
        if (!switched)
        {
            switched = true;
            gridManager.GetComponentInChildren<GridManager>().won = false;
            gridManager.GetComponentInChildren<GridManager>().switchTurn();
        }
    }
}
