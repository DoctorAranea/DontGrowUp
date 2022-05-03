using UnityEngine;

public class ObjectPlayerReaction : MonoBehaviour
{
    private Animator anim;
    private Transform player;
    private Vector3 direction;
    private bool reacted = false;
    [SerializeField] private float speed;

    private void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        direction = new Vector3(Random.Range(-1f, 1f), Random.Range(.3f, .8f), Random.Range(-1f, 1f));
    }

    private void Update()
    {
        if (Vector3.Distance(player.position, transform.position) <= 2f)
        {
            reacted = true;
        }
        Reaction();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + direction.normalized * speed * Time.deltaTime);
    }

    private void Reaction()
    {
        if (reacted)
        {
            transform.position += direction.normalized * speed * Time.deltaTime;
            transform.LookAt(transform.position + direction.normalized * speed * Time.deltaTime);
            if (anim != null)
                anim.SetTrigger("flyAway");
        }
    }
}
