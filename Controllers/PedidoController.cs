using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CacauShowApi324123267.Data;
using CacauShowApi324123267.Models;

namespace CacauShowApi324123267.Controllers
{
    
[ApiController]
[Route("api/controller")]

    public class PedidoController : ControllerBase
    {
        private readonly AppDbcontext _Context;

    
    public PedidoController(AppDbcontext context)
        {
            _Context = context;

        }

        }
    }
