using System.Web;
using System.Web.Optimization;
using MoscowCamerat.ScriptHelpers;
using MoscowCamerat.Extensions; 

namespace MoscowCamerat
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            BundleTable.Bundles.UseCdn = true;

            bundles.Add(new LicensedScriptBundle("~/bundles/jqueryjs", "https://ajax.googleapis.com/ajax/libs/jquery/3.1.1/jquery.min.js"
                            //"https://code.jquery.com/jquery-1.10.0.min.js" 
                            )
                        .Include(
                        "~/js/jquery-3.1.1.min.js"
                        //"~/js/jquery-1.10.0.min.js"
                        ));

            bundles.Add(new LicensedScriptBundle("~/bundles/ajaxjs"/*, "http://ajax.aspnetcdn.com/ajax/mvc/3.0/jquery.unobtrusive-ajax.min.js"*/).Include(
                        "~/js/jquery.unobtrusive-ajax.min.js" 
                        ));  

            bundles.Add(new LicensedScriptBundle("~/bundles/jqueryvalidatejs").Include(
                        "~/js/jquery.validate.min.js"
                        )); 

            bundles.Add(new LicensedScriptBundle("~/bundles/jqueryunobtrusiveajaxjs"/*, "http://ajax.aspnetcdn.com/ajax/mvc/3.0/jquery.unobtrusive-ajax.min.js"*/).Include(
                        "~/js/jquery.unobtrusive-ajax.min.js"
                        ));


            bundles.Add(new LicensedScriptBundle("~/bundles/jqueryvalidateunobtrusivejs", "https://cdnjs.cloudflare.com/ajax/libs/jquery-validation-unobtrusive/3.2.6/jquery.validate.unobtrusive.min.js").Include(
                "~/js/jquery.validate.unobtrusive.min.js"
            ));


            bundles.Add(
                        //new LicensedScriptBundle("~/bundles/bootstrapjs", "https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-alpha.5/js/bootstrap.min.js") 
                        new LicensedScriptBundle("~/bundles/bootstrapjs") 
                        .Include(
                            "~/js/moment.min.js",
                            "~/js/bootstrap.min.js"
                            ,"~/js/bootstrap-datetimepicker.min.js"
                            ,"~/js/bootstrap-datetimepicker.ru.js"
                        )
                        );

            bundles.Add(new LicensedScriptBundle("~/bundles/violinjs").Include(
                        "~/js/violin.js"
                        ));

            bundles.Add(new LicensedScriptBundle("~/bundles/medijs").Include(
                        "~/js/medi.js"
                        ));

            bundles.Add(new LicensedScriptBundle("~/bundles/photoswipejs").Include(
                        "~/PhotoSwipe/photoswipe.min.js",
                        "~/PhotoSwipe/photoswipe-ui-default.min.js"
                        ));

            bundles.Add(new LicensedScriptBundle("~/bundles/photoswipemanjs").Include(
                    "~/js/photoswipe.js"
                        ));

            bundles.Add(new LicensedScriptBundle("~/bundles/videojs").Include(
                        "~/js/youtube-video-player.jquery.js",
                        "~/js/jquery.mousewheel.js",
                        "~/js/perfect-scrollbar.js",
                        "~/js/jquery.powertip.js"
                        ));

            bundles.Add(new LicensedScriptBundle("~/bundles/bar-uijs").Include(
                    "~/js/bar-ui.js"
                    ));

            bundles.Add(new LicensedScriptBundle("~/bundles/soundmanager2js").Include(
                    "~/js/soundmanager2-nodebug-jsmin.js"
                    ));

            bundles.Add(new LicensedScriptBundle("~/bundles/mdbminjs").Include(
                    "~/js/mdb.min.js" 
                    ));

            bundles.Add(new LicensedScriptBundle("~/bundles/tetherjs").Include(
                    "~/js/tether.min.js"
                    ));

            bundles.Add(new LicensedStyleBundle("~/bundles/photoswipecss").IncludeWithCssRewriteUrlTransform(
                    "~/PhotoSwipe/photoswipe.css", 
                    "~/PhotoSwipe/default-skin/default-skin.css" 
                      ));

            bundles.Add(new LicensedStyleBundle("~/bundles/css").IncludeWithCssRewriteUrlTransform(
                      "~/css/bootstrap.css",
                      "~/css/modern-business.css", 
                      "~/css/bootstrap-social.css",
                      "~/css/bootstrap-datetimepicker.min.css" 
                      ));

            bundles.Add(new LicensedStyleBundle("~/bundles/bootstrapcss").IncludeWithCssRewriteUrlTransform(
                      "~/css/bootstrap.css"
                      ));

            bundles.Add(new LicensedStyleBundle("~/bundles/fontawesomecss", "https://maxcdn.bootstrapcdn.com/font-awesome/4.6.0/css/font-awesome.min.css")
                      .IncludeWithCssRewriteUrlTransform(
                      "~/css/font-awesome.min.css"
                      ));

            bundles.Add(new LicensedStyleBundle("~/bundles/violincss").IncludeWithCssRewriteUrlTransform( 
                      "~/css/violin.css" 
                      )); 

            bundles.Add(new LicensedStyleBundle("~/bundles/videocss").IncludeWithCssRewriteUrlTransform( 
                        "~/css/youtube-video-player.css", 
                        "~/css/perfect-scrollbar.css", 
                        "~/css/jquery.powertip-dark.css" 
                    )); 

            bundles.Add(new LicensedStyleBundle("~/bundles/material-iconscss", "https://fonts.googleapis.com/icon?family=Material+Icons")
                        .IncludeWithCssRewriteUrlTransform(
                        "~/css/material-icons-debug.css"
                      )); 

            bundles.Add(new LicensedStyleBundle("~/bundles/bar-uicss").IncludeWithCssRewriteUrlTransform(
                      "~/css/bar-ui.css" 
                      )); 

            bundles.Add(new LicensedStyleBundle("~/bundles/mdbcss").IncludeWithCssRewriteUrlTransform( 
                      "~/css/mdb.css" 
                      )); 

            if (!HttpContext.Current.IsDebuggingEnabled)
            {
                BundleTable.EnableOptimizations = true;
            }
        }
    }
}
