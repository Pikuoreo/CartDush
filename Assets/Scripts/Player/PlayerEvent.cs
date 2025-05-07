//using System;
//using UnityEngine;

//public class PlayerEvent
//{

//    public delegate void OnFallHandler();
   
//    private event OnFallHandler OnFall;

//    private static PlayerEvent instance;

//    public static PlayerEvent Instance
//    {
//        get
//        {
//            if (instance == null)
//            {
//                instance = new PlayerEvent();
//            }
//            return instance;
//        }
//    }

//    /// <summary>
//    /// イベントを登録する
//    /// </summary>
//    /// <param name="member">登録するメソッド</param>
//    public void SubscribeEvent(OnFallHandler member)
//    {
//        OnFall += member;
//    }

//    /// <summary>
//    /// イベントを解除する
//    /// </summary>
//    /// <param name="member">解除するメソッド</param>
//    public void UnSubscribeEvent(OnFallHandler member)
//    {
//        OnFall -= member;
//    }

//    /// <summary>
//    /// イベントを起動する
//    /// </summary>
//    public void ActivateEvent()
//    {
//        OnFall.Invoke();
//    }
//}
