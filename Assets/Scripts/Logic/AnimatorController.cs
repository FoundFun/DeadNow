using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    [SerializeField] private Animator _animator; 

    private string _animationName = "animation";

    public Animation StateAnimation
    {
        get { return (Animation)_animator.GetInteger(_animationName); }
        private set { _animator.SetInteger(_animationName, (int)value); }
    }

    public void SetSpeed(float speed)
    {
        _animator.speed = speed;
    }

    public void SetAnimation(Animation anim)
    {
        StateAnimation = anim;
    }
}

public enum Animation
{
    Idle,
    Run,
    Attack,
    Jump,
    Die
}

