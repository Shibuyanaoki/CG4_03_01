using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{

    public GameObject enemy;
    public GameObject gameOverText;

    public bool IsGameOver()
    {
        return gameOverFlag;
    }

    private bool gameOverFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOverFlag == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("TitleScene");
            }
        }
    }

    private void FixedUpdate()
    {

        if (gameOverFlag == true)
        {
            return;
        }

            int r = Random.Range(0, 50);
        if(r == 0)
        {
            float x = Random.Range(-3.0f, 3.0f);
            Instantiate(enemy, new Vector3(0, 0, 10), Quaternion.identity);

        }
    }

    public void GameOverStart()
    {
        gameOverText.SetActive(true);
        gameOverFlag = true;
    }

}
