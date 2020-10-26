using PrintMersion.Core.Interfaces;
using System;
namespace PrintMersion.Core.DTOs
{
    public class LogsToolsDto : IEntity
    {
        public int Id { get; set; }
        public int IdTool { get; set; }
        public int IdAdminister { get; set; }
        public DateTime StartUse { get; set; }
        public DateTime EndUse { get; set; }


    }
}
