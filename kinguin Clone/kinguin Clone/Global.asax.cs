// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Global.asax.cs" company="">
//   
// </copyright>
// <summary>
//   The global.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#region

using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;

#endregion

namespace kinguin_Clone
{
    /// <summary>
    /// The global.
    /// </summary>
    public class Global : HttpApplication
    {
        /// <summary>
        /// The application_ start.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}