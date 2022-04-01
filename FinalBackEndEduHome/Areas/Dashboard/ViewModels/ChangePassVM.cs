using System.ComponentModel.DataAnnotations;

namespace FinalBackEndEduHome.Areas.Dashboard.ViewModels
{
    public class ChangePassVM
    {
        [Required, DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [Required, DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required, DataType(DataType.Password), Compare(nameof(NewPassword))]
        public string ConfirmNewPassword { get; set; }
    }
}
