using APIDTO.Category;
using Domains;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommand : IRequest<CategoryMinimalDto>
    {
        
        
        public string Name { get; set; }

        public int? ParentCategoryId { get; set; }
        //public CreateCategoryCommand(string name,int? ParentId=null)
        //{
        //    Name = name;
        //    ParentCategoryId = ParentId;
           
        //}


    }
}
