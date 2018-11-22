using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ObjectActivityStateDeleting : ObjectActivityState
{
    [Inject] private ViewUIPanelMain _mainPanelView;

    public override void Cleanup()
    {

    }

    public override void Setup()
    {
        _mainPanelView.SetCurrentActivityStateText("Deleting State");
    }

    public override void Tick()
    {

    }
}
