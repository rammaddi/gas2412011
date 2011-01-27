namespace nothinbutdotnetstore.web.core
{
	public class CommandIncomingRequestMatcher : IncomingRequestMatcher
	{

		public bool Match<T>(Request request)
		{

			return (request.CommandName == typeof(T).Name);

		}


	}
}