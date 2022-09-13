using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float _speed = 3f;
    [SerializeField] GameObject _bullet = default;
    [SerializeField] Transform _muzzle = default;
    [SerializeField] float _bulletTime = 0.5f;
    [SerializeField] AudioSource _adBullet;

    private float _time;
    private float _h = 0f;
    private Rigidbody2D _rb2d;

    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _time += Time.deltaTime;
        _h = Input.GetAxisRaw("Horizontal");
        Vector2 dir = new Vector2(_h, 0);
        Vector2 b = dir.normalized * _speed;
        b.y = _rb2d.velocity.y;
        _rb2d.velocity = b;
       
        if(Input.GetButton("Jump") && _bulletTime < _time && TimeManager._isGame)
        {
            _adBullet.Play();
            GameObject bullet = Instantiate(_bullet);
            bullet.transform.position = _muzzle.position;
            _time = 0f;
        }
    }
}
