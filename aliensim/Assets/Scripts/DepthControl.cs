using UnityEngine;

public class DepthControl : MonoBehaviour
{
    [SerializeField] float yOffset;

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y + yOffset);
    }
}
