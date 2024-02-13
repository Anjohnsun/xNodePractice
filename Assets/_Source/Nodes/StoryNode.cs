using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class StoryNode : Node
{

    [SerializeField] public EventSO _event;
    [SerializeField] [Output] public StoryNode _previousStory;
    [SerializeField] [Input] public StoryNode _nextStoryNode1;
    [SerializeField] [Input] public StoryNode _nextStoryNode2;
    public int _optionID;
    protected override void Init()
    {
        base.Init();
    }

    // Return the correct value of an output port when requested
    public override object GetValue(NodePort port)
    {
        return this;
    }
}