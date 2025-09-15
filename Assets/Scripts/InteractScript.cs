using UnityEngine;

public class InteractScript : MonoBehaviour
{

    public AudioClip sound;
    public AudioSource aS;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        aS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            aS.PlayOneShot(sound);
            GetComponent<Animator>().SetTrigger("Yes");
        }
    }
}
