using System.Collections.Generic;

namespace Evona.Task.Application.Responses
{
    public class BaseCommandResponse : DefaultResponse
    {
        public int Id { get; set; }
        public List<string> Errors { get; set; }
    }
}
