using UnityEngine;
using System;

public class GameUpdator
{
    //�v���C���[�ȊO��Update�̗����^�C�~���O�����߂邽�߂̃C�x���g
    public delegate void Updator();

    //�v���C���[�̈ړ�������Update�̗����^�C�~���O�����߂邽�߂̃C�x���g
    public delegate void PlayerUpdator();

    //�v���C���[�ȊO��Update���܂Ƃ߂�
    private event Action _updator;

    //�v���C���[�̈ړ�������Update���܂Ƃ߂�
    private event Action _playerUpdator;

    //�V���O���g����
    private static GameUpdator _instance = default;
    public static GameUpdator Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameUpdator();
            }
            return _instance;
        }
    }

    /// <summary>
    /// Update���܂Ƃ߂�
    /// </summary>
    /// <param name="member">�܂Ƃ߂���Update��</param>
    public void SubscribeUpdate(Action member)
    {
        _updator += member;
    }

    /// <summary>
    /// �v���C���[�̈ړ�����Update���܂Ƃ߂�
    /// </summary>
    /// <param name="member">�܂Ƃ߂���Update��</param>
    public void SubscribePlayerUpdate(Action member)
    {
        _playerUpdator += member;
    }

    /// <summary>
    /// �v���C���[�ȊO��Update�𓮂���
    /// </summary>
    public void UpdateHandler()
    {
        _updator?.Invoke();
    }

    /// <summary>
    /// �v���C���[�̈ړ�����Update�𓮂���
    /// </summary>
    public void PlayerUpdateHandler()
    {
        _playerUpdator?.Invoke();
    }

    public void ResetInstance()
    {
        _instance = null;
    }
}
