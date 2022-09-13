using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] GameObject[] _enemy;
    [SerializeField] Transform _spawnPoint = null;
    [SerializeField] float _spawnTime = 2f;

    private int _index;
    private float _enemyTimer = 5f;


    void FixedUpdate()
    {
        // �E�F�[�u���œG�̐����Ԋu��҂�
        _enemyTimer += Time.deltaTime;
        if (_enemyTimer > _spawnTime)
        {
            _enemyTimer = 0;

            // �G�𐶐�����
            GameObject go = Instantiate(_enemy[_index % _enemy.Length]);
            go.transform.position = _spawnPoint.position;

            _index++;
        }
    }
}

