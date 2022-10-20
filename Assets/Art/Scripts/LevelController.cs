using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    private Monstrum[] _monsters;
    [SerializeField]
    private string _nextLevelName;
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
        Debug.Log("Další level: " + _nextLevelName);
        SceneManager.LoadScene(_nextLevelName);
    }

    bool MonstersAreAllDead()
    {
        foreach (Monstrum monstrum in _monsters)
        {
            if (monstrum.gameObject.activeSelf)
                return false;
        }
        return true;
    }
}
