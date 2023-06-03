using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium.Infrasturucture.Dtos.Entities.Get
{
    public class GetArticleTagsDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<GetTagDto> Tags { get; set; }
    }
}
