using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] GameObject[] _enemy;
    [SerializeField] GameObject _boss;
    [SerializeField] Transform _spawnPoint = null;
    [SerializeField] float _spawnTime = 2f;
    [SerializeField] int _enemyCount = 5;

    private int _index;
    private bool _flag = false;
    private int _spawnCounter = 0;
    private float _enemyTimer = 0f;
    private bool _bossSpawne = false;

    void Update()
    {
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
                // �{�X�𐶐�����
                _bossSpawne = true;
                GameObject boss = Instantiate(_boss);
                boss.transform.position = _spawnPoint.position;
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
    public void StopGeneration()
    {
        _flag = false;
    }
    public void StartGeneration()
    {
        _flag = true;
    }
}
