using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalScript : MonoBehaviour
{

    public GameObject gameClearText;
    public static bool isGameClear = false;

    // Start is called before the first frame update
    void Start()
    {
        isGameClear = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GoalScript.isGameClear == true)
        {
            if (Input.GetButtonDown("Jump"))
            {
                SceneManager.LoadScene("TitleScene");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        gameClearText.SetActive(true);
        isGameClear = true;
    }

}

