using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShoot : MonoBehaviour
{
    [SerializeField, Tooltip("’e‚ÌƒvƒŒƒnƒu")] GameObject _enemyBullet;
    [SerializeField] Transform[] _muzzle;
    [SerializeField] float _shootInterval = 0.2f;
    float _timer;


    void FixedUpdate()
    {
        if (TimeManager._isGame)
        {
            _timer += Time.deltaTime;
        }

        if (_timer > _shootInterval && _enemyBullet)
        {
            _timer = 0;
            for (int i = 0; i < _muzzle.Length; i++)
            {
                Instantiate(_enemyBullet, _muzzle[i].position, transform.rotation);
            }
        }
    }
}
