using System;

namespace Beco_tours.Data.Dto
{
    public class ResponseDto
    {
        public object Data { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string DisplayMessage { get; set; }
        public List<string> ErrorMessages { get; set; }
    }
}

