using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ObjectActivityStateCreating : ObjectActivityState
{
    [Inject] private ViewUIPanelMain _mainPanelView;
    [Inject] private ServiceInput _inputService;

    public override void Cleanup()
    {

    }

    public override void Setup()
    {
        _mainPanelView.SetCurrentActivityStateText("Creating State");
    }

    public override void Tick()
    {

    }
}
