using System;
using System.Threading.Tasks;

public class PlayerState
{
    private static PlayerState _instance = default;
    private float _invincibilityTime = 3f;

    public delegate void takeDamage();
    private event Action _takeDamageProcess = default;

    public static PlayerState Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new PlayerState();
            }

            return _instance;
        }
    }

    public PlayerState()
    {
        SubscribeTakeDamage(TakeDamage);
    }

    //ƒ_ƒ[ƒW‚ğ‹ò‚ç‚Á‚Ä‚¢‚éÅ’†‚©
    public bool isDamage
    {
        get; private set;
    }

    public void SubscribeTakeDamage(Action member)
    {
        _takeDamageProcess+= member;
    }

    public void TakeDamageHandler()
    {
        _takeDamageProcess();
    }

    public async void TakeDamage()
    {
        isDamage = true;

        await EndInvincibilityTimeAsync();
    }

    private async Task EndInvincibilityTimeAsync()
    {
        // _invincibilityTime•b‘Ò‚Â
        await Task.Delay(TimeSpan.FromSeconds(_invincibilityTime));
        isDamage = false;
    }

    public void ResetInstance()
    {
        _instance = null;
    }
}
