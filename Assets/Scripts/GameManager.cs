using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace RainDropGame
{
    public class GameManager : MonoBehaviour
    {
        public int maxTriggers = 5;
        public float playerScore = 0;

        public TextMeshProUGUI pointText; // Reference to the TextMeshPro text component
        private int pointCount = 0; // The current point count

        // Call this method to add a point and update the point text
        public void AddPoint()
        {
            pointCount++;
            UpdatePointText();
        }

        // Call this method to update the point text
        private void UpdatePointText()
        {
            pointText.text = "" + pointCount.ToString();
        }
    }

    

}
