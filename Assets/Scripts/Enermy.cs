using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enermy : MonoBehaviour
{
    public Transform target;
    private Rigidbody rig;
    private bool scored = false;
    public float speed = 150f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet" && scored == false)
        {
            scored = true;
            GameManager.instance.AddScore(1);
            transform.position = new Vector3(Random.Range(-30, 30), 0.5f, Random.Range(-30, 30));
            scored = false;
        }
    }

    void Start()
    {
        rig = GetComponent<Rigidbody>();
        target = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        if (Vector3.Distance(target.position, transform.position) < 10f)
        {
            Vector3 tran = target.position - transform.position;
            rig.AddForce(tran * speed * Time.deltaTime);
        }
    }
}