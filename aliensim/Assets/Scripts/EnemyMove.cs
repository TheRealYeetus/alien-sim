using UnityEditor;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float aggro;
    [SerializeField] float drag;

    Vector2 targetPos;
    Rigidbody2D rb;
    GameObject player;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        targetPos = transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, player.transform.position - transform.position, aggro, LayerMask.GetMask("Default"));

        if (hit.collider != null)
        {
            if ((player.transform.position - transform.position).magnitude < aggro && hit.transform.gameObject == player)
            {
                targetPos = player.transform.position;
                print("hit");
            }

            print(hit.transform.gameObject.name);
        }

        Vector2 movement = targetPos - new Vector2(transform.position.x, transform.position.y);


        movement = movement.normalized * speed;


        rb.AddForce(movement);
        rb.linearVelocity *= drag;
    }

    private void OnDrawGizmos()
    {
        if (Application.isPlaying)
        {
            Handles.color = Color.yellow;
            Handles.DrawLine(transform.position, targetPos);
            Handles.DrawWireDisc(transform.position, transform.forward, aggro);
            Handles.color = Color.green;
            Handles.DrawLine(transform.position, ((player.transform.position - transform.position).normalized * aggro) + transform.position);
            
        }
    }
}
