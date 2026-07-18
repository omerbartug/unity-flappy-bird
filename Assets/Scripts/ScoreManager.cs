using UnityEngine;
using TMPro;


public class ScoreManager : MonoBehaviour
{

    public static ScoreManager instance;
    public Bird bird;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI highScoreText;

    public Animator animator;
    public Animator animatorGlare1;
    public Animator animatorGlare2;
    public Animator animatorGlare3;
    public Animator animatorGlare4;

    private int score = 0;
    private int highScore;
    

    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        scoreText.text = score.ToString();
    }

    void Update()
    {
        
    }

    void Awake()
    {
        if (instance == null) 
        {
            instance = this;
        }
    }

    public void AddScore()
    {
        score++;
        scoreText.text = score.ToString();
        animator.SetTrigger("Pop");
        animatorGlare1.SetTrigger("Pop");
        animatorGlare2.SetTrigger("Pop");
        animatorGlare3.SetTrigger("Pop");
        animatorGlare4.SetTrigger("Pop");
    }

    public void CheckHighScore()
    {
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }
    }

    public int getHighScore(){
        return highScore;
    }

    public void getScoreBoard()
    {
        scoreText.enabled = false;
        if (finalScoreText != null && highScoreText != null)
        {
            finalScoreText.text = score.ToString();
            CheckHighScore();
            highScoreText.text = highScore.ToString();
        }
        
    }
    
}
