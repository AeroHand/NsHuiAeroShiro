using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildUIManager : MonoBehaviour {

    public GameObject builduimenu;

    public GameObject buildphantom;

    public Sprite farmsprite;
    public Sprite factorysprite;
    public Sprite barracksprite;

    public void buildfarm() {
        //check resource
        if (GameManager.Instance.iron >= 10)
        {
            
            //activate build phantom
            buildphantom.SetActive(true);
            GameManager.Instance.buildingstatus = true;
            GameManager.Instance.buildingtype = 1;
            buildphantom.GetComponent<SpriteRenderer>().sprite = farmsprite;

            //close buildmenu
            builduimenu.SetActive(false);

        }
        else
        {
            //not enough food
            Debug.Log("not enough iron");
        }
    }

    public void buildfactory()
    {
        //check resource
        if (GameManager.Instance.food >= 10)
        {
            
            //activate build phantom
            buildphantom.SetActive(true);
            GameManager.Instance.buildingstatus = true;
            GameManager.Instance.buildingtype = 2;
            buildphantom.GetComponent<SpriteRenderer>().sprite = factorysprite;

            //close buildmenu
            builduimenu.SetActive(false);

        }
        else
        {
            //not enough food
            Debug.Log("not enough food");
        }
    }

    public void buildbarrack()
    {
        //check resource
        if (GameManager.Instance.iron >= 10 && GameManager.Instance.food >= 10)
        {
            Debug.Log("buildfarm");
            //activate build phantom
            buildphantom.SetActive(true);
            GameManager.Instance.buildingstatus = true;
            GameManager.Instance.buildingtype = 3;
            buildphantom.GetComponent<SpriteRenderer>().sprite = barracksprite;

            //close buildmenu
            builduimenu.SetActive(false);

        }
        else
        {
            //not enough food
            Debug.Log("not enough iron");
        }
    }
}
