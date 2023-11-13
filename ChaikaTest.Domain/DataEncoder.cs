using Newtonsoft.Json.Linq;

namespace ChaikaTest.Domain
{
    public static class DataEncoder
    {
        public static byte[] EncodeDataToBytes(object data, Constants.DataType fromDataType)
        {
            byte[] encodedData;

            if (data == null)
            {
                return GetNullData(fromDataType);
            }

            if (data.GetType() == typeof(JObject))
            {
                var obj = (JObject)data;
                if (!obj.HasValues)
                {
                    return GetNullData(fromDataType);
                }

                if (obj.Count == 0)
                {
                    return GetNullData(fromDataType);
                }
            }

            switch (fromDataType)
            {
                case Constants.DataType.Picture:
                    encodedData = BitConverter.GetBytes(Convert.ToInt32(data));
                    break;

                default:
                    throw new NotImplementedException();
            }

            return encodedData;
        }

        public static byte[] GetNullData(Constants.DataType dataType)
        {
            switch (dataType)
            {
                case Constants.DataType.Picture:
                    return EncodeDataToBytes(0, Constants.DataType.Picture);

                default:
                    throw new NotImplementedException();
            }
        }
    }
}
