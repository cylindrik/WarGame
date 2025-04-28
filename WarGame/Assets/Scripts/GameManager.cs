using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor.Experimental.GraphView;
using TMPro;

public enum BattleStates { START, PLAYERONETURN, PLAYERTWOTURN, WON, LOST} // enumerator's gamestates
public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject[] CountriesPrefab; // prefab for the country game object
    public int numberOfSoldiers; // number of soldiers to be given to a player at the end of each turn
    public int numberOfTanks; // number of tanks to be given to a player at the end of each turn
    public bool playerOneTurn; // says if it is player one's turn

    public int TurnCount;

    public TMP_Text StatusText;

    [SerializeField] public GameObject ActionsCanvas; // canvas with actions a player can do in a round
    [SerializeField] public GameObject AttackAction; // Attack button needs to be disabled for first turn

    public List<GameObject> AllContries = new List<GameObject>();

    public List<GameObject> PlayerOneCountries = new List<GameObject>(); // countries that will be assigned to player one
    public List<GameObject> PlayerTwoCountries = new List<GameObject>(); // countries that will be assigned to player two

    [SerializeField] int NumOfCountries; // number of total contries

    public Countries currentCountry;
    public ActionCanvas Actions;

    public BattleStates state; //enumerator to control game states

    private void Start()
    {
        CountriesPrefab = GameObject.FindGameObjectsWithTag("NoOwners"); // gets all countries with "No Owners tag"
        

        foreach (GameObject Countries in CountriesPrefab)
        {
            AllContries.Add(Countries); // then adds them to the all countries list
        }

        state = BattleStates.START; // defines game state as "START"
        SetUpBattlefield(); // calls set up function
    }

    void SetUpBattlefield() // sets ups battlefield, defining number of countries to go to each player
    {

        StatusText.text = "Setting up.";


        for (int i = 0; i < NumOfCountries; i++) // tags all contries as no man's land
        {
            AllContries[i].tag = "NoOwners";
        }
        
        int P1Countries = NumOfCountries / 2; // defines number of countries to player one 

        for (int i = 0; i < P1Countries; i++) // adds countries prefabs to player one list and tags them.
        {
            PlayerOneCountries.Add(AllContries[i]);
            AllContries[i].tag = "PlayerOneCountry";
        }
        
        int P2Countries = NumOfCountries; // assigns the remainer of countries to player two 
        
        
        for (int i = 0; i < P2Countries; i++)// verifies witch untagged countries arent player one's, adds them to player two list and tags them.
        {
            if (AllContries[i].tag != "PlayerOneCountry" && AllContries[i].tag == "NoOwners")
            {
                PlayerTwoCountries.Add(AllContries[i]);
                AllContries[i].tag = "PlayerTwoCountry";
            }          
        }

        playerOneTurn = true;
        state = BattleStates.PLAYERONETURN; // sets battle state to player one turn
        StatusText.text = "Player one's turn";  
        TurnCount = 0;
        Actions.AssignTroopsPlayerOne();
    }


    private void Update()
    {

        if (Input.GetMouseButtonDown(0)) // selects contry that the mouse clicked on.
        {
            RaycastHit raycastHit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out raycastHit, 100f))
            {
                if (raycastHit.transform != null)
                {
                    actionsMenu(raycastHit.transform.gameObject);
                }

            }
        }
        else if (Input.GetMouseButtonDown(1)) // selects contry that the mouse right clicks on.
        {
            RaycastHit raycastHit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out raycastHit, 100f))
            {
                if (raycastHit.transform != null && Actions.isAttacking == true && Actions.defenderSelected == false)
                {


                    Actions.Attack(raycastHit.transform.gameObject);


                }
            }
        }
    }

    private void actionsMenu(GameObject gameObject) // function to call action canvas
    {
        currentCountry = gameObject.GetComponent<Countries>(); // gets the current country component
        Actions.currentSelectedCountry = currentCountry;
        
        if (TurnCount < 2) // checks if it is the player one's first turn, if it is it disables the attack option
        {
            ActionsCanvas.SetActive(true);
            AttackAction.SetActive(false);
        }
        else // after the initial turns, it just displays the full action canvas
        {
            ActionsCanvas.SetActive(true);
            AttackAction.SetActive(true);
        }
    }

}