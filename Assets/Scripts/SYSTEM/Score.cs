using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField]
    Text scoreText;

    public int GetScore()
    {
        return int.Parse(scoreText.text);
    }

    public void SetScore(string scoreString)
    {
        scoreText.text = scoreString;
    }
}
