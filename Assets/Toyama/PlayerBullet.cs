using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] float _bulletSpeed = 10;
    [SerializeField] GameObject _hitEffect;
    [SerializeField] GameObject _enemyBulletSE;
    [SerializeField] GameObject _enemySe;
    [SerializeField] GameObject _panSe;
    Rigidbody2D _rb;


    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity =  transform.up * _bulletSpeed;
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "EnemyBullet")
        {
            Instantiate(_enemyBulletSE);
        }
        else if(collision.gameObject.tag == "Boss")
        {
            Instantiate(_panSe);
        }
        else if(collision.gameObject.tag == "Enemy")
        {
            Instantiate(_enemySe);
        }
        Instantiate(_hitEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
