using MediatR;

namespace ChaikaTest.Application.Image.Read
{
    public class ReadImageRequestDTO : IRequest<ReadImageResponseDTO>
    {
        public int ImageId { get; set; }

        public ReadImageRequestDTO(int imageId)
        {
            ImageId = imageId;
        }
    }
}
