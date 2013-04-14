namespace Excella.Lean.Web
{
    using System;
    using System.Web.Optimization;

    public static class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();
            AddDefaultIgnorePatterns(bundles.IgnoreList);

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/Site.css",
                "~/Content/toastr.css"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/lib/modernizr/modernizr-*"));

            bundles.Add(
                new ScriptBundle("~/bundles/mvvm").Include(
                "~/Scripts/lib/jquery/jquery-{version}.js",
                "~/Scripts/lib/jquery/migrate/jquery-migrate-{version}.js",
                "~/Scripts/lib/q/q.js",
                "~/Scripts/lib/knockout/knockout-{version}.js",
                "~/Scripts/lib/underscore/underscore-{version}.js",
                "~/Scripts/lib/signals/signals.min.js",
                "~/Scripts/lib/crossroads/crossroads.min.js",
                "~/Scripts/lib/hasher/hasher.min.js",
                "~/Scripts/lib/pubsub/pubsub-*",
                "~/Scripts/lib/boilerplate/groundwork.min.js",
                "~/Scripts/lib/stacktrace/stacktrace.js",
                "~/Scripts/lib/toastr/toastr.js",
                    "~/Scripts/lib/date/date.js"));

#if RELEASE
            BundleTable.EnableOptimizations = true;
#endif
        }

        public static void AddDefaultIgnorePatterns(IgnoreList ignoreList)
        {
            if (ignoreList == null)
            {
                throw new ArgumentNullException("ignoreList");
            }

            ignoreList.Ignore("*.intellisense.js");
            ignoreList.Ignore("*-vsdoc.js");
            ignoreList.Ignore("*.debug.js", OptimizationMode.WhenEnabled);
            ////ignoreList.Ignore("*.min.js", OptimizationMode.WhenDisabled);
            ignoreList.Ignore("*.min.css", OptimizationMode.WhenDisabled);
        }
    }
}