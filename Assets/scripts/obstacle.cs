using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Obstacle : MonoBehaviour
{
    public int index;
    private Scene _scene; // Declare the _scene variable
    [SerializeField] TextMeshProUGUI healthText;

    void Awake()
    {
        _scene = SceneManager.GetActiveScene();
        if (PlayerInfo.health >= 0)
        {
            healthText.text = "Health: " + PlayerInfo.health.ToString();
        }
        else
        {
            healthText.text = "Health: 0";
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player")) // Corrected casing of gameObject
        {
            //SceneManager.LoadScene(index);
            PlayerInfo.health--;
            SceneManager.LoadScene(_scene.buildIndex);
        }
        if (PlayerInfo.health <= 0)
        {
            SceneManager.LoadScene(index);
        }
    }
}
