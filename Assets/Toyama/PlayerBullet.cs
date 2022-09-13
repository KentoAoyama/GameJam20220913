using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] float _bulletSpeed = 10;
    [SerializeField] GameObject _hitEffect;
    [SerializeField] AudioSource _enemyBullete;
    [SerializeField] AudioSource _enemy;
    [SerializeField] AudioSource _boss;
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
            _enemyBullete.Play();
        }
        else if(collision.gameObject.tag == "Boss")
        {
            _boss.Play();
        }
        else if(collision.gameObject.tag == "Enemy")
        {
            _enemy.Play();
        }
        Instantiate(_hitEffect, transform.position, transform.rotation);
        Destroy(gameObject,0.2f);
    }
}
