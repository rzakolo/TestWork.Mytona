using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerWarrior : Warrior
{
    [SerializeField] private GameObject isSelected;
    [SerializeField] private PlayerController playerController;
    private void Start()
    {
        StartSettings();
        enemyTag = "Enemy";
        health = 2;
        playerController = GameObject.Find("Main Camera").GetComponent<PlayerController>();

    }

    private void Update()
    {
        viewPoint = transform.position;
        CheckEnemys();
    }

    public void Select()
    {
        isSelected.SetActive(true);
    }

    public void UnSelect()
    {
        isSelected.SetActive(false);
    }

    private void OnBecameVisible()
    {
        playerController.AddVisibleWarrior(this);
    }

    private void OnBecameInvisible()
    {
        playerController.RemoveInvisibleWarrior(this);
    }
}
