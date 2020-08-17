﻿using BandAPI.DbContexts;
using BandAPI.Entities;
using BandAPI.Helpers;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BandAPI.Services
{
    public class BandAlbumRepository : IBandAlbumRepository
    {
        private readonly BandAlbumContext _context;
        public BandAlbumRepository(BandAlbumContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof (context));
        }
        public void AddAlbum(Guid bandId, Album album)
        {
            if(bandId ==Guid.Empty)
                throw new ArgumentNullException(nameof(bandId));
            if (album == null)
                throw new ArgumentNullException(nameof(album));
            album.BandId = bandId;
            _context.Albums.Add(album);
        }

        public void AddBands(Band band)
        {
            if (band == null)
                throw new ArgumentNullException(nameof(band));

            _context.Bands.Add(band);

        }

        public bool AlbumExists(Guid albumId)
        {
            if(albumId == Guid.Empty)
               throw new ArgumentNullException(nameof(albumId));

            return _context.Albums.Any(a => a.Id == albumId);
        }

        public bool BandExists(Guid bandId)
        {
            if (bandId == Guid.Empty)
                throw new ArgumentNullException(nameof(bandId));

            return _context.Bands.Any(b => b.Id == bandId);
           
        }

        public void DeleteAlbum(Album album)
        {
            if(album == null)
            throw new ArgumentNullException(nameof(album));

            _context.Albums.Remove(album);
        }

        public void DeleteBand(Band band)
        {
            if (band == null)
            throw new ArgumentNullException(nameof(band));

            _context.Bands.Remove(band);
        }

        public Album GetAlbum(Guid bandId, Guid albumId)
        {
            if (bandId == Guid.Empty)
                throw new ArgumentNullException(nameof(bandId));
            if (albumId == Guid.Empty)
                throw new ArgumentNullException(nameof(albumId));
            return _context.Albums.Where(a => a.BandId == bandId && a.Id == albumId).FirstOrDefault();
        }

        public IEnumerable<Album> GetAlbums(Guid bandId)
        {
            if (bandId ==Guid.Empty)
                throw new ArgumentNullException(nameof(bandId));

            return _context.Albums.Where(a => a.BandId == bandId)
                .OrderBy(a => a.Title).ToList();
        }

        public Band GetBand(Guid bandId)

        {
            if (bandId ==Guid.Empty)
                throw new ArgumentNullException(nameof(bandId));

            return _context.Bands.FirstOrDefault(b => b.Id == bandId);
        }

        public IEnumerable<Band> GetBands()
        {
            return _context.Bands.ToList();
        }

        public IEnumerable<Band> GetBands(IEnumerable<Guid> banIds)
        {
            if (banIds == null)
                throw new ArgumentNullException(nameof(banIds));

            return _context.Bands.Where(b => banIds.Contains(b.Id))
                .OrderBy(b => b.Name).ToList();
        }
        public IEnumerable<Band> GetBands(BandsResourceParameters bandsResourceParameters)
        {
            if (bandsResourceParameters == null)
                throw new ArgumentNullException(nameof(bandsResourceParameters));

            if (string.IsNullOrWhiteSpace(bandsResourceParameters.MainGenre)&& string.IsNullOrWhiteSpace(bandsResourceParameters.SearchQuery))
                return GetBands();
            var collection = _context.Bands as IQueryable<Band>;

            if (!string.IsNullOrWhiteSpace(bandsResourceParameters.MainGenre))
            {
               var mainGenre = bandsResourceParameters.MainGenre.Trim();
                collection = collection.Where(b => b.MainGenre == mainGenre);
            }
            if (!string.IsNullOrWhiteSpace(bandsResourceParameters.SearchQuery))
            {
               var searchQuery = bandsResourceParameters.SearchQuery.Trim();
                collection = collection.Where(b => b.Name.Contains(searchQuery));
            }

            return collection.ToList();
        }

        public bool Save()
        {
            return(_context.SaveChanges()>=0);
        }

        public void UpdateAlbum(Album album)
        {
           // not implemented throw new NotImplementedException();
        }

        public void UpdateBand(Band band)
        {
           // not implemented throw new NotImplementedException();
        }
    }
}
