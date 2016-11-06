using UnityEngine;
using System.Collections;

public class TreeDisappear : MonoBehaviour
{
    private Animator parentAnim;
    private BoxCollider2D parentBoxCollider2D;
    private AudioSource parentAudioSource;

	void Start ()
    {
        parentAnim = GetComponentInParent<Animator>();
        parentBoxCollider2D = GetComponentInParent<BoxCollider2D>();
        parentAudioSource = GetComponentInParent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //occurs when an the apple is hit by a fireball
        if (other.tag == "FireBall")
        {
            //Destroys apple
            Destroy(gameObject);
            //Start tree disappear animation
            parentAnim.SetBool("AppleDestroyed", true);
            //Sets box collider of tree to inactive
            parentBoxCollider2D.enabled = false;
            //Play sound in in tree's audio source
            parentAudioSource.Play();
        }
    }
}
