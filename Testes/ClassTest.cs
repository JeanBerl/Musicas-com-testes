using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
namespace Testes;
    
[TestClass]
public class ClassTest
{
    [TestMethod]
    public void AssertMusicIsProperlyCreated()
    {
        // arrange
        Musica musica1 = new Musica("Sucker Train Blues", new TimeSpan(0, 4, 27), "Hard rock", new DateTime(2004, 06, 08, 5, 0, 0));
        Assert.AreEqual(musica1.Nome, "Sucker Train Blues");
    }
}