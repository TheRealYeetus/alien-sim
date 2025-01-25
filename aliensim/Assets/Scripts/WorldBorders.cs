using UnityEngine;

public class WorldBorders : MonoBehaviour
{
    private void Update()
    {
        print(Time.deltaTime + " " + GetSign(Time.deltaTime));
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check for the player or objects leaving the boundary
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
        {
            // Optionally, teleport them back or destroy them
            Debug.Log(collision.gameObject.name + " left the world bounds!");
            // Example: Teleport back to the center
            Vector2 point = collision.GetContact(0).point;
            Vector2 newPos = collision.transform.position;
            if (Mathf.Abs(point.x - collision.transform.position.x) > 0.4f)
            {
                newPos = new Vector2(-newPos.x - (0.1f * GetSign(newPos.x)), newPos.y);
                print("tp x");
            }
            else if (Mathf.Abs(point.y - collision.transform.position.y) > 0.4f)
            {
                newPos = new Vector2(newPos.x, -newPos.y - (0.1f * GetSign(newPos.y)));
                print("tp y");
            }

            collision.transform.position = newPos;
        }
    }

    float GetSign(float num)
    {
        float ret;
        ret = num * (1 / Mathf.Abs(num));

        return ret;
    }
}
