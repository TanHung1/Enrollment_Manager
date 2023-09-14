using System.ComponentModel.DataAnnotations;

namespace Phanmemquanlyghidanh.Models
{
    public class SubjectCategory
    {
        [Key]
        public int SubjectCategory_Id { get; set; }

        public string SubjectCategory_Name { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();
    }
}
