using System.ComponentModel.DataAnnotations;

namespace EasyIntern.ViewModels
{
    public class InternLoginModel
    {
        [Required] public string UserName { get; set; }
        [Required] public string Password { get; set; }
    }
}