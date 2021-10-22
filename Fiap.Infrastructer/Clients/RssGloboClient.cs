using CodeHollow.FeedReader;
using Fiap.Application.Interfaces;
using Fiap.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Infrastructer.Clients
{
    public class RssGloboClient : IRssClient
    {
        private string _feedUrl;

        public RssGloboClient(string feedUrl)
        {
            _feedUrl = feedUrl;
        }
        public List<Noticia> Load()
        {
            var noticias = new List<Noticia>();
            var feed = FeedReader.ReadAsync(_feedUrl).Result;

            foreach (var item in feed.Items)
            {
                var feedItem = item.SpecificItem as CodeHollow.FeedReader.Feeds.MediaRssFeedItem;
                var media = feedItem.Media;
                var url = "";
                if (media.Any())
                    url = media.FirstOrDefault().Url;
                noticias.Add(new Noticia() { Id = 1, Titulo = item.Title, Link = item.Link, Imagem = url });
            }
            return noticias;
        }
    }
}
