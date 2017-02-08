using UnityEngine;
using System.Collections;

public class GameManager : Singleton<GameManager>
{

    protected GameManager() { }

    //public variables goes here
    public int turn_num = 1;


    

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
