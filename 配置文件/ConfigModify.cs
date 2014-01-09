private static void ChangeConfiguration()
{
	var config = ConfigurationManager.OpenExeConfiguration(Assembly.GetEntryAssembly().Location);
	var appSettings = config.GetSection("appSettings") as AppSettingsSection;
	if (appSettings == null) return;
	appSettings.Settings.Remove("name");
	appSettings.Settings.Add("name","FrankYou");
	config.Save();
}