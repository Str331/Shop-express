using MediatR;
using Microsoft.AspNetCore.Http;

namespace ChaikaTest.Application.Image.Update
{
    public class UpdateImageRequestDTO : IRequest<UpdateImageResponseDTO>
    {
        public int Id { get; set; }

        public IFormFileCollection Files { get; set; }

        public UpdateImageRequestDTO(int id, IFormFileCollection files)
        {
            Id = id;
            Files = files;
        }
    }
}
