using System;
using UnityEngine;
using UnityEngine.UI;

public class ResumeButton : MonoBehaviour
{
    private Button _resumeButton;

    public event Action ResumeButtonClicked;

    private void Awake()
    {
        _resumeButton = gameObject.GetComponent<Button>();
        _resumeButton.onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        ResumeButtonClicked?.Invoke();
    }
}
