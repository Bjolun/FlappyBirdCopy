using UnityEngine;

public class MoveLevel : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 1.0f;
    void Update()
    {
        transform.position += new Vector3(movementSpeed,0,0) * Time.deltaTime;
    }
}
