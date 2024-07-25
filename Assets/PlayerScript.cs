using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    private AudioSource audioSource;
    public Rigidbody rd;
    public Animator animator;
    public GameObject bullet;
    public GameObject gameManager;

    private GameManagerScript gameManagerSpript;

    private int bulletTimer = 0;

    Vector3 moveSpeed = new Vector3(5, 10, 5);

    // Start is called before the first frame update
    void Start()
    {
        gameManagerSpript = gameManager.GetComponent<GameManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {


        float stick = Input.GetAxis("Horizontal");

        Vector3 v = rd.velocity;

      if(gameManagerSpript.IsGameOver() == true)
        {
            rd.velocity = new Vector3(0, 0, 0);
            return;
        }

        if (Input.GetKey(KeyCode.RightArrow) || stick > 0)
        {
            //transform.rotation = Quaternion.Euler(0, 90, 0);
            v.x = moveSpeed.x;
            animator.SetBool("mode", true);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || stick < 0)
        {
            v.x = -moveSpeed.x;
        }else if (Input.GetKey(KeyCode.UpArrow))
        {
            v.z = moveSpeed.z;
            animator.SetBool("mode", true);
        }
        else
        {
            v = new Vector3(0, 0, 0);
            animator.SetBool("mode", false);
        }


        rd.velocity = v;

    }

    private void FixedUpdate()
    {

        if (gameManagerSpript.IsGameOver() == true)
        {
            return;
        }

        if (bulletTimer == 0)
        {
            // ’e”­ŽË
            if (Input.GetKey(KeyCode.Space))
            {
                Vector3 position = transform.position;
                position.y += 0.8f;
                position.z = 1.0f;

                Instantiate(bullet, position, Quaternion.identity);

                bulletTimer = 1;

            }
        }else
        {
            bulletTimer++;
            if(bulletTimer > 20)
            {
                bulletTimer = 0;
            }
        }

        
       
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            gameManagerSpript.GameOverStart();
        }
    }

}
