using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "EventCard", menuName = "SO/NewEventCard")]
public class EventSO : ScriptableObject
{
    [SerializeField] private Sprite _eventSprite;
    [SerializeField] [TextArea(1, 5)] private string _description;
    [SerializeField] [TextArea(1, 3)] private string _option1;
    [SerializeField] [TextArea(1, 3)] private string _option2;
    [SerializeField] private Vector2Int _goldEffect;
    [SerializeField] private Vector2Int _respectEffect;
    [SerializeField] private Vector2Int _armyEffect;
    [SerializeField] private Vector2Int _religionEffect;

    public Sprite EventSprite => _eventSprite;
    public string Description => _description;
    public string Option1 => _option1;
    public string Option2 => _option2;
    public Vector2Int GoldEffect => _goldEffect;
    public Vector2Int RespectEffect => _respectEffect;
    public Vector2Int ArmyEffect => _armyEffect;
    public Vector2Int ReligionEffect => _religionEffect;
}
