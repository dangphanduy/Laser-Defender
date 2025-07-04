using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
public class UIGameOver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;

    void Awake()
    {
      scoreKeeper = FindAnyObjectByType<ScoreKeeper>();  
    }

    void Start()
    {
        scoreText.text = "You Scored:\n" + scoreKeeper.GetCurrentScore();
        
    }

}
