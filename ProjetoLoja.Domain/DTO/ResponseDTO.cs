using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoLoja.Domain.DTO
{
    public class ResponseDTO
    {
        public bool Success { get; private set; }
        public string Message { get; private set; }

        public ResponseDTO(bool success, string message)
        {
            Success = success;
            Message = message;
        }
    }
}
