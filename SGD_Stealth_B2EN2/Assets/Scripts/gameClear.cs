﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameClear : MonoBehaviour
{
    public Transform playerSpawn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        GameObject.FindGameObjectWithTag("Player").transform.position = playerSpawn.position;

    }
}
