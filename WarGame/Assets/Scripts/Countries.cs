using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Countries : MonoBehaviour
{
    public List<Countries> Adjacents = new List<Countries>(); //countries that are adjacent
    private Vector3 position; // the country current position

    [SerializeField] int SoldiersNum; // number of soldiers
    [SerializeField] int TankNum; //number of tanks
    [SerializeField] int AANum; // number of AAs

    [SerializeField] GameObject Soldiers; //soldiers prefab
    [SerializeField] GameObject Tank; //tanks prefab
    [SerializeField] GameObject AAs; //Anti Aircraft prefab

    private void Start()
    {
        position = transform.position;
    }
}
