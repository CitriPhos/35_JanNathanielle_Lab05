using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    private float score;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
