using System;
using UnityEngine;
using TMPro; 
public class ScoreCard : MonoBehaviour
{
   private TextMeshProUGUI scoreCardText;
   private int Score = 0;

   private void Awake()
   {
      scoreCardText = GetComponentInChildren<TextMeshProUGUI>();
   }

   private void Start()
   {
      RefreshUI();
   }
   
   public void IncreaseScore(int score)
   { 
      Score += score;
      RefreshUI();
   }

   public void RefreshUI()
   {
      scoreCardText.text = "Score: " + Score;
   }
}
