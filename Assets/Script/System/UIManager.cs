using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    //public UI
    public Text TurnText;
    public GameObject BuildMenu;


    //public variables
    public bool BuildMenuStatus = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void onNextTurnClicked() {
        //change next turn text
        TurnText.text = "Processing...";
        GameManager.Instance.NextTurn();
    }

    public void onBuildMenuClicked() {
        BuildMenuStatus = !BuildMenuStatus;
        BuildMenu.SetActive(BuildMenuStatus);
    }

    

}
