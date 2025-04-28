using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class ActionCanvas : MonoBehaviour
{
    public GameManager Manager;

    public bool attackerSelected = false;

    public bool defenderSelected = false;

    public string attackerName;
    
    public string defenderName;

    public bool isAttacking;

    public bool isAdjacent;

    public string attackerTag;

    public string defenderTag;
    private void Start()
    {
        Manager = gameObject.GetComponent<GameManager>(); // gets the Game manager component
       
    }

  
    public void AddSoldiers() // adds soldiers to an selected country
    {
        if (Manager.IsPlayerOneFirstTurn == true && Manager.currentCountry.tag == "PlayerOneCountry")
        {
            if (Manager.numberOfSoldiers != 0)
            {
                Manager.currentCountry.SoldiersNum += 1;
                Manager.numberOfSoldiers = Manager.numberOfSoldiers - 1;
            }
        }
        else if (Manager.playerOneTurn == true && Manager.currentCountry.tag == "PlayerOneCountry")
        {
            Manager.currentCountry.SoldiersNum += 1;
            Manager.numberOfSoldiers = Manager.numberOfSoldiers - 1;
        }


        if (Manager.IsPlayerTwoFirstTurn == true && Manager.currentCountry.tag == "PlayerTwoCountry")
        {
            if (Manager.numberOfSoldiers != 0)
            {
                Manager.currentCountry.SoldiersNum += 1;
                Manager.numberOfSoldiers = Manager.numberOfSoldiers - 1;
            }
        }

        else if (Manager.PlayerTwoTurn == true && Manager.currentCountry.tag == "PlayerTwoCountry")
        {
            Manager.currentCountry.SoldiersNum += 1;
            Manager.numberOfSoldiers = Manager.numberOfSoldiers - 1;
        }

    }

    public void AddTanks() // adds soldiers to an selected country
    {
  

        if (Manager.IsPlayerTwoFirstTurn == true && Manager.currentCountry.tag == "PlayerTwoCountry")
        {
            if (Manager.numberOfSoldiers != 0)
            {
                Manager.currentCountry.TankNum += 1;
                Manager.numberOfTanks = Manager.numberOfTanks - 1;
            }
        }

        else if (Manager.PlayerTwoTurn == true && Manager.currentCountry.tag == "PlayerTwoCountry")
        {
            Manager.currentCountry.TankNum += 1;
            Manager.numberOfTanks = Manager.numberOfTanks - 1;
        }

    }



    public void EndTurn() // end of turn management, will happen when the player clicks the end of turn button
    {

        Manager.ActionsCanvas.SetActive(false); // disables all action canvas
        Manager.AttackAction.SetActive(false);

        if (Manager.TurnCount == 1) //checks to see if it is the first turn after setup then assgins values for the next player
        {
            Manager.state = BattleStates.PLAYERTWOFIRSTTURN;
            Manager.TurnCount = Manager.TurnCount + 1;
            AssignTroops();
            VictoryCheck();
        }
        if (Manager.TurnCount == 2) // checks to see witch player turn it is, then assign values
        {
            Manager.state = BattleStates.PLAYERONETURN;
            Manager.TurnCount = Manager.TurnCount + 1;
            AssignTroops();
            VictoryCheck();
        }
        if (Manager.TurnCount % 2 != 0) // same
        {
            Manager.TurnCount = Manager.TurnCount + 1;
            Manager.state = BattleStates.PLAYERTWOTURN;
            AssignTroops();
            VictoryCheck();
        }
        if (Manager.TurnCount % 2 == 0) // same
        {
            Manager.TurnCount = Manager.TurnCount + 1;
            Manager.state = BattleStates.PLAYERONETURN;
            AssignTroops();
            VictoryCheck();
        }
    }

    public void AssignTroops() // assing troops based on the number of countries in a player list, tanks is the total by 4, and soldiers is the total by 2, all rounded down
    {
        if(Manager.state == BattleStates.PLAYERONEFIRSTTURN)
        {
            Manager.numberOfSoldiers = (Manager.PlayerOneCountries.Count / 2);
        }
        
        if(Manager.state == BattleStates.PLAYERTWOFIRSTTURN)
        {
            Manager.numberOfSoldiers = (Manager.PlayerTwoCountries.Count / 2);
        }

        if (Manager.state == BattleStates.PLAYERONETURN)
        {
            Manager.numberOfSoldiers = (Manager.PlayerOneCountries.Count / 2);
            Manager.numberOfTanks = (Manager.PlayerOneCountries.Count / 4);
        }
        else if (Manager.state == BattleStates.PLAYERTWOTURN)
        {
            Manager.numberOfSoldiers = (Manager.PlayerTwoCountries.Count / 2);
            Manager.numberOfTanks = (Manager.PlayerTwoCountries.Count / 4);
        }
    }

    private void VictoryCheck() // checks if any player meets the victory requirement,
    {
        if (Manager.PlayerOneCountries.Count >= 10)
        {
            Debug.Log("Player One Wins");
        }
        else if (Manager.PlayerTwoCountries.Count >= 10)
        {
            Debug.Log("Player Two Wins");
        }
    }

    public void PlayerAttack()
    {
        Manager.ActionsCanvas.SetActive(false);
        Manager.AttackAction.SetActive(false);
        isAttacking = true;
        attackerSelected = true;
        defenderSelected = false;
    }

    public void Attack(GameObject gameObject)
    {
        Debug.Log(attackerName);
        Debug.Log(defenderName);
        
    }
}
