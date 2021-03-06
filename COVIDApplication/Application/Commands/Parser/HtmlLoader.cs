﻿using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Parser
{
    public class HtmlLoader<T> where T:class
    {
        readonly HttpClient client;
        readonly string url;

        public HtmlLoader(IParserSettings<T> settings)
        {
            client = new HttpClient();
            url = $"{settings.BaseUrl}/{settings.Prefix}/";
        }

        public async Task<string> GetSourceByPageId(string id="")
        {
            var currentUrl = url.Replace("{CurrentId}", id.ToString());
            var response = await client.GetAsync(currentUrl);
            string source = null;

            if (response != null && response.StatusCode == HttpStatusCode.OK)
            {
                source = await response.Content.ReadAsStringAsync();
            }

            return source;
        }
    }
}
