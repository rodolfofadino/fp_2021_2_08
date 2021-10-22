using Fiap.Application.Interfaces;
using Fiap.Domain.Models;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;

namespace Fiap.Application.Services
{
    public class NoticiaService : INoticiaService
    {
        private IMemoryCache _memoryCache;
        private IRssClient _rssClient;

        public NoticiaService(IMemoryCache memoryCache, IRssClient rssClient)
        {
            _memoryCache = memoryCache;
            _rssClient = rssClient;
        }

        public List<Noticia> Load(int totalDeNoticias)
        {

            var key = $"noticias_{totalDeNoticias}";

            var noticias = new List<Noticia>();
            if (!_memoryCache.TryGetValue(key, out noticias))
            {
                noticias = _rssClient.Load();

                var cacheEntrieOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(DateTime.Now.AddMinutes(2));

                _memoryCache.Set(key, noticias, cacheEntrieOptions);
            }


            return noticias;
        }
    }
}