using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bootstrapper : MonoBehaviour
{
    [SerializeField] private StoryNode _startNode;
    [SerializeField] private VIsualUpdater _vIsualUpdater;

    [SerializeField] private Button _option1Button;
    [SerializeField] private Button _option2Button;

    private StoryHandler _storyHandler;
    void Start()
    {   
        RestartGame();
    }

    public void RestartGame()
    {
        _option1Button.onClick.RemoveAllListeners();
        _option2Button.onClick.RemoveAllListeners();

        _storyHandler = new StoryHandler(_startNode, _vIsualUpdater, 5);
        _vIsualUpdater.ShowEndPanel(false);

        _option1Button.onClick.AddListener(_storyHandler.Option1);
        _option2Button.onClick.AddListener(_storyHandler.Option2);
    }
}
