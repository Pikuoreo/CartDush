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
//    /// �C�x���g��o�^����
//    /// </summary>
//    /// <param name="member">�o�^���郁�\�b�h</param>
//    public void SubscribeEvent(OnFallHandler member)
//    {
//        OnFall += member;
//    }

//    /// <summary>
//    /// �C�x���g����������
//    /// </summary>
//    /// <param name="member">�������郁�\�b�h</param>
//    public void UnSubscribeEvent(OnFallHandler member)
//    {
//        OnFall -= member;
//    }

//    /// <summary>
//    /// �C�x���g���N������
//    /// </summary>
//    public void ActivateEvent()
//    {
//        OnFall.Invoke();
//    }
//}
