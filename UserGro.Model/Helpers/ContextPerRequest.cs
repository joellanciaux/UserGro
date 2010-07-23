using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace UserGro.Model.Helpers
{
    /// <summary>
    /// This is going to hold one context per web request. 
    /// Maybe look at switching this to ninject's PerRequest but for now rock on.
    /// 
    /// References: http://stackoverflow.com/questions/194999/are-static-class-instances-unique-to-a-request-or-a-server-in-asp-net
    /// </summary>
    public class ContextPerRequest
    {
        public Context Context { get; set; }

        private ContextPerRequest()
        {
            Context = new Context(); 
        }

        public static ContextPerRequest Instance
        {
            get
            {
                var items = HttpContext.Current.Items;
                if(!items.Contains("RequestContext"))
                {
                    items["RequestContext"] = new ContextPerRequest();
                }

                return items["RequestContext"] as ContextPerRequest;
            }
        }
    }
}
