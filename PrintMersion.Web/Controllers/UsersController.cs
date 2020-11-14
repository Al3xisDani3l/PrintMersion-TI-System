using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PrintMersion.Core.Entities;
using PrintMersion.Infrastructure.Data;
using PrintMersion.Core.Interfaces;

namespace PrintMersion.Web.Controllers
{
    public class UsersController : GenericController<User>
    {
        public UsersController(IRepository<User> repository, IRepository<Picture> repositoryPicture, IGlobal global, PrintMersionDBContext dBContext) : base(repository, repositoryPicture, global, dBContext)
        {
        }




        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public override async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Email,Phone,UserName,Password,IdPicture,Role")] User user)
        {
            ViewData["IdPicture"] = new SelectList(_context.Pictures, "Id", "Id", user.IdPicture);
            return await base.Create(user);
          
         
        }
        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public override async Task<IActionResult> Edit(int? id, [Bind("Id,FirstName,LastName,Email,Phone,UserName,Password,IdPicture,Role")] User user)
        {
            ViewData["IdPicture"] = new SelectList(_context.Pictures, "Id", "Id", user.IdPicture);
            return await base.Edit(id, user);

           
            
        }

        // GET: Users/Delete/5
      

       

       
    }
}
