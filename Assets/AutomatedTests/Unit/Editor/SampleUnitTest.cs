using System;
using Zenject;
using NUnit.Framework;

[TestFixture]
public class SampleUnitTest : ZenjectUnitTestFixture
{
    [SetUp]
    public void CommonInstall()
    {
        Container.Bind<ServiceUtility>().AsSingle();
    }

    [Test]
    public void TestInitialValues()
    {
        Assert.That("" == String.Empty);
    }
}
