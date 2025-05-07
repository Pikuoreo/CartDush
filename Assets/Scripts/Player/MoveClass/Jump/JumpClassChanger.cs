using UnityEngine;

/// <summary>
/// アイテム取得など、状況によってジャンプ処理を管理するクラスを変えるクラス
/// </summary>
public class JumpClassChanger : MonoBehaviour
{
   　//現在のジャンプ処理
    public BaseJump CurrentJumpClass { get; private set; }

    private void Start()
    {
        //最初はDeafultJumpをセットする
        CurrentJumpClass = gameObject.AddComponent<DefaultJump>();
    }

    /// <summary>
    /// ジャンプ処理のクラスを変更する
    /// </summary>
    /// <typeparam name="T">変更するBaseJumpを継承したジャンプ処理のクラス</typeparam>
    public void ChangeJumpType<T>() where T : BaseJump
    {
        //すでに別のジャンプ処理がある場合
        if (CurrentJumpClass != null)
        {
            //入っているジャンプ処理を削除
            Destroy(CurrentJumpClass);
        }

        //新しいジャンプ処理のクラスを追加
        CurrentJumpClass = gameObject.AddComponent<T>();
    }

}
