using UnityEngine;
using System.Collections;

public class GiveHealth : MonoBehaviour
{
    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.name == "Player")
        {
            Destroy(gameObject);
            Movement.playerHealth += 2;
        }
    }
}