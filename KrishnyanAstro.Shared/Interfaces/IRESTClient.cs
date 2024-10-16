﻿using System.Net;

namespace KrishnyanAstro.Shared.Interfaces
{
    public interface IApiClient
    {
        string ContentType { get; set; }
        CookieContainer CookieContainer { get; }
        string EndPoint { get; set; }
        WebHeaderCollection Headers { get; set; }
        HttpVerb Method { get; set; }
        string PostData { get; set; }
        string UserAgent { get; set; }

        string Encoding { get; set; }

        string Response(string parameters = "");

        T Response<T>(string parameters = "");

    }
}
