using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputeManager : MonoBehaviour
{

    public GameObject builduimenu;

    public GameObject buildphantom;

    //public prefabs

    public GameObject farmprefab;
    public GameObject factoryprefab;
    public GameObject barrackprefab;

    public GridSystem scriptGridSystem;


    // Use this for initialization
    void Start()
    {
        //some initiation
        for (int i = 1; i <= 5; i++)
        {
            for (int j = 1; j <= 5; j++)
            {
                GameManager.Instance.buildmatrix[i, j] = 0;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("leftclick");
            
            if (GameManager.Instance.buildingstatus)
            {
                switch (GameManager.Instance.buildingtype)
                {
                    case 1:
                        GameManager.Instance.iron -= 10;
                        Instantiate(farmprefab, buildphantom.transform.position, buildphantom.transform.rotation);
                        GameManager.Instance.buildingstatus = false;
                        GameManager.Instance.buildingtype = 0;
                        buildphantom.SetActive(false);
                        GameManager.Instance.buildmatrix[scriptGridSystem.intCurGridX, scriptGridSystem.intCurGridY] = 1;
                        break;
                    case 2:
                        GameManager.Instance.food -= 10;
                        Instantiate(factoryprefab, buildphantom.transform.position, buildphantom.transform.rotation);
                        GameManager.Instance.buildingstatus = false;
                        GameManager.Instance.buildingtype = 0;
                        buildphantom.SetActive(false);
                        GameManager.Instance.buildmatrix[scriptGridSystem.intCurGridX, scriptGridSystem.intCurGridY] = 2;
                        break;
                    case 3:
                        GameManager.Instance.iron -= 10;
                        GameManager.Instance.food -= 10;
                        Instantiate(barrackprefab, buildphantom.transform.position, buildphantom.transform.rotation);
                        GameManager.Instance.buildingstatus = false;
                        GameManager.Instance.buildingtype = 0;
                        buildphantom.SetActive(false);
                        GameManager.Instance.buildmatrix[scriptGridSystem.intCurGridX, scriptGridSystem.intCurGridY] = 3;
                        break;
                    default:
                        break;
                }
            }
        }
        
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("rightclick");
            //cancel all the ui menu
            builduimenu.SetActive(false);
            //cancel building status
            GameManager.Instance.buildingstatus = false;
            GameManager.Instance.buildingtype = 0;
            buildphantom.SetActive(false);

        }
    }
}
