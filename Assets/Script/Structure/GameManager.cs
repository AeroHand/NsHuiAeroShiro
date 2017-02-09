using UnityEngine;
using System.Collections;

public class GameManager : Singleton<GameManager>
{

    protected GameManager() { }

    //public variables goes here
    public int turn_num = 1;
    
    //resources
    public int food = 100;
    public int iron = 100;
    public int population = 10;
    public int fight = 10;

    //building status
    public bool buildingstatus = false;
    public int buildingtype = 0;

    //grid status matrix
    public int[,] buildmatrix = new int[7, 7];
    
    public void NextTurn()
    {
        //turn+1, update all income


    }



    public void replay()
    {
        Application.LoadLevel(1);
    }

    public void lose()
    {
        Application.LoadLevel(2);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
