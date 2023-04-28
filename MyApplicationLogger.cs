public class MyAppInsightLogger : IMyLogger
	{
		public const string ApplicationName = "MyLogger";
		private readonly ILogger _appInsiLog;


		public MyAppInsightLogger()
		{
			var telemetryClient = new TelemetryClient(TelemetryConfiguration.CreateDefault())
			{
				InstrumentationKey = "guid" //config["InstrumentationKey"]
			};

			telemetryClient.Context.Cloud.RoleName = ApplicationName;

			var appInsightLoggerConfig = new LoggerConfiguration()
				.WriteTo.Async(a => a.ApplicationInsights(telemetryClient, TelemetryConverter.Traces))
				.Enrich.WithProperty("MachineName", Environment.MachineName)
				.Enrich.WithProperty("Application", ApplicationName);

			_appInsiLog = appInsightLoggerConfig.CreateLogger();
		}


		public void Info(string message) => _appInsiLog.Information(message);

		public void Info(Exception e, string message) => _appInsiLog.Warning(e, message);

		public void Error(string message) => _appInsiLog.Error(message);

		public void Error(Exception e, string message) => _appInsiLog.Warning(e, message);
	}
