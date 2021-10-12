using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    private float score;
    public Text scoreText;

    private float elapsedTime = 20;
    public Text timeText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        // Display time
        elapsedTime -= Time.deltaTime;

        float minutes = Mathf.FloorToInt(elapsedTime / 60);
        float seconds = Mathf.FloorToInt(elapsedTime % 60);
        timeText.text = string.Format("Time: {0:00}:{1:00}", minutes, seconds);

        // Win condition
        if (score >= 60)
        {
            SceneManager.LoadScene("GameWinScene");
        }

        // Lose condition
        if (elapsedTime <= 0)
        {
            SceneManager.LoadScene("GameLoseScene");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Coin"))
        {
            score += 10;
            Destroy(other.gameObject);
            scoreText.text = $"Score: {score}";
        }

        if (other.gameObject.tag.Equals("Water"))
        {
            SceneManager.LoadScene("GameLoseScene");
        }
    }
}
