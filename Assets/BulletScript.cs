using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public Rigidbody rd;
    Vector3 moveSpeed = new Vector3(5, 10, 5);

    // Start is called before the first frame update
    void Start()
    {
        rd.velocity = new Vector3(0, 0, moveSpeed.z);
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }

}