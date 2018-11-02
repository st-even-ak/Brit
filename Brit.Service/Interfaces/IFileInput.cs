using System.Collections.Generic;
using Brit.Service.Core;

namespace Brit.Service.Interfaces
{
    public interface IFileInput
    {
        Request<List<string>> ReadFile(string filePath);
    }
}