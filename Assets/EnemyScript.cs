using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private GameObject gameManager;
    private GameManagerScript gameManagerScript;

    int moveSpeed  = 1;

    // Start is called before the first frame update
    void Start()
    {

        // óêêîÇ≈ç∂âEÇ÷
        int r = Random.Range(0, 2);

        if(r == 0)
        {
            transform.rotation = Quaternion.Euler(0, 180 - 30, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180 + 30, 0);
        }

        gameManager = GameObject.Find("GameManager");

        gameManagerScript = gameManager.GetComponent<GameManagerScript>();

    }

    // Update is called once per frame
    void Update()
    {

        if (gameManagerScript.IsGameOver() == true)
        {
            return;
        }

        Vector3 velocity = new Vector3(0, 0, moveSpeed * Time.deltaTime);
        transform.position += transform.rotation * velocity;

        // ç∂âEÇ≈îΩì]
        if (transform.position.x > 4)
        {
            transform.rotation = Quaternion.Euler(0, 180 + 30, 0);
        }

        if(transform.position.x < -4)
        {
            transform.rotation = Quaternion.Euler(0, 180 - 30, 0);
        }

       

    }
}
