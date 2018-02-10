using System.Linq;
using System.Web.Optimization;

namespace MoscowCamerata2.Extensions
{
    public static class BundleExtensions
    {   
        public static Bundle IncludeWithCssRewriteUrlTransform(this Bundle bundle, params string[] virtualPaths)
        {
            //Ensure we add CssRewriteUrlTransform to turn relative paths (to images, etc.) in the CSS files into absolute paths.
            //Otherwise, you end up with 404s as the bundle paths will cause the relative paths to be off and not reach the static files.

            if ((virtualPaths != null) && (virtualPaths.Any()))
            {
                virtualPaths.ToList().ForEach(path => {
                    bundle.Include(path, new CssRewriteUrlTransform());
                });
            }

            return bundle;
        }
    }
}