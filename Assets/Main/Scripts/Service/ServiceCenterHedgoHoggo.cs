using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ServiceCenterHedgoHoggo
{
    private CollectionHedgoHoggo _hedgoHoggoCollection;
    private readonly ObjectHedgoHoggo.Factory _hedgoHoggoObjectFactory;
    private readonly ViewHedgoHoggo.Factory _hedgoHoggoViewFactory;

    public ServiceCenterHedgoHoggo (CollectionHedgoHoggo inputHedgoHoggoCollection, ObjectHedgoHoggo.Factory inputHedgoHoggoObjectFactory, ViewHedgoHoggo.Factory inputHedgoHoggoViewFactory)
    {
        _hedgoHoggoCollection = inputHedgoHoggoCollection;
        _hedgoHoggoObjectFactory = inputHedgoHoggoObjectFactory;
        _hedgoHoggoViewFactory = inputHedgoHoggoViewFactory;
    }

    public ViewHedgoHoggo CreateHedgoHoggo ()
    {
        ObjectHedgoHoggo hedgoHoggoObject = _hedgoHoggoObjectFactory.Create();
        ViewHedgoHoggo hedgoHoggoView = _hedgoHoggoViewFactory.Create(hedgoHoggoObject);
        _hedgoHoggoCollection.RegisterHedgoHoggo(hedgoHoggoObject, hedgoHoggoView);
        return hedgoHoggoView;
    }

    public void PositionHedgoHoggoViaFloor(ViewHedgoHoggo inputHedgoHoggoView, Vector3 inputPosition)
    {
        ObjectHedgoHoggo hedgoHoggoObject = _hedgoHoggoCollection.FetchHedgoHoggoObject(inputHedgoHoggoView);
        Vector3 flooredPosition = inputPosition;
        flooredPosition.y += inputHedgoHoggoView.WorldHeight / 2;
        hedgoHoggoObject.UpdateCurrentPosition(flooredPosition);
    }

    public void ColorHedgoHoggoToRandom(ViewHedgoHoggo inputHedgoHoggoView)
    {
        _hedgoHoggoCollection.FetchHedgoHoggoObject(inputHedgoHoggoView).UpdateCurrentColorToRandomColor();
    }

    public void DestroyHedgoHoggo (ViewHedgoHoggo inputHedgoHoggoView)
    {
        _hedgoHoggoCollection.UnRegisterHedgoHoggo(inputHedgoHoggoView);
        inputHedgoHoggoView.Dispose();
    }
}
