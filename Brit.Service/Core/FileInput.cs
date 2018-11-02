using System.Collections.Generic;
using System.IO;
using System.Linq;
using Brit.Service.Interfaces;

namespace Brit.Service.Core
{
    public class FileInput : IFileInput
    {
        public Request<List<string>> ReadFile(string filePath)
        {
            var request = new Request<List<string>>();//"IFileInput");

            if (filePath.Equals(string.Empty))
            {
                request.Exception = @"No file path value supplied";
                return request;
            }

            if (!File.Exists(filePath))
            {
                request.Exception = @"File Path references non existent file";
                return request;
            }

            request.CalcFunctions = File.ReadLines(filePath).ToList();

            return request;
        }
    }
}
