using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    //Tiempo total del nivel antes de Game Over
    public float levelTimer = 10f;

    //Tiempo que aumentará al destruir algún barril "TimeUp"
    public float levelTimeIncrease = 2f;

    private string levelName = "Level_SciFi";


    public bool levelComplete;


    void Start()
    {
        Instance = this;
        Debug.Log("El tiempo se agota, ¡date prisa!");
        Debug.Log("Encuentra la tarjeta para poder salir. Algunos barriles te pueden ayudar.");

    }


    void Update()
    {
        if (levelComplete != true)
        {
            if (levelTimer > 0f)
            {
                levelTimer -= Time.deltaTime;
                Debug.Log((int)levelTimer);
            }
            else
            {
                Debug.Log("·········· GAME OVER ··········");
                SceneManager.LoadScene(levelName);
            }
        }
        else
        {
            Debug.Log("·········· ¡CONSEGUISTE LA TARJETA, GANASTE! ··········");
 
        }
    }
    
}
