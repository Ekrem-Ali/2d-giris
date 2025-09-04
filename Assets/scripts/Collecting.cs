using TMPro;
using UnityEngine;

public class Collecting : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] int score = 0;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("elmas"))
        {
            Destroy(collision.gameObject);
            score++;
            audioSource.Play();
            scoreText.text = "Puan: " + score.ToString();
        }
    }
}
