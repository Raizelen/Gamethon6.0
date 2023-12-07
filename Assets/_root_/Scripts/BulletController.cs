using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private GameObject bulletdecal;

    private float speed = 50f;
    private float timeToDestreoy = 3f;

    public Vector3 target { get; set; }
    public bool hit { get; set; }

    private void OnEnable()
    {
        Destroy(gameObject, timeToDestreoy);
    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position,target,speed *Time.deltaTime);
        if (!hit && Vector3.Distance(transform.position, target) < 0.1f)
        {
            Destroy(gameObject);
        }

    }
    private void OnCollisionEnter(Collision other)
    {
        ContactPoint contact = other.GetContact(0);
        GameObject.Instantiate(bulletdecal, contact.point,Quaternion.LookRotation(contact.normal));
        Destroy(gameObject);

    }
}
