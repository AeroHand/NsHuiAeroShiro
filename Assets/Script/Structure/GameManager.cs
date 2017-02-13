using UnityEngine;
using System.Collections;

public class GameManager : Singleton<GameManager>
{

    protected GameManager() { }

    //public variables goes here
    public int turn_num = 1;
    
    //resources
    public int food = 10;
    public int iron = 10;
    public int population = 10;
    public int fight = 10;

    //building status
    public bool buildingstatus = false;
    public int buildingtype = 0;

    public int foodefficiency = 2;
    public int ironefficiency = 2;
    public int populationefficiency = 2;
    public int fightefficiency = 2;

    //grid status matrix
    public int[,] buildmatrix = new int[7, 7];
    
    public void NextTurn()
    {
        //turn+1, update all income
        turn_num += 1;
        for (int i = 1; i <= 6; i++)
        {
            for (int j = 1; j <= 6; j++)
            {
                switch (buildmatrix[i,j])
                {
                    case 1:
                        //farm, +food
                        food += foodefficiency;
                        break;
                    case 2:
                        //factory,+iron
                        iron += ironefficiency;
                        break;
                    case 3:
                        //barrack,+fight
                        fight += fightefficiency;
                        break;
                    default:
                        break;
                }
            }
        }


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
