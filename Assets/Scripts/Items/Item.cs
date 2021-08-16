// Предмет. Инициализируется данными (ItemData). Кликабельный

using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Item : MonoBehaviour
{
    [Header("External components")]
    [SerializeField] private Effect _AcceptAnimationEffect;
    [SerializeField] private Effect _DeclineAnimationEffect;

    private Image _imageComponent;
    private bool _isTarget;
    private bool _isClickable;

    public event Action OnTargetPressedAction;

    public bool IsTarget => _isTarget;


    private void Awake()
    {
        _imageComponent = GetComponent<Image>();
    }


    public void Initialize(ItemData data)
    {
        _isClickable = true;
        _isTarget = data.IsTarget;

        ItemRenderData renderData = data.RenderData;
        _imageComponent.sprite = renderData.Sprite;

        transform.rotation = Quaternion.Euler(0, 0, renderData.Rotation);
        transform.localScale = new Vector3(
            renderData.FlipH ? -1 : 1, 
            renderData.FlipV ? -1 : 1,
            1);
    }

    
    public void Click()
    {
        if (!_isClickable) return;

        if (_isTarget)
        {
            _isClickable = false;
            _AcceptAnimationEffect.Play();
            OnTargetPressedAction?.Invoke();
        }
        else
        {
            _DeclineAnimationEffect.Play();
        }
    }
}
