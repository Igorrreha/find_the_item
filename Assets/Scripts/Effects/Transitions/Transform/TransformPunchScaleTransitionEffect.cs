using UnityEngine;
using DG.Tweening;

// Punch-эффекты можно вынести в отдельный класс (так как это не совсем transition)
public class TransformPunchScaleTransitionEffect : TransitionEffect<Transform, Vector3>
{

    protected override Vector3 ValueFrom => Vector3.one;


    protected override Tweener GetTweener()
    {
        return _animatingComponent.DOPunchScale(_valueTo, _duration, 7, 0.5f).SetEase(_easeType);
    }


    protected override void SetValue(Vector3 value)
    {
        _animatingComponent.localScale = value;
    }
}
