using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class GameLoader : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] private UnityEvent OnGameLoading;
    [SerializeField] private UnityEvent OnGameLoaded;


    private void Start()
    {
        LoadGame();
    }


    public void LoadGame()
    {
        StartCoroutine(nameof(GameLoading));
    }
    

    IEnumerator GameLoading()
    {
        bool isLoadingEnded = false;
        UnityAction onLoadingEndedInlineAction = () => isLoadingEnded = true;

        OnGameLoading.AddListener(onLoadingEndedInlineAction);
        OnGameLoading?.Invoke();

        while (!isLoadingEnded) // сработает после того, как все подключенные к событию "OnGameLoading" действия будут выполнены
        {
            yield return new WaitForEndOfFrame();
        }

        OnGameLoading.RemoveListener(onLoadingEndedInlineAction);

        // ручная задержка для демонстрации
        yield return new WaitForSeconds(2);

        OnGameLoaded?.Invoke();
    }
}
