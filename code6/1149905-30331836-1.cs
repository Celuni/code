	public static void RegisterBundles(BundleCollection bundles)
	{
		bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
					 "~/Scripts/jquery-{version}.js"));
		BundleTable.EnableOptimizations = true;
	}
