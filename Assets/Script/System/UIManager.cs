using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    //public UI
    public Text TurnText;
    public GameObject BuildMenu;

    public Text foodnum;
    public Text ironnum;
    public Text populationnum;
    public Text fightnum;

    public GameObject event1panel;
    public Text event1text;

    public GameObject event2panel;

    //public variables
    public bool BuildMenuStatus = false;



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        foodnum.text = GameManager.Instance.food.ToString();
        ironnum.text = GameManager.Instance.iron.ToString();
        populationnum.text = GameManager.Instance.population.ToString();
        fightnum.text = GameManager.Instance.fight.ToString();

    }

    public void onNextTurnClicked() {
        //change next turn text
        TurnText.text = "Processing...";
        
        //StartCoroutine(event1system);
    }

    public void onBuildMenuClicked() {
        BuildMenuStatus = !BuildMenuStatus;
        BuildMenu.SetActive(BuildMenuStatus);
    }

    IEnumerator event1system()
    {
        yield return new WaitForSeconds(2);
        GameManager.Instance.NextTurn();
        yield return new WaitForSeconds(2);
        event1("a peaceful day. nothing happened.");       
    }

    public void event1(string info)
    {
        //show event panel
        event1panel.SetActive(true);
        //change event show text
        event1text.text = info;
    }

    public void onevent1click()
    {
        
    }

    private IEnumerator eventsystem()
    {
        yield return new WaitForSeconds(2);
        GameManager.Instance.NextTurn();
        yield return new WaitForSeconds(2);
        event1("a peaceful day. nothing happened.");
    }

}
