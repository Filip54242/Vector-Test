﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject objectExplosion;
    public GameObject playerExplosion;

    public int scoreValue;
    private LevelManager levelManager;
    private ScoreKeeper scoreKeeper;
    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            levelManager = gameControllerObject.GetComponent<LevelManager>();
            scoreKeeper = gameControllerObject.GetComponent<ScoreKeeper>();
        }
        if (levelManager == null)
        {
            Debug.Log("Cannot find 'GameController' script.");
        }
        if (scoreKeeper == null)
        {
            Debug.Log("Cannot find 'ScoreKeeper' script.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals(gameObject.tag) && gameObject.tag.Equals("Enemy"))
        {
            return;
        }
        if (other.tag.Equals("Boundry"))
        {
            return;
        }
        if (other.tag.Equals("Player"))
        {
            levelManager.GameOver();
        }
        if (other.tag.Equals("PlayerProjectile"))
        {
            scoreKeeper.AddScore(scoreValue);
        }


        Instantiate(objectExplosion, transform.position, transform.rotation);
        Destroy(other.gameObject);
        Destroy(gameObject);



    }
}
