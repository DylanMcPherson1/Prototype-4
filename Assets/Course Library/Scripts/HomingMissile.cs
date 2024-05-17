using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissile : MonoBehaviour
{
    public float speed;
    public bool homing;
    private GameObject[] enemy;
    public Rigidbody homingRb;


    // Start is called before the first frame update
    void Awake()
    {
       
        homingRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
         enemy = GameObject.FindGameObjectsWithTag("Enemy");
        Vector3 lookDirection = Vector3.RotateTowards(transform.forward, enemy[0].transform.position, 1 * Time.deltaTime, 0);
        transform.position = Vector3.MoveTowards(transform.position, enemy[0].transform.position, speed * Time.deltaTime);
        if (enemy == null)
        {
            Destroy(gameObject);
        }
    }
    void LaunchMissiles()
    {
      
        Destroy(gameObject, 5);
    }
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
        Destroy(gameObject);

    }
}
