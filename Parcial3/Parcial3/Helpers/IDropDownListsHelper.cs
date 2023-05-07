using Microsoft.AspNetCore.Mvc.Rendering;

namespace Parcial3.Helpers
{
	public interface IDropDownListsHelper
	{
		Task<IEnumerable<SelectListItem>> GetDDLServicesAsync();
	}
}
