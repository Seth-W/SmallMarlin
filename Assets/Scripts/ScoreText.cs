using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class ScoreText : MonoBehaviour
{
    Text textField;

    void Start()
    {
        textField = GetComponent<Text>();
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
        textField.text = ScoreManager.score.ToString();
    }
}
