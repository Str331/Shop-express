using ChaikaTest.Domain;
using Microsoft.AspNetCore.Http;
using System.Runtime.InteropServices;
using System.Text;

namespace ChaikaTest.Infrastructure.Helpers
{
    public static class DataExtractor
    {
        public static object ExtractData(byte[] data, Domain.Constants.DataType toDataType, bool fromOldGrids = false)
        {
            if (data == null || data.Length == 0)
            {
                data = DataEncoder.GetNullData(toDataType);
            }

            try
            {
                #region deprecated

                //deprecated
                if (fromOldGrids)
                {
                    switch (toDataType)
                    {
                        case Domain.Constants.DataType.Picture:
                            return Encoding.UTF8.GetString(data);
                        default:
                            //TODO Implement handling unsupported data types
                            throw new NotImplementedException();
                    }
                }

                #endregion

                //new
                else
                {
                    throw new NotImplementedException();
                }
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e);
                return ExtractData(DataEncoder.GetNullData(toDataType), toDataType, fromOldGrids);
            }
        }

        public static byte[] FileToBytes(IFormFile file)
        {
            if (file.Length > 0)
            {
                using var ms = new MemoryStream();
                file.CopyTo(ms);
                var fileBytes = ms.ToArray();
                return fileBytes;
            }

            return null;
        }

        static T[] ToListOf<T>(byte[] array, Func<byte[], int, T> bitConverter)
        {
            var size = Marshal.SizeOf(typeof(T));
            return Enumerable.Range(0, array.Length / size)
                .Select(i => bitConverter(array, i * size))
                .ToArray();
        }
    }
}
