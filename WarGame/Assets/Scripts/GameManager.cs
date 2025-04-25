using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor.Experimental.GraphView;

public enum BattleStates { START, PLAYERONETURN, PLAYERTWOTURN, WON, LOST} // enumerator's gamestates
public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject[] CountriesPrefab; // prefab for the country game object
    [SerializeField] GameObject TroopPrefab; // prefab fr the troops

    public List<GameObject> AllContries = new List<GameObject>();

    public List<GameObject> PlayerOneCountries = new List<GameObject>(); // countries that will be assigned to player one
    public List<GameObject> PlayerTwoCountries = new List<GameObject>(); // countries that will be assigned to player two

    [SerializeField] int NumOfCountries; // number of total contries
    [SerializeField] Transform Player1Troops; // player one troops
    [SerializeField] Transform Player2Troops; // player two troops

   

    public BattleStates state; //enumerator to control game states

    private void Start()
    {
        if (AllContries == null) // if there are no countries in all countries
        {
            CountriesPrefab = GameObject.FindGameObjectsWithTag("NoOwners"); // countries with "NoOwners" tag are saved in the contries prefab array 
        }
        foreach (GameObject Countries in CountriesPrefab)
        {
            AllContries.Add(Countries); // then adds them to the all countries list
        }

        state = BattleStates.START; // defines game state as "START"
        SetUpBattlefield(); // calls set up function
    }

    void SetUpBattlefield() // sets ups battlefield, defining number of countries to go to each player
    {

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
        
        int P2Countries = Mathf.Abs(P1Countries - NumOfCountries); // defines number of countries to player two 
        
        
        for (int i = 0; i < P2Countries; i++)// verifies witch untagged countries arent player one's, adds them to player two list and tags them.
        {
            if (AllContries[i].tag != "PlayerOneCountry" && AllContries[i].tag == "NoOwners")
            {
                PlayerTwoCountries.Add(AllContries[i]);
                AllContries[i].tag = "PlayerTwoCountry";
            }          
        }
        

        state = BattleStates.PLAYERONETURN; // sets battle state to player one turn
    }


}