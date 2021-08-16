using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TemplatedText : MonoBehaviour
{
    [SerializeField] private string _template = "Find {0}";
    private Text _textComponent;


    private void Awake()
    {
        _textComponent = GetComponent<Text>();
    }


    public void UpdateText(object param)
    {
        _textComponent.text = string.Format(_template, param);
    }
}
