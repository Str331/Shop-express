using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaikaTest.Infrastructure.Services
{
    public interface IMD5ChecksumService
    {
        public string MD5Checksum(byte[] inputBuffer);
    }
}
