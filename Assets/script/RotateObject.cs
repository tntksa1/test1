using UnityEngine;

public class RotateObject : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 1);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
