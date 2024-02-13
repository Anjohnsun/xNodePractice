using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryHandler
{
    private int _gold;
    private int _respect;
    private int _army;
    private int _religion;

    private StoryNode _currentNode;
    private VIsualUpdater _vIsualUpdater;

    public StoryHandler(StoryNode node, VIsualUpdater vIsualUpdater, int startValue)
    {
        _currentNode = node;
        _gold = startValue;
        _respect = startValue;
        _army = startValue;
        _religion = startValue;

        _vIsualUpdater = vIsualUpdater;

        LoadNodeInfo();
        UpdateResourceInfo();
    }

    public void Option1() => ChooseOption(1);
    public void Option2() => ChooseOption(2);

    private void ChooseOption(int i)
    {
        if (!(i == 1 || i == 2 || i == 3))
            throw new Exception("No such option");

        Vector2Int optionGold = _currentNode._event.GoldEffect;
        Vector2Int optionRespect = _currentNode._event.RespectEffect;
        Vector2Int optionArmy = _currentNode._event.ArmyEffect;
        Vector2Int optionReligion = _currentNode._event.ReligionEffect;

        if (i == 1)
        {
            _gold += optionGold.x;
            _respect += optionRespect.x;
            _army += optionArmy.x;
            _religion += optionReligion.x;
        }
        else if (i == 2)
        {
            _gold += optionGold.y;
            _respect += optionRespect.y;
            _army += optionArmy.y;
            _religion += optionReligion.y;
        }


        UpdateResourceInfo();

        if (_gold < 0 || _gold > 10
            || _respect < 0 || _respect > 10
            || _army < 0 || _army > 10
            || _religion < 0 || _religion > 10)
        {
            _vIsualUpdater.ShowEndPanel(true);
            Debug.Log($"Золото -{_gold}, Уважение -{_respect}, Армия -{_army}, Вера - {_religion}.");
        }
        else
        {
            if (i == 1)
            {
                _currentNode.GetInputValue<StoryNode>("_nextStoryNode1")._previousStory = _currentNode;
                _currentNode = _currentNode.GetInputValue<StoryNode>("_nextStoryNode1");
                _currentNode._optionID = 1;
            }
            else if (i == 2)
            {
                _currentNode.GetInputValue<StoryNode>("_nextStoryNode2")._previousStory = _currentNode;
                _currentNode = _currentNode.GetInputValue<StoryNode>("_nextStoryNode2");
                _currentNode._optionID = 2;
            }
            else
            {
                if (_currentNode._previousStory != null)
                {
                    optionGold = _currentNode._previousStory._event.GoldEffect;
                    optionRespect = _currentNode._previousStory._event.RespectEffect;
                    optionArmy = _currentNode._previousStory._event.ArmyEffect;
                    optionReligion = _currentNode._previousStory._event.ReligionEffect;

                    if (_currentNode._optionID == 1)
                    {
                        _gold -= optionGold.x;
                        _respect -= optionRespect.x;
                        _army -= optionArmy.x;
                        _religion -= optionReligion.x;
                    }
                    else if (_currentNode._optionID == 2)
                    {
                        _gold -= optionGold.y;
                        _respect -= optionRespect.y;
                        _army -= optionArmy.y;
                        _religion -= optionReligion.y;
                    }

                    _currentNode = _currentNode._previousStory;
                    UpdateResourceInfo();
                }
            }

            LoadNodeInfo();
        }
    }

    private void LoadNodeInfo()
    {
        _vIsualUpdater.UpdateStory(_currentNode._event.Description, _currentNode._event.Option1, _currentNode._event.Option2, _currentNode._event.EventSprite);
    }

    private void UpdateResourceInfo()
    {
        _vIsualUpdater.UpdateResourceInfo(_gold.ToString(), _respect.ToString(), _army.ToString(), _religion.ToString());
    }

    public void PreviousNodeOption()
    {
        ChooseOption(3);
    }
}

