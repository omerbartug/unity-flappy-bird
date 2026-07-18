using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Bird: MonoBehaviour
{
    public float jumpForce= 7f;
    private Rigidbody2D rb;
    private bool isDead = false;
    public GameObject gameOverPanel;
    

     

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(isDead){
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Jump();
        }
    }

    void Jump(){
        rb.linearVelocity = Vector2.up * jumpForce;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDead) return;

        isDead = true;

        StartCoroutine(GameOver());
    }

     private void OnTriggerEnter2D(Collider2D ColliderObject)
    {
        if(ColliderObject.CompareTag("score"))
        {
            AudioManager.Instance.PlaySFX(AudioManager.Instance.scoreSound);
            ScoreManager.instance.AddScore();
        }
    }

    IEnumerator GameOver()
    {   
        ScoreManager.instance.getScoreBoard();
        gameOverPanel.SetActive(true);
        yield return new WaitForSeconds(1.2f);
        Time.timeScale = 0;
    }

}
