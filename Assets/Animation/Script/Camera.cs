using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 5f;
    public Vector2 offset = new Vector2(2f, 1f);

    void LateUpdate()
    {
        if (target == null) return;

        float directionX = target.localScale.x > 0 ? 1f : -1f;

        Vector3 desiredPos = new Vector3(
            target.position.x + offset.x * directionX,
            target.position.y + offset.y,
            transform.position.z
        );

        transform.position = Vector3.Lerp(transform.position, desiredPos, smoothSpeed * Time.deltaTime);
    }
}