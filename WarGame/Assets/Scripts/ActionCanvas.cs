using System.Collections.Generic;
using TMPro;
using Unity.Mathematics.Geometry;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class ActionCanvas : MonoBehaviour
{
    public GameManager Manager;

    public bool attackerSelected = false;

    public bool defenderSelected = false;

    public Countries attackerName;

    public Countries defenderName;

    public bool isAttacking;

    public Countries currentSelectedCountry;

    public List<GameObject> AttackCountries = new List<GameObject>();

    public int maxSelections = 2;

    

    public void SelectObject(GameObject obj)
    {
        // Example selection effect - change color
        obj.GetComponent<Renderer>().material.color = Color.green;
        Debug.Log("Selected: " + obj.name);
    }

    public void DeselectObject(GameObject obj)
    {
        // Example deselection effect - revert color
        obj.GetComponent<Renderer>().material.color = Color.white;
        Debug.Log("Deselected: " + obj.name);
    }

    public void EndTurn() // end of turn management, will happen when the player clicks the end of turn button
    {

        Manager.ActionsCanvas.SetActive(false); // disables all action canvas
        Manager.AttackAction.SetActive(false);
        Manager.numberOfSoldiers = 0;
        Manager.numberOfTanks = 0;
        Manager.TurnCount = Manager.TurnCount + 1;
        Debug.Log(Manager.TurnCount);

        if (Manager.playerOneTurn == true)
        {
            Manager.playerOneTurn = false;
            Manager.TurnCount = Manager.TurnCount++;
            Manager.state = BattleStates.PLAYERTWOTURN;
            Manager.StatusText.text = "Player two's turn";
            AssignTroopsPlayerTwo();
        }
        else if (Manager.playerOneTurn == false)
        {
            Manager.playerOneTurn = true;
            Manager.TurnCount = Manager.TurnCount++;
            Manager.state = BattleStates.PLAYERONETURN;
            Manager.StatusText.text = "Player one's turn";
            AssignTroopsPlayerOne();
        }


    }

    public void AssignTroopsPlayerOne() // assing troops based on the number of countries in a player list, tanks is the total by 4, and soldiers is the total by 2, all rounded down
    {

        if (Manager.TurnCount < 1 && Manager.state == BattleStates.PLAYERONETURN)
        {
            Manager.numberOfSoldiers = Manager.PlayerOneCountries.Count / 2;
            if (Manager.numberOfSoldiers < 1)
            {
                Manager.numberOfSoldiers = 0;
            }
        }
        else if (Manager.TurnCount < 2 && Manager.state == BattleStates.PLAYERONETURN)
        {
            Manager.numberOfSoldiers = Manager.PlayerOneCountries.Count / 2;
            Manager.numberOfTanks = Manager.PlayerOneCountries.Count / 4;
            if (Manager.numberOfSoldiers < 1)
            {
                Manager.numberOfSoldiers = 0;
            }
            else if (Manager.numberOfTanks < 1)
            {
                Manager.numberOfTanks = 0;
            }
        }

    }

    public void AssignTroopsPlayerTwo() // assing troops based on the number of countries in a player list, tanks is the total by 4, and soldiers is the total by 2, all rounded down
    {

        if (Manager.TurnCount < 1 && Manager.state == BattleStates.PLAYERTWOTURN)
        {
            Manager.numberOfSoldiers = Manager.PlayerTwoCountries.Count / 2;
            if (Manager.numberOfSoldiers < 1)
            {
                Manager.numberOfSoldiers = 0;
            }
        }
        else if (Manager.TurnCount < 2 && Manager.state == BattleStates.PLAYERTWOTURN)
        {
            Manager.numberOfSoldiers = Manager.PlayerTwoCountries.Count / 2;
            Manager.numberOfTanks = Manager.PlayerTwoCountries.Count / 4;
            if (Manager.numberOfSoldiers < 1)
            {
                Manager.numberOfSoldiers = 0;
            }
            else if (Manager.numberOfTanks < 1)
            {
                Manager.numberOfTanks = 0;
            }
        }



    }

    public void AddSoldiers()
    {
        if (Manager.playerOneTurn == true && currentSelectedCountry.tag == "PlayerOneCountry")
        {
            if (Manager.numberOfSoldiers != 0)
            {
                currentSelectedCountry.SoldiersNum++;
                Manager.numberOfSoldiers--;
            }
            if (Manager.numberOfSoldiers == 0)
            {
                Debug.Log("No more soldiers to add and you have this amount of soldiers:");
                Debug.Log(Manager.currentCountry.SoldiersNum);
            }
        }
        else if (Manager.playerOneTurn == true && currentSelectedCountry.tag != "PlayerOneCountry")
        {
            Debug.Log("País n é seu");
        }

        if (Manager.playerOneTurn == false && currentSelectedCountry.tag == "PlayerTwoCountry")
        {
            if (Manager.numberOfSoldiers != 0)
            {
                currentSelectedCountry.SoldiersNum++;
                Manager.numberOfSoldiers--;
            }
            if (Manager.numberOfSoldiers == 0)
            {
                Debug.Log("No more soldiers to add and you have this amount of soldiers:");
                Debug.Log(Manager.currentCountry.SoldiersNum);
            }
        }
        else if (Manager.playerOneTurn == false && currentSelectedCountry.tag != "PlayerTwoCountry")
        {
            Debug.Log("País n é seu");
        }

    }

    public void AddTanks()
    {
        if (Manager.playerOneTurn == true && currentSelectedCountry.tag == "PlayerOneCountry")
        {
            if (Manager.numberOfTanks != 0)
            {
                currentSelectedCountry.TankNum++;
                Manager.numberOfTanks--;

            }
            if (Manager.numberOfTanks == 0)
            {
                Debug.Log("No more soldiers to add and you have this amount of tanks:");
                Debug.Log(Manager.currentCountry.TankNum);
            }
        }
        else
        {
            Debug.Log("País n é seu");
        }


        if (Manager.playerOneTurn == false && currentSelectedCountry.tag == "PlayerTwoCountry")
        {
            if (Manager.numberOfTanks != 0)
            {
                currentSelectedCountry.TankNum++;
                Manager.numberOfTanks--;

            }
            if (Manager.numberOfTanks == 0)
            {
                Debug.Log("No more soldiers to add and you have this amount of tanks:");
                Debug.Log(Manager.currentCountry.TankNum);
            }
        }
        else
        {
            Debug.Log("País n é seu");
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

    public void CloseCanvas()
    {
        Manager.ActionsCanvas.SetActive(false); // disables all action canvas
        Manager.AttackAction.SetActive(false);
    }

    public void PlayerAttack()
    {
        Manager.ActionsCanvas.SetActive(false); 
        Manager.AttackAction.SetActive(false);
        isAttacking = true;
      
    }

    public void Attacking()
    {
        bool Adjacent = false;
        attackerName = AttackCountries[0].GetComponent<Countries>();
        defenderName = AttackCountries[1].GetComponent<Countries>();

        if(attackerName.Adjacents.Contains(defenderName))
        {
            Adjacent = true;
        }

        //attackerName.Adjacents.Contains(defenderName);
        Debug.Log(Adjacent);

    }

    public void Attack(GameObject gameObject)
    {
        Debug.Log(attackerName);
        Debug.Log(defenderName);
        
    }
}
