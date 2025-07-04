using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIDisplay : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] Slider healthSlider;
    [SerializeField] Health playerHealth;

    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] ScoreKeeper score;

    void Awake()
    {
            playerHealth = FindAnyObjectByType<Health>();
            score = FindAnyObjectByType<ScoreKeeper>();
    }
    void Start()
    {
        healthSlider.maxValue = playerHealth.GetHealth();
    }

    void Update()
    {
        healthSlider.value = playerHealth.GetHealth();
        scoreText.text = score.GetCurrentScore().ToString("0000000000");
    }
}
