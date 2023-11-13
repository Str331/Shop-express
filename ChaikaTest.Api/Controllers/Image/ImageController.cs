using ChaikaTest.Application.Image.Create;
using ChaikaTest.Application.Image.Delete;
using ChaikaTest.Application.Image.Read;
using ChaikaTest.Application.Image.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ChaikaTest.Api.Controllers.Image
{
    [Route("Image")]
    public class ImageController : Controller
    {
        private readonly IMediator _mediator;

        public ImageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("{transactionId}"), DisableRequestSizeLimit]
        public async Task<CreateImageResponseDTO> Create(int transactionId, IFormFileCollection files)
        {
            var result = await _mediator.Send(new CreateImageRequestDTO(transactionId, files));
            return new CreateImageResponseDTO(result.Id);
        }

        [HttpGet("{imageId}")]
        public async Task<IActionResult> Read(int imageId)
        {
            var result = await _mediator.Send(new ReadImageRequestDTO(imageId));
            if (result.Content != default) return File(result.Content, result.ContentType, result.FileName);
            return Redirect(result.FileName);
        }

        [HttpDelete("{imageId}")]
        public async Task<Unit> Delete(int imageId)
        {
            return await _mediator.Send(new DeleteImageRequestDTO(imageId));
        }

        [HttpPut("{id}"), DisableRequestSizeLimit]
        public async Task<UpdateImageResponseDTO> Update(int id, IFormFileCollection files)
        {
            return await _mediator.Send(new UpdateImageRequestDTO(id, files));
        }
    }
}
