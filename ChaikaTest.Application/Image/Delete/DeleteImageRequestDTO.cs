using MediatR;

namespace ChaikaTest.Application.Image.Delete
{
    public class DeleteImageRequestDTO : IRequest<Unit>
    {
        public int ImageId { get; set; }

        public DeleteImageRequestDTO(int imageId)
        {
            ImageId = imageId;
        }
    }
}
