using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;


[RequireComponent(typeof(Image))]
abstract public class ImageFadeTransitionEffect : TransitionEffect<Image, float>
{
    protected override Tweener GetTweener()
    {
        return DOTween.ToAlpha(() => _animatingComponent.color, x => _animatingComponent.color = x, _valueTo / 255f, _duration).SetEase(_easeType);
    }


    protected override void SetValue(float value)
    {
        _animatingComponent.color = new Color(_animatingComponent.color.r, _animatingComponent.color.g, _animatingComponent.color.b, value / 255f);
    }
}
