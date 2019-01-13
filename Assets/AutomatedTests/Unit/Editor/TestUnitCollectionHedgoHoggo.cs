using System;
using Zenject;
using NUnit.Framework;
using Moq;

[TestFixture]
public class TestUnitCollectionHedgoHoggo : ZenjectUnitTestFixture
{
    [SetUp]
    public void CommonInstall()
    {
        Container.BindInterfacesAndSelfTo<ServiceLogger>().FromNew().AsSingle().WithArguments(false).Lazy();
        Container.Bind<CollectionHedgoHoggo>().FromNew().AsSingle();
    }

    [Test]
    public void TestNew()
    {
        CollectionHedgoHoggo hedgoHoggoCollection = Container.Resolve<CollectionHedgoHoggo>();
        Assert.That(hedgoHoggoCollection.RegisteredHedgoHoggoViews != null);
        Assert.That(hedgoHoggoCollection.RegisteredHedgoHoggoViews.Count == 0);
    }

    [Test]
    public void TestEmptySaveLoad()
    {
        CollectionHedgoHoggo hedgoHoggoCollection = Container.Resolve<CollectionHedgoHoggo>();
        hedgoHoggoCollection.Save();
        hedgoHoggoCollection.Load();
        Assert.That(hedgoHoggoCollection.RegisteredHedgoHoggoViews != null);
        Assert.That(hedgoHoggoCollection.RegisteredHedgoHoggoObjects != null);
        Assert.That(hedgoHoggoCollection.RegisteredHedgoHoggoViews.Count == 0);
        Assert.That(hedgoHoggoCollection.RegisteredHedgoHoggoObjects.Count == 0);
    }

    [Test]
    public void TestPopulatedSaveLoad()
    {
        CollectionHedgoHoggo hedgoHoggoCollection = Container.Resolve<CollectionHedgoHoggo>();
        ObjectHedgoHoggo hedgoHoggoObject = new Mock<ObjectHedgoHoggo>().Object;
        UnityEngine.Color hedgoHoggoColor = UnityEngine.Color.red;
        UnityEngine.Vector3 hedgoHoggoPosition = UnityEngine.Vector3.zero;
        hedgoHoggoObject.UpdateCurrentColor(hedgoHoggoColor);
        hedgoHoggoObject.UpdateCurrentPosition(hedgoHoggoPosition);
        ViewHedgoHoggo hedgoHoggoView = new Mock<ViewHedgoHoggo>().Object;
        hedgoHoggoCollection.RegisterHedgoHoggo(hedgoHoggoObject, hedgoHoggoView);
        hedgoHoggoCollection.Save();
        hedgoHoggoCollection.UnRegisterHedgoHoggo(hedgoHoggoView);
        hedgoHoggoCollection.Load();
        Assert.That(hedgoHoggoCollection.RegisteredHedgoHoggoViews.Count == 1);
        Assert.That(hedgoHoggoCollection.RegisteredHedgoHoggoObjects.Count == 1);
        Assert.That(hedgoHoggoCollection.RegisteredHedgoHoggoObjects[0].CurrentColor == hedgoHoggoColor);
        Assert.That(hedgoHoggoCollection.RegisteredHedgoHoggoObjects[0].CurrentPosition == hedgoHoggoPosition);
    }
}