using ChaikaTest.Domain.Constants;

namespace ChaikaTest.Domain
{
    public class Image
    {
        public int Id { get; set; }

        public string ContentType { get; set; }

        public long Length { get; set; }

        public string FileName { get; set; }

        public byte[] Content { get; set; }

        public ImageType ImageType { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
