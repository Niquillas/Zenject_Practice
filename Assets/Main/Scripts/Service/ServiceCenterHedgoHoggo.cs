using System.Collections.Generic;
using UnityEngine;

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

    public void DestroyAllHedgoHoggos ()
    {
        List<ViewHedgoHoggo> hedgoHoggoViews = _hedgoHoggoCollection.RegisteredHedgoHoggoViews;
        for (int i = 0; i < hedgoHoggoViews.Count; i++)
        {
            DestroyHedgoHoggo(hedgoHoggoViews[i]);
        }
    }

    public void DestroyHedgoHoggo (ViewHedgoHoggo inputHedgoHoggoView)
    {
        _hedgoHoggoCollection.UnRegisterHedgoHoggo(inputHedgoHoggoView);
        inputHedgoHoggoView.Dispose();
    }

    public void Save ()
    {
        _hedgoHoggoCollection.Save();
    }

    public void Load ()
    {
        DestroyAllHedgoHoggos();

        CollectionHedgoHoggo.Data saveData = _hedgoHoggoCollection.Load();

        if (saveData != null)
        {
            for (int i = 0; i < saveData.HedgoHoggos.Count; i++)
            {
                ViewHedgoHoggo hedgoHoggoView = _hedgoHoggoViewFactory.Create(saveData.HedgoHoggos[i]);
                _hedgoHoggoCollection.RegisterHedgoHoggo(saveData.HedgoHoggos[i], hedgoHoggoView);
                saveData.HedgoHoggos[i].UpdateCurrentPosition(saveData.HedgoHoggos[i].CurrentPosition);
                saveData.HedgoHoggos[i].UpdateCurrentColor(saveData.HedgoHoggos[i].CurrentColor);
            }
        }
    }
}
