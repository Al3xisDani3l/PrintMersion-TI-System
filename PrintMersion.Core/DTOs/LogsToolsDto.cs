using System;
using System.Collections.Generic;

namespace PrintMersion.Core.DTOs
{
    public  class LogsToolsDto
    {
        public int Id { get; set; }
        public int IdTool { get; set; }
        public int IdAdminister { get; set; }
        public DateTime StartUse { get; set; }
        public DateTime EndUse { get; set; }

        
    }
}
