using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    Monstrum[] _monsters;
    void OnEnable()
    {
        _monsters = FindObjectsOfType<Monstrum>();
    }

    // Update is called once per frame
    void Update()
    {
        if (MonstersAreAllDead()) 
            GoToNextLevel();
    }

    void GoToNextLevel()
    {
        Debug.Log("Další level");
        //SceneManager.LoadScene();
    }

    bool MonstersAreAllDead()
    {
        throw new NotImplementedException();
    }
}
