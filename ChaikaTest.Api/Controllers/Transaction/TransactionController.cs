using ChaikaTest.Api.Controllers.Transaction.Create;
using ChaikaTest.Application.Transaction.Create;
using ChaikaTest.Application.Transaction.Delete;
using ChaikaTest.Application.Transaction.Query;
using ChaikaTest.Application.Transaction.Read;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ChaikaTest.Api.Controllers.Transaction
{
    [Route("Transaction")]
    public class TransactionController : Controller
    {
        private readonly IMediator _mediator;
        public TransactionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("")]
        public async Task<CreateTransactionResponseDTO> CreateTransaction([FromBody] CreateTransactionRequest request)
        {
            var result = await _mediator.Send(request.GetDTO());

            return new CreateTransactionResponseDTO { Id = result.Id };
        }

        [HttpDelete("{transactionId}")]
        public async Task<Unit> DeleteTransaction(int transactionId)
        {
            return await _mediator.Send(new DeleteTransactionRequestDTO(transactionId));
        }

        [HttpGet("Latest-transactions/{cardId}")]
        public async Task<QueryTransactionListResponseDTO> TransactionList(int cardId)
        {
            var result = await _mediator.Send(new QueryTransactionListRequestDTO(cardId));

            return result;
        }

        [HttpGet("Transaction-detail/{transactionId}")]
        public async Task<ReadTransactionResponseDTO> TransactionDetail(int transactionId)
        {
            var result = await _mediator.Send(new ReadTransactionRequestDTO(transactionId));

            return result;
        }
    }
}
