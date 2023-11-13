using ChaikaTest.Domain;
using System.Net;

namespace ChaikaTest.Infrastructure.Helpers
{
    public static class PropertyChecker
    {
        public static void CheckNullAndThrow404<T>(T objectToCheck, string errorMessage = "")
        {
            var type = typeof(T);
            if (objectToCheck == null)
            {
                if (errorMessage.Length == 0)
                {
                    throw new RestException(HttpStatusCode.NotFound, new { Error = $"{type.Name} could not be found!" });
                }
                else
                {
                    throw new RestException(HttpStatusCode.NotFound, new { Error = errorMessage });
                }
            }
        }
    }
}
