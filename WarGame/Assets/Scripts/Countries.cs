using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Countries : MonoBehaviour
{
    
    public List<Countries> Adjacents = new List<Countries>(); //countries that are adjacent
    private Vector3 position; // the country current position
    

    [SerializeField] public int SoldiersNum; // number of soldiers
    [SerializeField] public int TankNum; //number of tanks
    [SerializeField] public int AANum; // number of AAs

    [SerializeField] GameObject Soldiers; //soldiers prefab
    [SerializeField] GameObject Tank; //tanks prefab
    [SerializeField] GameObject AAs; //Anti Aircraft prefab

}
