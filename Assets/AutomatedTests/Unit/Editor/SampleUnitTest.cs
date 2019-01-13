using System;
using Zenject;
using NUnit.Framework;

[TestFixture]
public class SampleUnitTest : ZenjectUnitTestFixture
{
    [SetUp]
    public void CommonInstall()
    {
        // Binding statements here
    }

    [Test]
    public void TestInitialValues()
    {
        Assert.That("" == String.Empty);
    }
}
