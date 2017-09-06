using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Microsoft.Extensions.Caching.Memory;
using KenticoCloud.Delivery;
using CloudBoilerplateNet.Areas.WebHooks.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CloudBoilerplateNet.Areas.WebHooks.Controllers
{
    public class KenticoCloudController : Controller
    {
        protected readonly IDeliveryClient _client;
        protected readonly IMemoryCache _cache;

        public KenticoCloudController(IDeliveryClient deliveryClient, IMemoryCache memoryCache)
        {
            _client = deliveryClient;
            _cache = memoryCache;
        }

        // GET: /<controller>/
        [HttpPost]
        public IActionResult Index([FromBody] KenticoCloudWebhookModel model)
        {
            // Switch by types
                // Switch by operations

            // content item: 
                // get "getcontentitem|{name}|" cache items (TODO implement a dictionary in CachedDeliveryClient), add to list
                // get CLR type via ICodeFirstTypeProvider (TODO DI?), get "gettype" and "getelement" cache items, add to list
                // purge, 
                // if upsert, restore_publish(?) and publish, then read items, types and elements via cached client

            return View();
        }
    }
}
