using UnityEngine;

public class MovingObjectAction : MonoBehaviour
{
    public float velocity = 0;

    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * velocity);
    }
}
