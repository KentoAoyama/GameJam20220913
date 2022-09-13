using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] float _bulletSpeed = 10;
    [SerializeField] GameObject _hitEffect;

    Rigidbody2D _rb;


    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity =  transform.up * _bulletSpeed;
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(_hitEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
