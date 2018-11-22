using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using System;

public class ObjectHedgoHoggo : IDisposable
{
    public class Factory : PlaceholderFactory<ObjectHedgoHoggo> {}

    private ViewHedgoHoggo.Factory _viewFactory;
    private ViewHedgoHoggo _view;

    public ObjectHedgoHoggo (ViewHedgoHoggo.Factory inputHedgoHoggoViewFactory)
    {
        _viewFactory = inputHedgoHoggoViewFactory;
        _view = _viewFactory.Create();
    }

    public void Dispose()
    {
        _view.Dispose();
        _view = null;
        _viewFactory = null;
    }
}
