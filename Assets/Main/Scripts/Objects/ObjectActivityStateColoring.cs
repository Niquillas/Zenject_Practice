using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ObjectActivityStateColoring : ObjectActivityState
{
    [Inject] private ViewUIPanelMain _mainPanelView;

    public override void Cleanup()
    {

    }

    public override void Setup()
    {
        _mainPanelView.SetCurrentActivityStateText("Coloring State");
    }

    public override void Tick()
    {

    }
}
