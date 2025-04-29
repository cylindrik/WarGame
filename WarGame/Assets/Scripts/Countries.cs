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
    private GameObject soldierPrefab;

    [SerializeField]
    private GameObject tankPrefab;

    [SerializeField]
    private GameObject antiAerialPrefab;

    [SerializeField]
    private GameObject planePrefab;

    private Color playerColor;
    private string playerName;

    [SerializeField] public int SoldiersNum; // number of soldiers
    [SerializeField] public int TankNum; //number of tanks
    [SerializeField] public int AANum; // number of AAs

    //[SerializeField] GameObject Soldiers; //soldiers prefab
    //[SerializeField] GameObject Tank; //tanks prefab
    //[SerializeField] GameObject AAs; //Anti Aircraft prefab

    private void Start()
    {
        SoldiersNum = 0;
        TankNum = 0;
        AANum = 0;
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
}
    
        

    



