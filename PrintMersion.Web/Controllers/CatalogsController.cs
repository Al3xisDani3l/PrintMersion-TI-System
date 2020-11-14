﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PrintMersion.Core.Entities;
using PrintMersion.Core.Interfaces;
using PrintMersion.Infrastructure.Data;

namespace PrintMersion.Web.Controllers
{
    public class CatalogsController : GenericController<Catalog>
    {
        public CatalogsController(IRepository<Catalog> repository, IRepository<Picture> repositoryPicture, IGlobal global, PrintMersionDBContext dBContext) : base(repository, repositoryPicture, global, dBContext)
        {
        }






    }
}
