public static class IocContainer
	{
		public static IServiceCollection Registered(this IServiceCollection services, IConfiguration config = null)
		{
			services.AddTransient<IMyLogger, MyAppInsightLogger>();

			return services;
		}
	}
