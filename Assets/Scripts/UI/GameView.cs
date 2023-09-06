using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using TMPro;
using UnityEngine.Events;

public class GameView : AbstractView
{
    [SerializeField] private Button pauseButton;
    [SerializeField] private TextMeshProUGUI scoreText;
    private NavigationFlow _navigationFlow;
    public UnityEvent OnPause { get; } = new UnityEvent();

    public override void Init()
    {
        Debug.Log("Game view activated!");
        _navigationFlow=GameObject.Find("Navigation Flow").GetComponent<NavigationFlow>();
        _navigationFlow.OnScoreValueChanged.AddListener(ShowScore);
    }
    protected void OnEnable()
    {
        base.OnEnable();
        pauseButton.onClick.AddListener(OnPauseButtonClicked);
    }
    protected void OnDisable()
    {
        base.OnDisable();
        pauseButton.onClick?.RemoveListener(OnPauseButtonClicked);
    }
    private void OnPauseButtonClicked()
    {
        OnPause?.Invoke();
    }
    private void ShowScore(int value)
    {
        scoreText.text = value.ToString();
    }
}