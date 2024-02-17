using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RazorCrudWithWebApi.Pages
{
    public class ClassModel
    {
        public int Id { get; set; }
        public string? ClassName { get; set; }
    }

    public partial class AccountType
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public bool? AcStatus { get; set; }
    }

    public class IndexModel : PageModel
    {
        public List<ClassModel> Classes { get; set; }
        public List<AccountType> Account { get; set; }
        [BindProperty]
        public int SelectedClassId { get; set; }
        public IndexModel()
        {
            Classes = new List<ClassModel>
            {
                new ClassModel { Id = 1, ClassName = "Class A" },
                new ClassModel { Id = 2, ClassName = "Class B" },
                new ClassModel { Id = 3, ClassName = "Class C" }
            };
        }
    }
}
