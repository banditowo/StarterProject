using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] private float speed;
    private bool isActive;


    public void Initialize()
    {
        isActive = true;
    }
    void Update()
    {
        if (isActive)
        {
            transform.Translate(transform.forward * speed * Time.deltaTime);
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cube"))
        {
            Destroy(gameObject); 
        }
        
    }
}
