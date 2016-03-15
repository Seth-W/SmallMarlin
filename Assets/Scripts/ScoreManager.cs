using UnityEngine;
using System.Collections;
using System;

public class ScoreManager : MonoBehaviour
{
    private static int _score;
    public static int score
    {get { return _score; } }

    void Start()
    {
        _score = 0;
    }

    void OnEnable()
    {
        Fish.fishDeathEvent += OnFishDeathEvent;
    }

    void OnDisable()
    {
        Fish.fishDeathEvent -= OnFishDeathEvent;
    }

    private void OnFishDeathEvent(object sender, InfoEventArgs<int> e)
    {
        _score += e.info;
    }
}
