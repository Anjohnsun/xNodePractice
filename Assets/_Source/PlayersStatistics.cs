using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersStatistics
{
    private int _gold;
    private int _respect;
    private int _army;
    private int _religion;

    private Vector2 _minMaxValues;

    public PlayersStatistics(int gold, int respect, int army, int religion, Vector2 minMaxValues)
    {
        _gold = gold;
        _respect = respect;
        _army = army;
        _religion = religion;
        _minMaxValues = minMaxValues;
    }
}
