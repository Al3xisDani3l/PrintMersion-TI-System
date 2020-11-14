using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrintMersion.Core.Entities;
using PrintMersion.Core.Interfaces;

namespace PrintMersion.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersPicturesController : GenericController<UsersPictures>
    {
        public UsersPicturesController(IRepository<UsersPictures> Repository, IService<UsersPictures> service) : base(Repository, service)
        {
        }
    }
}