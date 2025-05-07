using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _playerAnimator = default;
    void Start()
    {

        if(!TryGetComponent<Animator>(out _playerAnimator))
        {
            _playerAnimator=this.gameObject.AddComponent<Animator>();
        }
        _playerAnimator=this.GetComponent<Animator>();
        PlayerState.Instance.SubscribeTakeDamage(TakeDamageAnimation);
    }

  private void TakeDamageAnimation()
    {
        
            _playerAnimator.SetTrigger("Damage");
    }
}
