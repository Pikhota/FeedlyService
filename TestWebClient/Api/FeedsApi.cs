using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace TestWebClient.Api
{
	public class FeedsApi
	{
		public HttpClient Initial(HttpClientHandler clientHandler)
		{
				clientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
				HttpClient client = new HttpClient(clientHandler)
				{
					BaseAddress = new Uri("https://localhost:5001")
				};
				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				return client;
		}

		public HttpClient Initial()
		{
			HttpClient client = new HttpClient()
			{
				BaseAddress = new Uri("https://localhost:5001")
			};
			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			return client;
		}
	}
}
