using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Animator animator;
    public AudioSource aS;
    public float speed;

    bool up;
    bool down;
    bool left;
    bool right;

    public AudioClip footsteps;
    public AudioClip pop;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        up = true;
        down = true;
        left = true;
        right = true;

        animator = GetComponent<Animator>();
        aS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPos = transform.position;
        if (Input.GetKey(KeyCode.W) && up)
        {
            currentPos.y += speed * Time.deltaTime;
            animator.SetBool("Up", true);
            if (!aS.isPlaying)
            {
                aS.PlayOneShot(footsteps);
            }
        }
            else { animator.SetBool("Up", false); }
        if (Input.GetKey(KeyCode.S) && down)
        {
            currentPos.y -= speed * Time.deltaTime;
            animator.SetBool("Down", true);
            if (!aS.isPlaying)
            {
                aS.PlayOneShot(footsteps);
            }
        }
        else { animator.SetBool("Down", false); }
        if (Input.GetKey(KeyCode.A) && left)
        {
            currentPos.x -= speed * Time.deltaTime;
            animator.SetBool("Left", true);
            if (!aS.isPlaying)
            {
                aS.PlayOneShot(footsteps);
            }
        }
        else { animator.SetBool("Left", false); }
        if (Input.GetKey(KeyCode.D) && right)
        {
            currentPos.x += speed * Time.deltaTime;
            animator.SetBool("Right", true);
            if (!aS.isPlaying)
            {
                aS.PlayOneShot(footsteps);
            }
        }
        else { animator.SetBool("Right", false); }
        transform.position = currentPos;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Up"))
        {
            up = false;
            aS.PlayOneShot(pop);
        }
        if (collision.CompareTag("Down"))
        {
            down = false;
            aS.PlayOneShot(pop);
        }
        if (collision.CompareTag("Left"))
        {
            left = false;
            aS.PlayOneShot(pop);
        }
        if (collision.CompareTag("Right"))
        {
            right = false;
            aS.PlayOneShot(pop);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Up"))
        {
            up = true;
        }
        if (collision.CompareTag("Down"))
        {
            down = true;
        }
        if (collision.CompareTag("Left"))
        {
            left = true;
        }
        if (collision.CompareTag("Right"))
        {
            right = true;
        }
    }

}
