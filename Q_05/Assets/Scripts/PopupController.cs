using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupController : MonoBehaviour
{
    [SerializeField] private float _deactiveTime;
    private WaitForSeconds _wait;
    private Button _popupButton;

    [SerializeField] private GameObject _popup;

    Coroutine _deactivateCo;

    private void OnEnable()
    {
        Init();
    }

    private void Init()
    {
        _wait = new WaitForSeconds(_deactiveTime);
        _popupButton = GetComponent<Button>();
        SubscribeEvent();
    }

    private void SubscribeEvent()
    {
        _popupButton.onClick.AddListener(Activate);
    }

    private void Activate()
    {
        _popup.gameObject.SetActive(true);
        GameManager.Intance.Pause();

        if (_deactivateCo == null)
        _deactivateCo = StartCoroutine(DeactivateRoutine());
    }

    private void Deactivate()
    {
        _popup.gameObject.SetActive(false);
    }

    private IEnumerator DeactivateRoutine()
    {
        Debug.Log("코루틴 시작");
        yield return _wait;
        Debug.Log("카운트 끝");
        Deactivate();
    }
}
