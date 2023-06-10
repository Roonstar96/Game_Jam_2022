using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum LevelInts
{
    One,
    Two, 
    Three, 
    Four,
    Five,
    Six,
    Seven, 
    Eight
}

public class GameManagerScript : MonoBehaviour
{
    [Header("Current Level")]
    [SerializeField] private LevelInts levels;
    private int _currentLvl;
    private int _nextLvl;

    [Header("Player Exits & spawns")]
    [SerializeField] private GameObject[] _players;
    [SerializeField] private GameObject[] _playerSpawns;
    [SerializeField] private ExitLevelScript _jumpExit;
    [SerializeField] private ExitLevelScript _crouchExit;

    private bool _levelOver;

    private void Awake()
    {
        _players[0].transform.position = _playerSpawns[0].transform.position;
        _players[1].transform.position = _playerSpawns[1].transform.position;
        _levelOver = false;

        switch (levels)
        {
            case (LevelInts.One):
                {
                    _currentLvl = 0;
                    _nextLvl = 1;
                    break;
                }
            case (LevelInts.Two):
                {
                    _currentLvl = 1;
                    _nextLvl = 2;
                    break;
                }
            case (LevelInts.Three):
                {
                    _currentLvl = 2;
                    _nextLvl = 3;
                    break;
                }
            case (LevelInts.Four):
                {
                    _currentLvl = 3;
                    _nextLvl = 4;
                    break;
                }
            case (LevelInts.Five):
                {
                    _currentLvl = 4;
                    _nextLvl = 5;
                    break;
                }
            case (LevelInts.Six):
                {
                    _currentLvl = 5;
                    _nextLvl = 6;
                    break;
                }
            case (LevelInts.Seven):
                {
                    _currentLvl = 6;
                    _nextLvl = 7;
                    break;
                }
            case (LevelInts.Eight):
                {
                    _currentLvl = 7;
                    _nextLvl = 8;
                    break;
                }
        }
    }

    private void FixedUpdate()
    {
        NextLevel();
        RestartLevel();
    }

    private void NextLevel()
    {
        if (_jumpExit.Exiting && _crouchExit.Exiting)
        {
            SceneManager.LoadScene(_nextLvl);
        }
    }

    private void RestartLevel()
    {
        if (Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene(_currentLvl);
        }
    }
}
