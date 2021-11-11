using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    [SerializeField] Text txtScore;
    int score = 0;
    public int Score { get => score; set => score = value; }
    // Update is called once per frame
    void Update()
    {
        txtScore.text = $"Score : {Score}";
    }
}
