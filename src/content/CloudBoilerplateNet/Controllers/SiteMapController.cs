using System.Collections.Generic;
using System.Linq;
using KenticoCloud.Delivery;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SimpleMvcSitemap;

namespace CloudBoilerplateNet.Controllers
{
    public class SiteMapController : BaseController
    {
        public SiteMapController(IDeliveryClient deliveryClient): base(deliveryClient)
        {
        }

        public async Task<ActionResult> Index()
        {
            // TODO: In the InFilter params, specify which content types should be included in the sitemap
            var parameters = new List<IQueryParameter>
            {
                new DepthParameter(0),
                new InFilter("system.type", "article", "cafe"),
            };

            var response = await DeliveryClient.GetItemsAsync(parameters);

            var nodes = response.Items.Select(item => new SitemapNode(GetPageUrl(item.System))
                {
                    LastModificationDate = item.System.LastModified
                })
                .ToList();

            return new SitemapProvider().CreateSitemap(new SitemapModel(nodes));
        }

        private static string GetPageUrl(ContentItemSystemAttributes system)
        {
            // TODO: Adjust the URL generation logic to match your website
            var url = string.Empty;

            if(system.SitemapLocation.Any())
            {
                url = $"/{system.SitemapLocation[0]}";
            }

            url = $"{url}/{system.Codename.Replace("_", "-").TrimEnd('-')}";

            return url;
        }
    }
}
