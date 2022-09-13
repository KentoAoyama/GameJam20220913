using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] GameObject[] _enemy;
    [SerializeField] Transform _spawnPoint = null;
    [SerializeField] float _spawnTime = 2f;
    [SerializeField] int _enemyCount = 0;

    private int _index;
    private bool _flag = false;
    private int _spawnCounter = 0;
    private float _enemyTimer = 5f;
    private bool _bossSpawne = false;

    public static bool _isBossActive;


    void Update()
    {
        if(TimeManager._isGame == true)
        {
            _flag = true;
        }

        if (!_flag) return;

        if (_bossSpawne)
        {
            return;
        }

        // �E�F�[�u���œG�̐����Ԋu��҂�
        _enemyTimer += Time.deltaTime;
        if (_enemyTimer > _spawnTime)
        {
            // m_enemyPrefabs �z��̑S�Ă̗v�f�ɑ΂��ăE�F�[�u���I�������
            if (_index > _enemy.Length - 1)
            {
                // �{�X
                _isBossActive = true;
                return;
            }

            // �܂��E�F�[�u�𐶐����A�^�C�}�[�����Z�b�g���� m_spawnCounter ���J�E���g�A�b�v����
            _enemyTimer = 0;
            _spawnCounter++;

            // �G�𐶐�����
            GameObject go = Instantiate(_enemy[_index]);
            go.transform.position = _spawnPoint.position;

            // �E�F�[�u���I�������A���̃E�F�[�u�ɉf��
            if (_spawnCounter > _enemyCount - 1)
            {
                _spawnCounter = 0;
                _index++;
            }
        }
    }
}

