using Microsoft.Ajax.Utilities;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Optimization;
using MoscowCamerat.HtmlHelpers; 

namespace MoscowCamerat.ScriptHelpers
{
    public class LicensedStyleBundle : Bundle
    {
        public LicensedStyleBundle(string virtualPath)
            : base(virtualPath)
        {
            this.Builder = new LicencedStyleBuilder(); 
        }

        public LicensedStyleBundle(string virtualPath, string cdnPath)
            : base(virtualPath, cdnPath)
        {
            this.Builder = new LicencedStyleBuilder(); 
        }
    }

    public class LicencedStyleBuilder : IBundleBuilder
    {
        public virtual string BuildBundleContent(Bundle bundle, BundleContext context, IEnumerable<BundleFile> files)
        {
            var content = new StringBuilder();
            foreach (var file in files)
            {
                FileInfo f = new FileInfo(HttpContext.Current.Server.MapPath(file.VirtualFile.VirtualPath));
                CssSettings settings = new CssSettings();
                settings.IgnoreAllErrors = true; 
                settings.CommentMode = CssComment.None;
                var minifier = new Minifier();
                string readFile = Read(f);
                string res = minifier.MinifyStyleSheet(readFile, settings);
                content.Append(res);
            }

            return content.ToString();
        }

        public static string Read(FileInfo file)
        {
            using (var r = file.OpenText())
            {
                return r.ReadToEnd();
            }
        }
    }

    public class LicensedScriptBundle : Bundle
    {
        public LicensedScriptBundle(string virtualPath)
            : base(virtualPath)
        {
            this.Builder = new LicensedScriptBuilder();
        }

        public LicensedScriptBundle(string virtualPath, string cdnPath)
            : base(virtualPath, cdnPath)
        {
            this.Builder = new LicensedScriptBuilder();
        }
    }

    public class LicensedScriptBuilder : IBundleBuilder
    {
        public virtual string BuildBundleContent(Bundle bundle, BundleContext context, IEnumerable<BundleFile> files)
        {
            var content = new StringBuilder();
            content.Append(Common.AddHeader());
            foreach (var file in files)
            {
                FileInfo f = new FileInfo(HttpContext.Current.Server.MapPath(file.VirtualFile.VirtualPath));
                CodeSettings settings = new CodeSettings();
                settings.RemoveUnneededCode = true;
                settings.StripDebugStatements = true;
                settings.PreserveImportantComments = false;
                settings.TermSemicolons = true;
                var minifier = new Minifier();
                string readFile = Common.Read(f);
                string res = minifier.MinifyJavaScript(readFile, settings);
                if (minifier.ErrorList.Count > 0)
                {
                    content.Insert(0, Common.PrependErrors(readFile, minifier.ErrorList));
                }
                else
                {
                    content.Append(res);
                }
            }

            return content.ToString();
        }
    }
}