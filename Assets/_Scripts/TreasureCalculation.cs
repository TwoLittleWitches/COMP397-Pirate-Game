using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TreasureCalculation : MonoBehaviour
{
    static TextMeshProUGUI scoreKeeper;
    [SerializeField] static int score = 0;
    private void Awake()
    {
        scoreKeeper = GetComponent<TextMeshProUGUI>();
    }
    public static void AddTreasure()
    {
        score += 100;
        scoreKeeper.text = score.ToString();
    }
}
