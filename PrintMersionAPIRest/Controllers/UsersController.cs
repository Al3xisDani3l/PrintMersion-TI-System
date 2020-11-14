using Microsoft.AspNetCore.Mvc;
using PrintMersion.Core.Entities;
using PrintMersion.Core.Interfaces;
using System.Threading.Tasks;

namespace PrintMersion.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : GenericController<User>
    {
        IPasswordService _passwordService;

        //    private readonly IRepository<Administer> _administerRepository;
        public UsersController(IRepository<User> administerRepository, IService<User> service, IPasswordService passwordService) : base(administerRepository, service)
        {
            _passwordService = passwordService;
        }

        [HttpPut]
        public override async Task<IActionResult> Put(User entity)
        {

            var current = await _Repository.Get(entity.Id);

            if (current.Password != entity.Password)
            {
                entity.Password = _passwordService.Hash(entity.Password);
            }

           

            return await base.Put(entity);
        }

        [HttpPost]
        public override async Task<IActionResult> Post(User entity)
        {

            
            entity.Password = _passwordService.Hash(entity.Password);

            return await base.Post(entity);
        }
        //    [HttpGet]
        //    public async Task<IActionResult> Get()
        //    {
        //        var administers = await _administerRepository.Get();
        //        return Ok(administers);
        //    }

        //    [HttpGet("{id}")]
        //    public async Task<IActionResult> Get(int id)
        //    {
        //        var adm = await _administerRepository.Get(id);
        //        return Ok(adm);
        //    }

        //    [HttpPost]
        //    public async Task<IActionResult> post(Administer administer)
        //    {
        //        await _administerRepository.Post(administer);
        //        return Ok(administer);
        //    }

    }
}

