using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Io.Devs.Application.Features.Technologies.Dtos
{
    public class TechnologyGetByIdDto
    {
        public int Id { get; set; }
        public int ProgramingLanguageId { get; set; }
        public string ProgramingLanguageName { get; set; }
        public string Name { get; set; }
    }
}
