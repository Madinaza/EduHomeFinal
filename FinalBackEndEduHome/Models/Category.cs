using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinalBackEndEduHome.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength: 50)]
        public string Name { get; set; }
        [MaxLength(100)]
      
        public List<CourseCategory> CourseCategories { get; set; }

    }
}
