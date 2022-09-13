using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] float _bulletSpeed = 10;

    private GameObject _player;
    Rigidbody2D _rb;


    void Start()
    {
        _player = GameObject.Find("Player");
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = transform.up * _bulletSpeed;
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
