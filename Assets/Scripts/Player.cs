using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Animation thisAnimation;
    public float Velocity;
    private Rigidbody rb;
    void Start()
    {
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector3.up * Velocity;
            thisAnimation.Play();
        }

        if(transform.position.y >= 3.2f)
        {
            transform.position = new Vector3(transform.position.x, 3.2f, transform.position.z);
        }

        if(transform.position.y <= -4.75f)
        {
            SceneManager.LoadScene("GameOver");
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
