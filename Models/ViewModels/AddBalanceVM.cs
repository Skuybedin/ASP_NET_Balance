using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace BalanceTest.Models.ViewModels
{
    public class AddBalanceVM
    {
        public AddBalance AddBalance { get; set; }
        public IEnumerable<SelectListItem> UsersSelectList { get; set; }
    }
}
