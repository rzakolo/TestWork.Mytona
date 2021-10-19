using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyWarrior : Warrior
{
    private void Start()
    {
        health = 1;
        viewPoint = transform.position;
        enemyTag = "Player";
        StartSettings();
    }

    // Update is called once per frame
    private void Update()
    {
        CheckEnemys();
    }
}
