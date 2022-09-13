using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShoot : MonoBehaviour
{
    [SerializeField, Tooltip("’e‚ÌƒvƒŒƒnƒu")] GameObject _enemyBullet;
    [SerializeField] Transform[] _muzzle;
    [SerializeField] float _shootInterval = 0.5f;
    [SerializeField] float _shootInterval2 = 1f;
    [SerializeField] bool _isLast;

    GameObject _player;

    float _timer1;
    float _timer2;


    void Start()
    {
        _player = GameObject.FindWithTag("Player");
    }


    void FixedUpdate()
    {
        if (TimeManager._isGame)
        {
            _timer1 += Time.deltaTime;
            _timer2 += Time.deltaTime;
        }

        if (_timer1 > _shootInterval && _enemyBullet)
        {
            _timer1 = 0;
            for (int i = 0; i < _muzzle.Length; i++)
            {
                Instantiate(_enemyBullet, _muzzle[i].position, transform.rotation);
            }
        }

        if (_timer2 > _shootInterval2 && _enemyBullet && _isLast)
        {
            _timer2 = 0;
            for (int i = 0; i < _muzzle.Length; i++)
            {
                var bullet = Instantiate(_enemyBullet, _muzzle[i]);
                bullet.transform.up = bullet.transform.position - _player.transform.position;
            }
        }

    }
}
