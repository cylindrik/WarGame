using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;

public class Countries : MonoBehaviour
{
    
    public List<Countries> Adjacents = new List<Countries>(); //countries that are adjacent
    private Vector3 position; // the country current position
    [SerializeField]
    private Renderer meshRenderer;
    
    [SerializeField]
    public GameObject soldierPrefab;

    [SerializeField]
    public GameObject tankPrefab;

    [SerializeField]
    private GameObject antiAerialPrefab;

    [SerializeField]
    private GameObject planePrefab;

    public Color playerColor;
    private string playerName;

    //private int SoldiersAdded = 0;

    //private int TanksAdded = 0;
    private Vector3 CountryPosition;

    [SerializeField] public int SoldiersNum; // number of soldiers
    [SerializeField] public int TankNum; //number of tanks
    [SerializeField] public int AANum; // number of AAs


    private void Start()
    {
        SoldiersNum = 0;
        TankNum = 0;
        AANum = 0;
        CountryPosition = transform.position;
    }

    private void Update()
    {
       /* if (SoldiersNum != 0)
        {
            SoldierInstantiate();
        }
        if (TankNum != 0)
        {
            TankInstantiate();
        }*/
    }

    public void SetMaterialColor(Material color)
    {
        meshRenderer.material = color;
    }

    public void SetPlayerName(string name)
    {
        playerName = name;
    }

    public void SetPlayerColor(Color color)
    {
        playerColor = color;
    }

    public Color GetPlayerColor()
    {
        return playerColor;
    }

    public string GetPlayerName()
    {
        return playerName;
    }

    /*public void SoldierInstantiate()
    {

        while (SoldiersNum != 0 && SoldiersAdded != SoldiersNum)
        {
            Instantiate(soldierPrefab, CountryPosition.normalized, Quaternion.identity);
            SoldiersAdded++;
        }   
    }
    public void TankInstantiate()
    {

        while (TankNum != 0 && TanksAdded != TankNum)
        {
            Instantiate(tankPrefab, CountryPosition.normalized, Quaternion.identity);
            TanksAdded++;
        }

    }*/
    
}
    
        

    



