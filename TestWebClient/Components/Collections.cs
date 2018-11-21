using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TestWebClient.Api;
using FeedlyServiceApi.Models;

namespace TestWebClient.Components
{
	public class Collections : ViewComponent
	{
		private FeedsApi _api;

		public Collections()
		{
			_api = new FeedsApi();
		}

		public async Task<IViewComponentResult> InvokeAsync(string userName)
		{
			List<Collection> collections;

			using (HttpClient client = _api.Initial())
			{
				try
				{
					using (HttpResponseMessage response = await client.GetAsync($"api/FeedsNews/byOwner/{userName}"))
					{
						response.EnsureSuccessStatusCode();
						var result = await response.Content.ReadAsStringAsync();
						collections = JsonConvert.DeserializeObject<List<Collection>>(result);
					}
				}
				catch (HttpRequestException requestException)
				{
					return Content($"Code: {requestException.HResult}\nMessage: {requestException.Message}\nSource: {requestException.Source}\n Trace: {requestException.StackTrace}");
				}
				catch (ArgumentNullException nullException)
				{
					return Content($"Code: {nullException.HResult}\nMessage: {nullException.Message}\nSource: {nullException.Source}\n Trace: {nullException.StackTrace}");
				}
			}
			return View("Collections", collections);
		}
	}
}
