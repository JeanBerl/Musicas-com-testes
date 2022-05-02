using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Testes;

[TestClass]
public class BuscaTest
{
    List<Artista> artists;
    List<Album> albumsSlash;
    List<Album> albumsOzzy;
    List<Musica> musicasContraband;
    List<Musica> musicasBlizzardOfOzzy;
    Album Contraband;
    Album BlizzardOfOzzy;
    Musica musica1;
    Musica musica2;
    Musica musica3;

    [TestInitialize]
    public void testInit(){
        // Creating collections
        artists = new List<Artista>();
        albumsSlash = new List<Album>();
        albumsOzzy = new List<Album>();
        musicasContraband = new List<Musica>();
        musicasBlizzardOfOzzy = new List<Musica>();
        // Creating variables
        Contraband = new Album("Contraband", "Hard Rock", new DateTime(2004, 06, 08, 5, 0, 0), "Mulher com arma", musicasContraband);
        BlizzardOfOzzy = new Album("Blizzard Of Ozz", "Heavy Metal", new DateTime(1980, 09, 20, 5, 0, 0), "Ozzy cantando", musicasBlizzardOfOzzy);
        musica1 = new Musica("Sucker Train Blues", new TimeSpan(0, 4, 27), "Hard rock", new DateTime(2004, 06, 08, 5, 0, 0));
        musica2 = new Musica("Do It for the Kids", new TimeSpan(0, 3, 55), "Hard rock", new DateTime(2004, 06, 08, 5, 0, 0));
        musica3 = new Musica("Crazy Train", new TimeSpan(0, 4, 56), "Heavy Metal", new DateTime(1980, 09, 20, 5, 0, 0));
        // Populating collections
        musicasContraband.Add(musica1);
        musicasContraband.Add(musica2);
        musicasBlizzardOfOzzy.Add(musica3);
        albumsSlash.Add(Contraband);
        albumsOzzy.Add(BlizzardOfOzzy);
        artists.Add(new Artista("Slash", "1222233", new DateTime(1965, 07, 23, 7, 0, 0), new DateTime(2022, 3, 1, 7, 0, 0), new DateTime(2008, 3, 1, 7, 0, 0), "Rock", albumsSlash));
        artists.Add(new Artista("Ozzy Osbourne", "42142141", new DateTime(1948, 12, 03, 7, 0, 0), new DateTime(2022, 3, 1, 7, 0, 0), new DateTime(2000, 3, 1, 7, 0, 0), "Hard Rock", albumsOzzy));
    }
    [TestMethod]
    public void AssertSpecificArtistAlbumsAreReturned() {
        var albumsQuery = Busca.GetSpecificArtistAlbums(artists, "Ozzy Osbourne");
        int i = 0;
        foreach(var album in albumsQuery){
            Assert.AreEqual(album.Nome, albumsOzzy[i].Nome);
            i++;
        }
    }
    [TestMethod]
    public void AssertAlbumsAreOrderedByDate(){
        // arrange
        List<Album> albuns = new List<Album>();
        Album Contraband = new Album("Contraband", "Hard Rock", new DateTime(2004, 06, 08, 5, 0, 0), "Mulher com arma", musicasContraband);
        Album BlizzardOfOzzy = new Album("Blizzard Of Ozz", "Heavy Metal", new DateTime(1980, 09, 20, 5, 0, 0), "Ozzy cantando", musicasBlizzardOfOzzy);
        albuns.Add(Contraband);
        albuns.Add(BlizzardOfOzzy);
        var albunsOrdered = Busca.OrderAlbumByReleaseDate(albuns);
        var albunsExpected = albuns.OrderBy(album => album.DataLancamento).ToList();
        Assert.IsTrue(albunsOrdered.SequenceEqual(albunsExpected));
    }
    [TestMethod]
    public void AssertProdutorAlbumsReleasedInSpecificYearAreReturned(){
        Assert.Fail();
    }
}