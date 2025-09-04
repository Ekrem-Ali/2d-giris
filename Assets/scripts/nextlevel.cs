using UnityEngine;
using UnityEngine.SceneManagement;

public class nextlevel : MonoBehaviour
{
    private Scene _scene;
    public int Sceneindex;
    private void Awake()
    {
        _scene = SceneManager.GetActiveScene();
    }
    //sahne geçişlerinde kullandığımız fonksiyon
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Corrected casing of gameObject
        {
            SceneManager.LoadScene(_scene.buildIndex + 1);
        }
    }
    //sahneler arası geçişlerde gamemanager olarak kullandığımız fonksiyon
    public void LoadSceneByIndex()
    {
        //sahnede verdiğimiz index numarasına göre sahne geçişi yapar
        SceneManager.LoadScene(Sceneindex);
        
        //oyun ilk başladığında score değerlerini alır
    }
}
