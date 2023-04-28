public interface IMyLogger
	{
		void Error(Exception e, string message);
		void Error(string message);
		void Info(Exception e, string message);
		void Info(string message);
	}
