using UnityEngine;
using UnityEngine.SceneManagement;

public class nextlevel : MonoBehaviour
{
    private Scene _scene;
    private void Awake()
    {
        _scene = SceneManager.GetActiveScene();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Corrected casing of gameObject
        {
            SceneManager.LoadScene(_scene.buildIndex + 1);
        }
    }
    public void nextlvl()
    {
        SceneManager.LoadScene(_scene.buildIndex + 1);
    }
}
