using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class persistSounds : MonoBehaviour
{

    public SpriteRenderer render;
    public AudioClip audio;

    // Update is called once per frame
    void Start()
    {
        render = GetComponent<SpriteRenderer>();
        AudioSource.PlayClipAtPoint(audio, this.gameObject.transform.position);
    }

 
    void OnTriggerEnter2D(Collider2D other)
    {
        render.enabled = false;
    }
}
