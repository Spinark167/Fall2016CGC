using UnityEngine;
using System.Collections;

public class TreeBossScript : MonoBehaviour
{

    public GameObject player;

    private Rigidbody2D rb;
    private Animator anim;

    float distToPlayerSqrd = 100f;
    float direction = 1f;
    float health = 10f;


    // Use this for initialization
    void Start()
    {
        //I'm going to actually give this guy code later this is just to see how the animation works with the speed im giving it.
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        anim.SetFloat("Speed", rb.velocity.x * rb.velocity.x);

        distToPlayerSqrd = (player.transform.position.x - gameObject.transform.position.x) * (player.transform.position.x - gameObject.transform.position.x) + (player.transform.position.y - gameObject.transform.position.y) * (player.transform.position.y - gameObject.transform.position.y);
        anim.SetFloat("DistToPlayer", distToPlayerSqrd);

        if (health <= 0)
        {
            Destroy(gameObject);
        }

        if ((player.transform.position.x - gameObject.transform.position.x) >= 0)
        {
            direction = 1f;
            gameObject.transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        if ((player.transform.position.x - gameObject.transform.position.x) < 0)
        {
            direction = -1f;
            gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
        }
        if (distToPlayerSqrd < 400f)
        {
            rb.velocity = new Vector2(2f * direction, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0f, rb.velocity.y);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "FireBall")
        {
            health--;
        }
    }
}
