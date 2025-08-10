using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    public Transform a;
    public Transform b;

    
    void Start()
    {
        transform.LookAt(a);
    }

   
    void Update()
    {
        transform.Translate(Vector3.forward * 1 * Time.deltaTime);
    }
    
    void OnTriggerEnter(Collider other)
    {
         if (other.gameObject.CompareTag("a"))
        {
            transform.LookAt(b);
        }
        else if (other.gameObject.CompareTag("b"))
        {
            transform.LookAt(a);
        }
    }
}