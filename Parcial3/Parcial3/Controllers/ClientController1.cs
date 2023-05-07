using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parcial3.Dal;
using Parcial3.Dal.Entities;
using Parcial3.Enums;
using Parcial3.Helpers;
using Parcial3.Models;

namespace Parcial3.Controllers
{
    [Authorize (Roles ="Client")]
    public class ClientController : Controller
    {
        private readonly IUserHelper _userHelper;
        private readonly DatabaseContext _context;
        private readonly IDropDownListsHelper _ddlHelper;
        private readonly IAzureBlobHelper _azureBlobHelper;

        public ClientController(IUserHelper userHelper, DatabaseContext context, IDropDownListsHelper dropDownListsHelper, IAzureBlobHelper azureBlobHelper)
        {
            _userHelper = userHelper;
            _context = context;
            _ddlHelper = dropDownListsHelper;
            _azureBlobHelper = azureBlobHelper;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Users
                .Include(v => v.Vehicle)
                .ThenInclude(s => s.Service)
                //.ThenInclude(b => b.Vehicle)
                .ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> addVehicle_services()
        {
            Guid emptyGuid = new Guid();

            VehicleServiceModel vehicleServiceModel = new()
            {
                Id = Guid.Empty,
                Services = await _ddlHelper.GetDDLServicesAsync(),              
                UserType = UserType.Client,
            };

            return View(vehicleServiceModel);
        }

        [HttpPost]

        public async Task<IActionResult> addVehicle_services(VehicleServiceModel vehicleServiceModel)
        {
            if (ModelState.IsValid)
            {
                Vehicle vehicle = new()
                {
                    Owner = vehicleServiceModel.Owner,
                    NumberPlate = vehicleServiceModel.NumberPlate,
                    Service = (Service)vehicleServiceModel.Services
                };
                try
                {
                   
                    _context.Add(vehicle);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya esta en proceso");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }
            return View(Index);
        }
    }
        }
    

