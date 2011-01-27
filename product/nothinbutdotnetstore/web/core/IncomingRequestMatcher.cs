namespace nothinbutdotnetstore.web.core
{
	public interface IncomingRequestMatcher
	{
		bool Match<T>(Request request);
	}
}