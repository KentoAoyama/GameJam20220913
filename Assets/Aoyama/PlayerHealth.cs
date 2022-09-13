using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField, Tooltip("死亡時に出すプレハブ")] GameObject _deathPrefab;
    [SerializeField, Tooltip("PlayerのHPのSlider")] Slider _hpSlider;

    public float _playerHealth = 10;

    float _startHealth;

    void Start()
    {
        _startHealth = _playerHealth;
    }


    void FixedUpdate()
    {
        _hpSlider.value = _playerHealth / _startHealth;
    }


    void OnDisable()
    {
        if (_deathPrefab)
        {
            Instantiate(_deathPrefab, transform.position, transform.rotation);
        }
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyBullet")
        {
            _playerHealth--;
        }
    }
}
