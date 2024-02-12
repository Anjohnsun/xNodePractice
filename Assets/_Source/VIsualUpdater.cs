using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VIsualUpdater : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _gold;
    [SerializeField] private TextMeshProUGUI _respect;
    [SerializeField] private TextMeshProUGUI _army;
    [SerializeField] private TextMeshProUGUI _religion;

    [SerializeField] private TextMeshProUGUI _story;

    [SerializeField] private TextMeshProUGUI _option1;
    [SerializeField] private TextMeshProUGUI _option2;

    [SerializeField] private Image _image;

    [SerializeField] private GameObject _endPanel;

    public void UpdateResourceInfo(string gold, string respect, string army, string religion)
    {
        _gold.text = gold;
        _respect.text = respect;
        _army.text = army;
        _religion.text = religion;
    }

    public void UpdateStory(string story, string option1, string option2, Sprite sprite)
    {
        _story.text = story;
        _option1.text = option1;
        _option2.text = option2;
        _image.sprite = sprite;
    }

    public void ShowEndPanel(bool value)
    {
        _endPanel.SetActive(value);
    }
}
