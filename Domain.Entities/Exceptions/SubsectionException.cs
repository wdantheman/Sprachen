

namespace Domain.Entities.Exceptions
{
    public class SubsectionException : ArgumentException
    {
        string data;
        public SubsectionException(string display)
        {
            data = display;
        }
    }
}
