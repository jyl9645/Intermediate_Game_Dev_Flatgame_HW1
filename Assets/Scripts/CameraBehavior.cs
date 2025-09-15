using System;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{

    public GameObject plr;

    private float x_pos;
    private float y_pos;
    public AudioSource aS;

    public AudioClip flowing;
    public AudioClip leaves;
    public AudioClip bush;
    public List<AudioClip> audios = new List<AudioClip>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audios.Add(flowing);
        audios.Add(leaves);
        audios.Add(bush);

        aS = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

        if (!aS.isPlaying)
        {
            aS.PlayOneShot(audios[UnityEngine.Random.Range(0, 2)]);
        }

        x_pos = plr.transform.position.x;
        y_pos = plr.transform.position.y;

        this.transform.position = new Vector3(x_pos, y_pos, this.transform.position.z);
    }
}
