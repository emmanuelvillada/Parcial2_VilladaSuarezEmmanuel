using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Parcial3.Dal;
using Parcial3.Helpers;

namespace Parcial3.Services
{
	public class DropDownListsHelper : IDropDownListsHelper
	{
		private readonly DatabaseContext _context;

		public DropDownListsHelper(DatabaseContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<SelectListItem>> GetDDLServicesAsync()
		{
			List<SelectListItem> listServices = await _context.Services
				.Select(s => new SelectListItem
				{
					Text = s.Name, //Col
					Value = s.Id.ToString(), //Guid                    
				})
				.OrderBy(s => s.Text)
				.ToListAsync();

			listServices.Insert(0, new SelectListItem
			{
				Text = "Selecione un servicio...",
				Value = "0",
			});

			return listServices;
		}
	}
}
