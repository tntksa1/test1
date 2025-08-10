using UnityEngine;

public class DPlaytform : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private float DT = 1;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject, DT);
            
        }
    }
}
