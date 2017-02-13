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

    public Text eventchoice1text;
    public Text eventchoice2text;
    //public variables
    public bool BuildMenuStatus = false;

    public AudioSource adsource;
    public AudioClip click;
    public AudioClip coin;

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
        TurnText.text = "Turn  "+GameManager.Instance.turn_num.ToString();
        adsource.PlayOneShot(click, 3F);
        StartCoroutine(event1system());
    }

    public void onBuildMenuClicked() {
        adsource.PlayOneShot(click, 3F);
        BuildMenuStatus = !BuildMenuStatus;
        BuildMenu.SetActive(BuildMenuStatus);
    }

    IEnumerator event1system()
    {
        yield return new WaitForSeconds(1);
        adsource.PlayOneShot(coin, 3F);
        GameManager.Instance.NextTurn();
        switch (GameManager.Instance.turn_num)
        {
            case 2:
                event1text.text = "One of the adjacent country asked you to exchange 1 population for 10 food, or they will steal you 10 iron.";
                eventchoice1text.text = "Sure!";
                eventchoice2text.text = "Refuse";
                break;
            case 4:
                event1text.text = "Your scientists have just find a super efficient way to tranfer human to 金坷垃 which can increase +1 food per turn per farm.";
                eventchoice1text.text = "DO IT";
                eventchoice2text.text = "No. I wont do that. ";
                break;
            case 6:
                event1text.text = "The electricity got cut off somehow. The major wire is broken what are u gonna do?";
                eventchoice1text.text = "Ignore it.";
                eventchoice2text.text = "Use 2 people to make a human wire";
                break;
            default:
                event1text.text = "a peaceful day. nothing happened.";
                eventchoice1text.text = "ok";
                eventchoice2text.text = "oh yeah";
                break;


        }
        event1();
        
        yield return new WaitForSeconds(2);
    }

    public void event1()
    {
        //show event panel
        event1panel.SetActive(true);
        //change event show text
        
    }

    public void onchoice2click()
    {
        adsource.PlayOneShot(click, 3F);
        switch (GameManager.Instance.turn_num)
        {
            case 2:
                //event1text.text = "One of the adjacent country asked you to exchange 1 population for 10 food, or they will steal you 10 iron.";
                GameManager.Instance.population -= 1;
                GameManager.Instance.food += 10;
                break;
            case 4:
                //event1text.text = "Your scientists have just find a super efficient way to tranfer human to 金坷垃 which can increase +1 food per turn per farm.";
                GameManager.Instance.population -= 1;

                GameManager.Instance.foodefficiency += 1;
                break;
            case 6:
                GameManager.Instance.ironefficiency = 0;
                break;
            default:

                break;


        }
        event1panel.SetActive(false);
    }

    public void onchoice1click()
    {
        adsource.PlayOneShot(click, 3F);
        switch (GameManager.Instance.turn_num)
        {
            case 2:
                GameManager.Instance.iron -= 10; 
                break;
            case 4:

                break;
            case 6:
                GameManager.Instance.population -= 2;
                break;
            default:

                break;


        }
        event1panel.SetActive(false);
    }

}
