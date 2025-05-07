using UnityEngine;
using System;

public class GameUpdator
{
    //プレイヤー以外のUpdateの流すタイミングを決めるためのイベント
    public delegate void Updator();

    //プレイヤーの移動処理のUpdateの流すタイミングを決めるためのイベント
    public delegate void PlayerUpdator();

    //プレイヤー以外のUpdateをまとめる
    private event Action _updator;

    //プレイヤーの移動処理のUpdateをまとめる
    private event Action _playerUpdator;

    //シングルトン化
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
    /// Updateをまとめる
    /// </summary>
    /// <param name="member">まとめたいUpdate文</param>
    public void SubscribeUpdate(Action member)
    {
        _updator += member;
    }

    /// <summary>
    /// プレイヤーの移動処理Updateをまとめる
    /// </summary>
    /// <param name="member">まとめたいUpdate文</param>
    public void SubscribePlayerUpdate(Action member)
    {
        _playerUpdator += member;
    }

    /// <summary>
    /// プレイヤー以外のUpdateを動かす
    /// </summary>
    public void UpdateHandler()
    {
        _updator?.Invoke();
    }

    /// <summary>
    /// プレイヤーの移動処理Updateを動かす
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
