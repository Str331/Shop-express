using ShopTest.View.Task.Query;
using ShopTest.View.Task.Read;

namespace ShopTest.Api.Controllers.Task.Query
{
    public class QueryTasksResponse
    {
        public List<ReadTaskResponseDTO> ReadTasks { get; set; }

        public QueryTasksResponse(QueryTasksResponseDTO dTO)
        {
            ReadTasks = dTO.Tasks;
        }
    }
}
