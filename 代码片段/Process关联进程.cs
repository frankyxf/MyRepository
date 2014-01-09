using (var process = new Process
{
	StartInfo =
	{
		FileName = "cmd.exe",
		UseShellExecute = false,
		RedirectStandardError = true,
		RedirectStandardInput = true,
		RedirectStandardOutput = true,
		CreateNoWindow = true,
	}
})
{
	process.Start();
	process.StandardInput.WriteLine("ipconfig");
	process.StandardInput.WriteLine("exit");
	if (!process.WaitForExit(200000))
	{
		process.Kill();
	}
	txtResult.Text = process.StandardOutput.ReadToEnd();
}
